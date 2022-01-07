using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryModels
{
    public class Answer
    {
        public int AnswerId { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
    }
}
