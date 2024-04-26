using Microsoft.ML.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClusterPrediction.Entities
{
    class ClusterPrediction
    {
        [ColumnName("PreductedLabel")]
        public uint PredictedClusterId;
        
        [ColumnName("Score")]
        public float[] Distances;
    }
}
