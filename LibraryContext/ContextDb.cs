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
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().HasData(
                new Answer() { Id = 1, Description = "A. Portugal" },
                new Answer() { Id = 2, Description = "B. Espanha" },
                new Answer() { Id = 3, Description = "C. Argentina" },
                new Answer() { Id = 4, Description = "D. Malta" },
                new Answer() { Id = 5, Description = "A. Gato" },
                new Answer() { Id = 6, Description = "B. Coelho" },
                new Answer() { Id = 7, Description = "C. Papagaio" },
                new Answer() { Id = 8, Description = "D. Coentros" }
            );
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Description = "Geografia" },
                new Category() { Id = 2, Description = "Cultura Portuguesa" },
                new Category() { Id = 3, Description = "Animais" }
            );
            modelBuilder.Entity<Question>().HasData(
                new Question() { Id = 1, Description = "Qual destes está mais próximo de França?", AnswerId = 2, CategoryId = 1 },
                new Question() { Id = 2, Description = "Qual destes fala?", AnswerId = 8, CategoryId = 3 }
            );
        }
    }
}
