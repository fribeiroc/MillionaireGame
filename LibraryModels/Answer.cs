using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class Answer
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
