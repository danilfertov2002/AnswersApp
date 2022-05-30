using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnswersApp
{
    public class Helper
    {
        public static AnswersContext db = new AnswersContext();
        public static User userSession;
        public static Task task;
        public static User searchsession;
    }
}
