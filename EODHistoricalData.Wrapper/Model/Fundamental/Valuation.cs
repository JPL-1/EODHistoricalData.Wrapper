﻿namespace EOD.Model.Fundamental
{
    /// <summary>
    /// 
    /// </summary>
    public class Valuation
    {
        /// <summary>
        /// 
        /// </summary>
        public double? TrailingPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? ForwardPE { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? PriceSalesTTM { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? PriceBookMRQ { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public long? EnterpriseValue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? EnterpriseValueRevenue { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public double? EnterpriseValueEbitda { get; set; }
    }
}
