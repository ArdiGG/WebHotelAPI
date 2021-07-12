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
using MyHotelCF.APi.Models;

namespace MyHotelCF.APi.Controllers
{
    public class BookingController : ApiController
    {
        
        private IBookingService service;
        public BookingController() { }
        public IMapper mapper;
        public BookingController(IBookingService service)
        {
            this.service = service;
            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<BookingDTO, BookingModel>()).CreateMapper();
        }
        // GET: api/Booking
        public IEnumerable<BookingDTO> Get()
        {

            var data = service.GetAllBookings();
            return data;
           
        }

        // GET: api/Booking/5
        
        public BookingModel Get(HttpRequestMessage request ,int id)
        {
            try
            {
                var booking = new BookingModel();
                var data = service.Get(id);
                if (data != null)
                {
                    booking = mapper.Map<BookingDTO, BookingModel>(data);
                }
                else
                {
                    throw new NullReferenceException();
                }

                return booking;
            }
            catch (NullReferenceException ex)
            {
                return new BookingModel();
            }
        }

        // POST: api/Booking
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Booking/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Booking/5
        public void Delete(int id)
        {
        }
        
    }
}
