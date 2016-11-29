using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSRestAPI_DLL.Entities
{
    public class Hairdresser : User
    {
        /*Hairdresser : User //ID and other variables inherited are tested in User.
        - Working hours
        - Appointments
         */
        internal Dictionary<DateTime, TimeRange> WorkingDays = new Dictionary<DateTime, TimeRange>();
        internal Dictionary<DateTime, Appointment> Appointments = new Dictionary<DateTime, Appointment>();

        #region Working days
        public TimeRange GetWorkingDay(DateTime date)
        {
            var onlyDate = date.Date; //Ensure dictionary look-up only uses date and not time.
            return WorkingDays[onlyDate];
        }

        public Dictionary<DateTime, TimeRange> GetAllWorkingDays()
        {
            return WorkingDays;
        }

        public void SetAllWorkingDays(Dictionary<DateTime, TimeRange> newWorkingDays)
        {
            WorkingDays = newWorkingDays;
        }


        /// <summary>
        /// Sets a given working day, using the Date from the WorkingDay object as key.
        /// The time of the DateTime object used is set to 00:00:00, so only the Date is used.
        /// </summary>
        public void SetWorkingDay(TimeRange workingDay)
        {
            var date = workingDay.GetDate().Date;
            WorkingDays.Add(date, workingDay);
        }
        #endregion

        /// <summary>
        /// Gets an appointment, using the DateTime object as key.
        /// The time of the DateTime object used is set to 00:00:00, so only the Date is used.
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        #region Appointments
        public Appointment GetAppointment(DateTime date)
        {
            var onlyDate = date.Date; //Ensure dictionary look-up only uses date and not time.
            return Appointments[onlyDate];
        }

        /// <summary>
        /// Returns a dictionary with all appointments for this hairdresser.
        /// </summary>
        /// <returns></returns>
        public Dictionary<DateTime, Appointment> GetAllAppointments()
        {
            return Appointments;
        }

        public void SetAllAppointments(Dictionary<DateTime, Appointment> newAppointments)
        {
            Appointments = newAppointments;
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
