﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AT1__PerfectPolicy_.DTO
{
    public class OptionCreate
    {
        public string OptionText { get; set; }
        public string OptionOrderByLetter { get; set; }
        public string OptionOrderByNumber { get; set; }
        public string Answer { get; set; }
        public int QuestionID { get; set; }
    }
}
