using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Server.Data.Models;

namespace Server.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        public DbSet<Answer> Answers { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Exam> Exams { get; set; }

        public DbSet<ExamQuestion> ExamQuestion { get; set; }

        public DbSet<UserAnswer> UserAnswer { get; set; }

        public DbSet<UserExam> ExamParticipants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=.;Database=QuizSystem;Trusted_Connection=True;MultipleActiveResultSets=true");
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExamQuestion>()
                .HasKey(x => new {x.QuestionId, x.ExamId});

            modelBuilder.Entity<UserExam>()
                .HasKey(x => new {x.ExamId, x.UserId});

            var entityTypes = modelBuilder.Model.GetEntityTypes().ToList();

            var foreignKeys = entityTypes.SelectMany(e =>
                e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));

            foreach (var keys in foreignKeys)
            {
                keys.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}