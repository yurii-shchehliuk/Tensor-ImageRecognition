using ClusterPrediction.Entities;
using Microsoft.ML;

namespace ClusterPrediction
{
    internal class Program
    {
        static string dataPath = "D:\\_repos\\Tensor-ImageRecognition\\data\\prediction\\iris.data";
        static string modelath = Path.Combine("D:\\_repos\\Tensor-ImageRecognition\\data\\prediction", "IrisClusterModel.zip");
        static void Main(string[] args)
        {
            //4. Create a ML context
            var mlContext = new MLContext(seed: 0);

            var dataView = mlContext.Data.LoadFromTextFile<IrisData>(
                path: dataPath,
                separatorChar: ',',
                hasHeader: false);

            //6. create a learning pipeline
            string featuresColumnName = "Features";
            var pipeline = mlContext.Transforms
                .Concatenate(featuresColumnName,
                "SepalLength",
                "SepalWidth",
                "PetalLength",
                "PetalWidth")
                .Append(mlContext.Clustering.Trainers.KMeans(featuresColumnName, numberOfClusters: 3));

            //7. Train and save
            var trainedModel = pipeline.Fit(dataView);

            using var fileStream = new FileStream(modelath, FileMode.Create, FileAccess.Write, FileShare.Write);
            mlContext.Model.Save(trainedModel, dataView.Schema, fileStream);

            var predictor = mlContext.Model.CreatePredictionEngine<IrisData, Entities.ClusterPrediction>(trainedModel);

            //8. Predict
            var prediction = predictor.Predict(TestIrisData.Setosa);
            Console.WriteLine($"Cluster: {prediction.PredictedClusterId}");
            Console.WriteLine($"Distances: {string.Join(" ", prediction.Distances)}");
            Console.ReadLine();

        }
    }
}
