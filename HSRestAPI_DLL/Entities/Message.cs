using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRestAPI_DLL.Entities
{
    public class Message : AbstractEntity
    {
        /*Message (for website, e.g. welcome messagge) : AbstractEntity
        - Description
        */
        public string Description { get; set; }
    }
}
