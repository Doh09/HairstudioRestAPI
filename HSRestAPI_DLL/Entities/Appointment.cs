using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRestAPI_DLL.Entities
{
    public class Appointment : AbstractEntity
    {
        /*Appointment : AbstractEntity
        - Appointment start time
        - Appointment end time
        - HairdresserID
        - CustomerID
         */
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int HairdresserID { get; set; }
        public int CustomerID { get; set; }
    }
}
