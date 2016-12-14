using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRestAPI_DLL.Entities
{
    public class ServiceOffered : IEntity
    {
        #region IEntity
        public int ID { get; set; }
        #endregion
        /*ServiceOffered : IEntity
        - Message
        - Price
        */
        public string Message { get; set; }
        public double Price { get; set; }
    }
}
