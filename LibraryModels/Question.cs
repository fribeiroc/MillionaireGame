using System;

namespace LibraryModels
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string Description { get; set; }
        public virtual int AnswerId { get; set; }
        public virtual Answer Answer { get; set; }
    }
}
