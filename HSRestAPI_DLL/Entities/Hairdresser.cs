using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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


        public virtual List<TimeRange> WorkingDays { get; set; } = new List<TimeRange>();
        //public List<TimeRange> WorkingDays = new List<TimeRange>();
        public virtual List<Appointment> Appointments { get; set; } = new List<Appointment>();
        //public List<Appointment> Appointments = new List<Appointment>();
        
    }
}
