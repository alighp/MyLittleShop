﻿using System;

namespace MyLittleShop.Controllers
{
    public class UpdateGoodEntryDto
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}