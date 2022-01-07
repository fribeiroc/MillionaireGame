using LibraryModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace LibraryContext
{
    public class ContextDb : DbContext
    {
        public ContextDb(DbContextOptions<ContextDb> options)
            : base(options)
        {
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().HasData(
                new Answer() { Description = "A. Portugal" },
                new Answer() { Description = "B. Espanha" },
                new Answer() { Description = "C. Argentina" },
                new Answer() { Description = "D. Malta" },
                new Answer() { Description = "A. Gato" },
                new Answer() { Description = "B. Coelho" },
                new Answer() { Description = "C. Papagaio" },
                new Answer() { Description = "D. Coentros" }
                );
            modelBuilder.Entity<Question>().HasData(
                new Question() { Description = "Qual destes está mais próximo de França?", }
        }
    }
}
