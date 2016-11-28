using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRestAPI_DLL.Entities
{
    public class Hairdresser : User
    {
        /*Hairdresser : User //ID and other variables inherited are tested in User.
        - Working hours
        - Appointments
         */
        public Dictionary<DateTime, WorkingDay> WorkingHours { get; set; }
        public Dictionary<DateTime, Appointment> Appointments { get; set; }

    }
}
