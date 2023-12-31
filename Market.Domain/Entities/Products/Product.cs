﻿using Market.Domain.Commons;
using Market.Domain.Entities.Common;

namespace Market.Domain.Entities.Products
{
    public class Product: Auditable<long>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }

        public long? CategoryId { get; set; }
        public ProductCategory? Category { get; set; }

        public long? FileId { get; set; }
        public Attachment File { get; set; }
    }
}
