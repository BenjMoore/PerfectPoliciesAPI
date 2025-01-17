﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AT1__PerfectPolicy_.Models
{
    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionTopic { get; set; }
        public string QuestionText { get; set; }
        public string QuestionImage { get; set; }
        public string Title { get; set; }

        //public int QuizID { get; set; }

        public Quiz quiz { get; set; }
        public ICollection<Option> Options { get; set; }

    }

}
