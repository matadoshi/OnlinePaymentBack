﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Service.DTO.Slider
{
    public class SliderPutDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MainTitle { get; set; }
        public string SubTitle { get; set; }
        public string Image { get; set; }
    }
}
