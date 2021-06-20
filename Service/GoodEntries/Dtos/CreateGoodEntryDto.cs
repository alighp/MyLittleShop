using System;

namespace MyLittleShop.Service.GoodEntries.Dtos
{
    public class CreateGoodEntryDto
    {

        public string Code { get; set; }
        public int TotalPrice { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
        public int GoodId { get; set; }
    }
}