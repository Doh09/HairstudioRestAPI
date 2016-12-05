using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.Entities;

namespace HSRestAPI_DLL
{
    public static class EntityUpdater
    {
        public static void UpdateTimeRange(TimeRange existingTR, TimeRange newTR)
        {
            existingTR.TheDate = newTR.TheDate;
            existingTR.EndTime = newTR.EndTime;
            existingTR.StartTime = newTR.StartTime;

        }
        public static void UpdateAppointment(Appointment existingA, Appointment newA)
        {
            UpdateTimeRange(existingA.TimeRange, newA.TimeRange);
            //existingA.TimeRange.TheDate = newA.TimeRange.TheDate;

        }
        public static void UpdateCustomer()
        {
        }
        public static void UpdateHairdresser()
        {
        }


    }
}
