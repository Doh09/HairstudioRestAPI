using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRestAPI_DLL.Entities
{
    public class Message : IEntity
    {
        #region IEntity
        public int ID { get; set; }
        #endregion
        /*Message (for website, e.g. welcome messagge) : IEntity
        - AreaMessageIsUsed (for example "Welcome message"
        - Description
        */
        public string AreaMessageIsUsed { get; set; }
        public string Description { get; set; }
    }
}
