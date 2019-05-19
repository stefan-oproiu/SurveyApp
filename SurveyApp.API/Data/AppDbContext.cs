using Microsoft.EntityFrameworkCore;
using SurveyApp.API.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SurveyApp.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<QuestionChoiceDb> QuestionChoices { get; set; }
        public DbSet<QuestionDb> Questions { get; set; }
        public DbSet<SubmissionDb> Submissions { get; set; }
        public DbSet<SubmissionQuestionChoice> SubmissionQuestionChoices { get; set; }
        public DbSet<SurveyDb> Surveys { get; set; }
        public DbSet<SurveyQuestionDb> SurveyQuestions { get; set; }
        public DbSet<UserDb> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SubmissionQuestionChoice>()
                .HasKey(bc => new { bc.SubmissionId, bc.QuestionChoiceId });

            modelBuilder.Entity<SurveyQuestionDb>()
                 .HasKey(bc => new { bc.QuestionId, bc.SurveyId });

            modelBuilder.Entity<SubmissionQuestionChoice>()
                .HasOne(s => s.QuestionChoice)
                .WithMany(q => q.Submissions);

            modelBuilder.Entity<SubmissionQuestionChoice>()
                .HasOne(s => s.Submission)
                .WithMany(s => s.Choices);

            modelBuilder.Entity<SurveyQuestionDb>()
                .HasOne(s => s.Question)
                .WithMany(s => s.Surveys);

            modelBuilder.Entity<SurveyQuestionDb>()
                .HasOne(s => s.Survey)
                .WithMany(s => s.Questions);
        }
    }
}
