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
        public virtual List<TimeRange> WorkingDays { get; set; }
        //public List<TimeRange> WorkingDays = new List<TimeRange>();
        public virtual List<Appointment> Appointments { get; set; }
        //public List<Appointment> Appointments = new List<Appointment>();

        #region Working days
        public TimeRange GetWorkingDay(DateTime date)
        {
            return WorkingDays.FirstOrDefault(a => a.GetDate().Date == date.Date);
        }

        /// <summary>
        /// Adds a given working day.
        /// </summary>
        public void AddWorkingDay(TimeRange workingDay)
        {
            WorkingDays.Add(workingDay);
        }
        #endregion

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
