using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRestAPI_DLL.Entities
{
    public class ServiceOffered : AbstractEntity
    {
        /*ServiceOffered : AbstractEntity
        - Message
        - Price
        */
        public Message Message { get; set; }
        public double Price { get; set; }
    }
}
