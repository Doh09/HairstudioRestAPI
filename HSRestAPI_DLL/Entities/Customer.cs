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
        private Dictionary<DateTime, Appointment> Appointments = new Dictionary<DateTime, Appointment>();

        #region Appointments
        /// <summary>
        /// Gets an appointment, using the DateTime object as key.
        /// The time of the DateTime object used is set to 00:00:00, so only the Date is used.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public Appointment GetAppointment(DateTime date)
        {
            var onlyDate = date.Date; //Ensure dictionary look-up only uses date and not time.
            return Appointments[onlyDate];
        }

        /// <summary>
        /// Returns a dictionary with all appointments for this customer.
        /// </summary>
        /// <returns></returns>
        public Dictionary<DateTime, Appointment> GetAllAppointments()
        {
            return Appointments;
        }

        /// <summary>
        /// Sets a given appointment, using the Date from the Appointment object as key.
        /// The time of the DateTime object used is set to 00:00:00, so only the Date is used.
        /// </summary>
        public void SetAppointment(Appointment appointment)
        {
            var date = appointment.TimeAndDate.GetDate().Date;
            Appointments.Add(date, appointment);
        }
        #endregion
    }
}
