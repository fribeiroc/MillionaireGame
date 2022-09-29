using LibraryModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;

namespace LibraryContext
{
    public class ContextDb : DbContext, IDesignTimeDbContextFactory<ContextDb>
    {
        public ContextDb(DbContextOptions<ContextDb> options)
            : base(options)
        {   
        }

        //2º After adding the IDesignTimeDbContextFactory and function CreateDbContext, the following error occured: No parameterless constructor defined for type 'LibraryContext.ContextDb'
        //As checked in https://stackoverflow.com/questions/1355464/asp-net-mvc-no-parameterless-constructor-defined-for-this-object the issue might be the new ContextDb
        //instance being created in CreateDbContext function. To fix this I added a parameterless constructor.
        public ContextDb()     
        {
        }

        //1º Added to fix error: Unable to create an object of type 'ContextDb'. For the different patterns supported at design time, see https://go.microsoft.com/fwlink/?linkid=851728
        //Which is required as per interface IDesignTimeDbContextFactory. This error occured when I tried to Add-Migration in Package Manager Console
        public ContextDb CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<ContextDb>();
            optionBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MillionaireGame;Trusted_Connection=True;MultipleActiveResultSets=true");
            return new ContextDb(optionBuilder.Options);
        }

        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<BuyingCart> BuyingCarts { get; set; }
        public DbSet<CartLine> CartLines { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*modelBuilder.Entity<Answer>().HasData(
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
                new Category() { Id = 3, Description = "Animais" },
                new Category() { Id = 4, Description = "História" },
                new Category() { Id = 5, Description = "Ciencias" }
            );
            modelBuilder.Entity<Question>().HasData(
                new Question() { Id = 1, Description = "Qual destes está mais próximo de França?", AnswerId = 2, CategoryId = 1 },
                new Question() { Id = 2, Description = "Qual destes fala?", AnswerId = 8, CategoryId = 3 },
                new Question() { Id = 3, Description = "Quem é o maior?", AnswerId = 4, CategoryId = 5 },
                new Question() { Id = 4, Description = "O que é que se come aqui?", AnswerId = 5, CategoryId = 1 }
            );*/
        }
    }
}
