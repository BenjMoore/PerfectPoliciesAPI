using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AT1__PerfectPolicy_.Models
{
    public class Quiz
    {
        public int QuizID { get; set; }
        public string Title { get; set; }
        public string Topic { get; set; }
        public string Creator { get; set; }
        public DateTime DateCreated { get; set; }
        public int PassingPercentage { get; set; }

        // Navigation Properties
        public ICollection<Question> Questions { get; set; }
    }
}
