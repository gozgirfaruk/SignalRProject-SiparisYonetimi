﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.DiscountDtos
{
    public class GetDiscountDto
    {
        public int DiscountID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
    }
}
