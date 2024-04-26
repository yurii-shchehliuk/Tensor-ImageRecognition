namespace ImageRecognition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(@"D:\_repos\Tensor-ImageRecognition\data\images\blue\download (1).png");
            MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
            var result = MLModel1.Predict(sampleData);
        }
    }
}
