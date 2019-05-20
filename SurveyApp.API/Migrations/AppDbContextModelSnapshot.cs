﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SurveyApp.API.Data;

namespace SurveyApp.API.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SurveyApp.API.Data.Entities.QuestionChoiceDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("QuestionId");

                    b.Property<string>("Text");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("QuestionChoices");
                });

            modelBuilder.Entity("SurveyApp.API.Data.Entities.QuestionDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Text");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("SurveyApp.API.Data.Entities.SubmissionDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SurveyId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SurveyId");

                    b.HasIndex("UserId");

                    b.ToTable("Submissions");
                });

            modelBuilder.Entity("SurveyApp.API.Data.Entities.SubmissionQuestionChoiceDb", b =>
                {
                    b.Property<int>("SubmissionId");

                    b.Property<int>("QuestionChoiceId");

                    b.HasKey("SubmissionId", "QuestionChoiceId");

                    b.HasIndex("QuestionChoiceId");

                    b.ToTable("SubmissionQuestionChoices");
                });

            modelBuilder.Entity("SurveyApp.API.Data.Entities.SurveyDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Surveys");
                });

            modelBuilder.Entity("SurveyApp.API.Data.Entities.SurveyQuestionDb", b =>
                {
                    b.Property<int>("QuestionId");

                    b.Property<int>("SurveyId");

                    b.HasKey("QuestionId", "SurveyId");

                    b.HasIndex("SurveyId");

                    b.ToTable("SurveyQuestions");
                });

            modelBuilder.Entity("SurveyApp.API.Data.Entities.UserDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<string>("Password");

                    b.Property<int>("Role");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SurveyApp.API.Data.Entities.QuestionChoiceDb", b =>
                {
                    b.HasOne("SurveyApp.API.Data.Entities.QuestionDb", "Question")
                        .WithMany("Choices")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurveyApp.API.Data.Entities.SubmissionDb", b =>
                {
                    b.HasOne("SurveyApp.API.Data.Entities.SurveyDb", "Survey")
                        .WithMany("Submissions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurveyApp.API.Data.Entities.UserDb", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurveyApp.API.Data.Entities.SubmissionQuestionChoiceDb", b =>
                {
                    b.HasOne("SurveyApp.API.Data.Entities.QuestionChoiceDb", "QuestionChoice")
                        .WithMany("Submissions")
                        .HasForeignKey("QuestionChoiceId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurveyApp.API.Data.Entities.SubmissionDb", "Submission")
                        .WithMany("Choices")
                        .HasForeignKey("SubmissionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SurveyApp.API.Data.Entities.SurveyQuestionDb", b =>
                {
                    b.HasOne("SurveyApp.API.Data.Entities.QuestionDb", "Question")
                        .WithMany("Surveys")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SurveyApp.API.Data.Entities.SurveyDb", "Survey")
                        .WithMany("Questions")
                        .HasForeignKey("SurveyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
