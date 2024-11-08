﻿using VismaTechnicalTest.Common;

namespace VismaTechnicalTest.Models
{
    public class ProductSelectionViewModel
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public List<ProductToOrder> ProductsToOrder { get; set; } = new();
        public List<DiscountType> AvailableDiscounts { get; set; }
    }
}
