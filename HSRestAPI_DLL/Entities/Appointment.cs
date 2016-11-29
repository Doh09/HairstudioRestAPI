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
        - TimeRange
        - Hairdresser
        - Customer
         */
        public TimeRange TimeAndDate { get; set; }
        public Hairdresser Hairdresser { get; set; }
        public Customer Customer { get; set; }
    }
}
