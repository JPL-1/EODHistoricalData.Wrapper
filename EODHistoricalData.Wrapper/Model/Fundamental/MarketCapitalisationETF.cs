using Newtonsoft.Json;

namespace EOD.Model.Fundamental
{
    /// <summary>
    /// 
    /// </summary>
    public class MarketCapitalisationETF
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(Utils.SafeNumConverter))]
        public double? Mega { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(Utils.SafeNumConverter))]
        public double? Big { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(Utils.SafeNumConverter))]
        public double? Medium { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(Utils.SafeNumConverter))]
        public double? Small { get; set; }
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(Utils.SafeNumConverter))]
        public double? Micro { get; set; }
    }
}

