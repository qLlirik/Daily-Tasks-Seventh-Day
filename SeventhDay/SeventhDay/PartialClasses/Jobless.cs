using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeventhDay.DB
{
    partial class Jobless
    {
        public string FullName
        {
            get
            {
                return LastName + ' ' + FirstName + ' ' + Patronymic; 
            }
        }
    }
}
