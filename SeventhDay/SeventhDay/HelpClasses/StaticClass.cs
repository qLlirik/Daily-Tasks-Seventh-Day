using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeventhDay.HelpClasses
{
    class StaticClass
    {
        static public DB.Users AuthUser;
        static public DB.Entity db = new DB.Entity();
        static public DB.Vacancies SelectVacancy;
    }
}
