using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyHotel.BLL.DTO;
using MyHotel.BLL.Interfaces;
using MyHotel.DAL.Entities;
using MyHotel.DAL.Interfaces;

namespace MyHotel.BLL.Services
{
    public class BookingService : IBookingService
    {
        private MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Booking, BookingDTO>();
            cfg.CreateMap<Guest, GuestDTO>();
            cfg.CreateMap<Room, RoomDTO>();
            cfg.CreateMap<RoomCategory, RoomCategoryDTO>();
        });

        private IWorkUnit Database { get; set; }

        public BookingService(IWorkUnit database)
        {
            this.Database = database;
        }

        public IEnumerable<BookingDTO> GetAllBookings()
        {
            
            var data = Database.Bookings.GetAll();
            var mapper = config.CreateMapper();
            return mapper.Map<IEnumerable<Booking>, List<BookingDTO>>(data);
        }

        public void Put(int id, Booking booking)
        {
            Database.Bookings.Put(id,booking);
        }
        public void Post(Booking booking)
        {
            Database.Bookings.Add(booking);
        }

        public void Delete(int id)
        {
            Database.Bookings.Delete(id);
        }
        public BookingDTO Get(int id)
        {
            var booking = Database.Bookings.Get(id);
            var mapper = config.CreateMapper();
            return mapper.Map<Booking, BookingDTO>(booking);
        }
    }
}
