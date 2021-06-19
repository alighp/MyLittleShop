﻿using MyLittleShop.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyLittleShop.Service
{
    public class CreateGoodDto
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }
        public ColorEnum ColorID { get; set; }
    }
}
