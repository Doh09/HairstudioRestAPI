using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRestAPI_DLL.Entities
{
    public class TimeRange : AbstractEntity
    {
        /*TimeRange : AbstractEntity
        - Date
        - Start time
        - End time
         */
        private DateTime Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        #region Date
        /// <summary>
        /// Gets the date of the TimeRange object.
        /// The time of the DateTime object used is set to 00:00:00, so only the Date is used.
        /// </summary>
        /// <returns></returns>
        public DateTime GetDate()
        {
            return Date.Date;//Ensure only return date and not time.
        }

        /// <summary>
        /// Sets the date of the TimeRange object.
        /// The time of the DateTime object used is set to 00:00:00, so only the Date is used.
        /// </summary>
        public void SetDate(DateTime date)
        {
            Date = date.Date;
        }
        #endregion
    }
}
