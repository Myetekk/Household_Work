using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Household_Works_Child.Model.DataBase
{
    class CheckDates
    {
        public bool on_time(string task_comm, string task_time)
        {
            var cultureInfo = new CultureInfo("pl-PL");
            DateTime dt_task_comm = DateTime.Parse(task_comm, cultureInfo);
            TimeSpan ts_task_time = TimeSpan.Parse(task_time, cultureInfo);


            TimeSpan timespan = DateTime.Now - dt_task_comm;

            if (timespan > ts_task_time) 
                return false;
            else 
                return true;
        }
    }
}
