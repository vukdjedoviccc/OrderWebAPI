﻿namespace Order.Domain.Request
{
    
    public class CreateProductRequest
    {
        
        public string Name { get; set; }
        
        public decimal Price { get; set; }
    }
}
