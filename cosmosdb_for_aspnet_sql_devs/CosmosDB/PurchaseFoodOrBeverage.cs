using System;
using System.Collections.Generic;
using System.Text;

namespace CosmosDB
{
    public class PurchaseFoodOrBeverage : IInteraction
    {
        public decimal unitPrice { get; set; }
        public decimal totalPrice { get; set; }
        public int quantity { get; set; }
        public string medium { get; set; }
        public string Id { get; set; }
        public string dayOfWeek { get; set; }
    }
}
