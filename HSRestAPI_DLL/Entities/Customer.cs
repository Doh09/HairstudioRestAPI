using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRestAPI_DLL.Entities
{
    public class Customer : User
    {
        /*Customer : User //ID and other variables inherited are tested in User.
        - Appointments
         */
        public virtual List<Appointment> Appointments { get; set; }
       
    }
}
