﻿using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal? Value { get; set; }
    }
}
