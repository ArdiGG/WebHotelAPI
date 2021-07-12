using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using MyHotel.BLL.DTO;
using MyHotel.BLL.Interfaces;
using MyHotelCF.APi.Models;

namespace MyHotelCF.APi.Controllers
{
    public class FreeRoomsController : ApiController
    {
        private IBookingService bookingService;
        private IRoomService roomService;
        private IMapper mapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<BookingDTO, BookingModel>();
            cfg.CreateMap<GuestDTO, GuestModel>();
            cfg.CreateMap<RoomDTO, RoomModel>();
        }).CreateMapper();

        private IMapper RoomMapper = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<RoomDTO, RoomModel>();
            cfg.CreateMap<RoomCategoryDTO, RoomCategoryModel>();
        }).CreateMapper();
        public FreeRoomsController(IBookingService BookingService, IRoomService roomService)
        {
            this.bookingService = BookingService;
            this.roomService = roomService;
        }
        // GET: api/FreeRooms
        public IEnumerable<RoomModel> Get(FreeRoomsModel requiredRoom)
        {
            var dataBooking = mapper.Map<IEnumerable<BookingDTO>, List<BookingModel>>(bookingService.GetAllBookings());
            var dataRoom = RoomMapper.Map<IEnumerable<RoomDTO>, List<RoomModel>>(roomService.GetAllRooms());
            List<RoomModel> freeRooms = new List<RoomModel>();
            List<RoomModel> occupiedRooms = new List<RoomModel>();

            foreach (var booking in dataBooking)
            {
                if ((requiredRoom.ArriveDate >= booking.ArriveDate && requiredRoom.ArriveDate <= booking.DepartureDate) 
                    || (requiredRoom.ArriveDate <= booking.ArriveDate && requiredRoom.DepartureDate >= booking.ArriveDate)
                    || (requiredRoom.ArriveDate <= booking.ArriveDate && requiredRoom.DepartureDate >= booking.DepartureDate )
                    || (requiredRoom.DepartureDate >= booking.DepartureDate && requiredRoom.ArriveDate <= booking.DepartureDate)
                    || (requiredRoom.DepartureDate >= booking.ArriveDate && requiredRoom.DepartureDate <= booking.DepartureDate))
                {
                    occupiedRooms.Add(booking.BookingRoom);
                }
            }

            bool flag;
            for (int i = 0; i < dataRoom.Count; i++)
            {
                flag = true;
                foreach (var occupied in occupiedRooms)
                {
                    if (dataRoom[i].Id == occupied.Id)
                    {
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    freeRooms.Add(dataRoom[i]);
                }
            }
            
            return freeRooms;
        }

        // GET: api/FreeRooms/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/FreeRooms
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/FreeRooms/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/FreeRooms/5
        public void Delete(int id)
        {
        }
    }
}
