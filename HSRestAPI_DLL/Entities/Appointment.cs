using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public virtual TimeRange TimeRange { get; set; }
        public virtual Hairdresser Hairdresser { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
