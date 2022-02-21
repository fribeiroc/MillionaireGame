using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryModels
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        //Adding an Answer per Question 1-M
        public virtual int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }

        //Adding a Category per Question 1-M
        public virtual int CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
}
