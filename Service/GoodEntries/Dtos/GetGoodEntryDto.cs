using System;

namespace MyLittleShop.Service.GoodEntries.Dtos
{
    public class GetGoodEntryDto
    {
        public int Id { get; set; }
        public string GoodCode { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}