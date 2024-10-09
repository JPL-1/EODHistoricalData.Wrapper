using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace EOD.Model.Fundamental
{
    /// <summary>
    /// 
    /// </summary>
    public class TopHoldings
    {
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Owned { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Change { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(Utils.PercentageConverter))]
        public double? Weight { get; set; }
    }
}
