using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRestAPI_DLL.Entities
{
    public class TimeRange : AbstractEntity
    {
        /*WorkingDay : AbstractEntity
        - TheDate
        - Start time
        - End time
         */
        public DateTime TheDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
