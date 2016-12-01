using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSRestAPI_DLL.Entities;
using HSRestAPI_DLL.Interfaces;
using HSRestAPI_DLL.Repositories;

namespace HSRestAPI_DLL
{
    public class Facade
    {
        private IRepository<Hairdresser> _hairdresserRepository;
        private IRepository<Message> _messageRepository;
        private IRepository<Appointment> _appointmentRepository;
        private IRepository<TimeRange> _timeRangeRepository;
        public IRepository<Hairdresser> GetHairdresserRepository()
        {
            return _hairdresserRepository ?? (_hairdresserRepository = new HairdresserRepository());
        }

        public IRepository<Message> GetMessageRepository()
        {
            return _messageRepository ?? (_messageRepository = new MessageRepository());
        }

        public IRepository<Appointment> GetAppointmentRepository()
        {
            return _appointmentRepository ?? (_appointmentRepository = new AppointmentRepository());
        }
        public IRepository<TimeRange> GetTimeRangeRepository()
        {
            return _timeRangeRepository ?? (_timeRangeRepository = new TimeRangeRepository());
        }
    }
}
