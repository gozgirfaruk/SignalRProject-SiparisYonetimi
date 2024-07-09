﻿namespace SignalR.EntityLayer.Entities
{
    public class Discount
    {
        public int DiscountID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int Amount { get; set; }
        public string? Description { get; set; }
        public bool Status { get; set; }
    }
}
