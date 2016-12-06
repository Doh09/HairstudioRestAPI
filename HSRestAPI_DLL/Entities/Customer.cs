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
        public List<Appointment> Appointments { get; set; }

        #region Appointments
        /// <summary>
        /// Gets an appointment, using the DateTime object as search parameter.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public Appointment GetAppointment(DateTime date)
        {
            return Appointments.FirstOrDefault(a => a.TimeRange.GetDate().Date == date.Date);
        }

        /// <summary>
        /// Adds the given appointment to the Hairdressers appointment list.
        /// </summary>
        public void AddAppointment(Appointment appointment)
        {
            Appointments.Add(appointment);
        }
        #endregion
    }
}
