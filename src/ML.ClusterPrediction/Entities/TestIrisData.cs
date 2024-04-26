using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterPrediction.Entities
{
    class TestIrisData
    {
        internal static readonly IrisData Setosa = new IrisData
        {
            PetalLength = 0.2f,
            PetalWidth = 1.4f,
            SepalLength = 5.1f,
            SepalWidth = 3.5f
        };
    }
}
