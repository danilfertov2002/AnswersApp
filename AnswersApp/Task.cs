using System;
using System.Collections.Generic;
using System.Linq;

namespace AnswersApp
{
    public partial class Task
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? DateOfPublication { get; set; }
        public int? IdCreator { get; set; }
        public int? IdAccepted { get; set; }
        public int? IdStatusTask { get; set; }
        public virtual User? IdAcceptedNavigation { get; set; }
        public virtual User? IdCreatorNavigation { get; set; }
        public virtual StatusTask? IdStatusTaskNavigation { get; set; }


    }
}
