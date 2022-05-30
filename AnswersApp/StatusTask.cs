using System;
using System.Collections.Generic;

namespace AnswersApp
{
    public partial class StatusTask
    {
        public StatusTask()
        {
            Tasks = new HashSet<Task>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
