using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using MyHotel.BLL.DTO;
using MyHotel.BLL.Interfaces;
using MyHotel.DAL.Entities;
using MyHotelCF.APi.Models;

namespace MyHotelCF.APi.Controllers
{
    public class BookingController : ApiController
    {
        
        private IBookingService service;
        public BookingController() { }

        private MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<BookingDTO, BookingModel>();
            cfg.CreateMap<GuestDTO, GuestModel>();
            cfg.CreateMap<RoomDTO, RoomModel>();
        });
        public IMapper mapper;
        public BookingController(IBookingService service)
        {
            this.service = service;
            mapper = config.CreateMapper();
        }
        // GET: api/Booking

        public IEnumerable<BookingModel> GetAllBookings()
        {
            var data = service.GetAllBookings();
            var bookings = mapper.Map<IEnumerable<BookingDTO>, List<BookingModel>>(data);
            return bookings;

        }

        // GET: api/Booking/5
        [ResponseType(typeof(BookingModel))]
        public BookingModel Get(HttpRequestMessage request,int id)
        {
            try
            {
                var data = service.Get(id);
                if (data == null)
                {
                    throw new NullReferenceException();
                }

                var booking = mapper.Map<BookingDTO, BookingModel>(data);
                return booking;

            }
            catch (NullReferenceException ex)
            {
                return null;
            }
        }

        // POST: api/Booking
        [ResponseType(typeof(BookingModel))]
        public HttpResponseMessage Post(HttpRequestMessage request, Booking booking)
        {
            try
            {
                service.Post(booking);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NullReferenceException)
            {
                return request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        // PUT: api/Booking/5
        [ResponseType(typeof(BookingModel))]
        public HttpResponseMessage Put(HttpRequestMessage request, int id, Booking booking)
        {
            try
            {
                service.Put(id, booking);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch(NullReferenceException)
            {
                return request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/Booking/5
        [ResponseType(typeof(BookingModel))]
        public HttpResponseMessage Delete(HttpRequestMessage request,int id)
        {
            service.Delete(id);
            return request.CreateResponse(HttpStatusCode.OK);
        }
        
    }
}
