using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryModels
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
