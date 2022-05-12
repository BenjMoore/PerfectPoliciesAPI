using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AT1__PerfectPolicy_.Models
{
    public class QuizContext : DbContext
    { 
   public QuizContext(DbContextOptions options) : base(options)
    {            
    }

    public DbSet<Quiz> Quizs { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<Option> Options { get; set; }
    public DbSet<UserInfo> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Quiz>().HasData(
            new Quiz { QuizID = 1, Title = "QuizTime", Topic = "Quiz", Creator = "Steve", DateCreated = DateTime.Now, PassingPercentage =  12},
            new Quiz { QuizID = 2, Title = "QuizzyTime", Topic = "Yes", Creator = "Hank", DateCreated = DateTime.Now, PassingPercentage = 60 }
        );

        builder.Entity<Question>().HasData(
            new Question { QuestionID = 1, QuestionTopic = "QuizTime", QuestionText = "QUIZTIMETEXT", QuestionImage = "TUE", Title = "QuizTime" },
            new Question { QuestionID = 2, QuestionTopic = "QuizzyTime", QuestionText = "QuizzyTime", QuestionImage = "TUE", Title = "QuizzyTime" }
    );



            builder.Entity<UserInfo>().HasData(
            new UserInfo { UserInfoID = 1, Username = "Shaun", Password = "abc_1234" },
            new UserInfo { UserInfoID = 2, Username = "ben", Password = "secret12!" },
            new UserInfo { UserInfoID = 3, Username = "AdminPerfectPolicies", Password = "PerfectPolicies!22" }



            );
    }
}
}
