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
using MyHotel.DAL.EF;
using MyHotel.DAL.Entities;
using MyHotelCF.APi.Models;

namespace MyHotelCF.APi.Controllers
{
    public class GuestController : ApiController
    {
        private IGuestService service;
        public IMapper mapper;
        public GuestController() { }

        public GuestController(IGuestService service)
        {
            this.service = service;
            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<GuestDTO, GuestModel>()).CreateMapper();
        }
        // GET: api/Guest
        public IEnumerable<GuestModel> GetAllGuests()
        {
            var data = service.GetAllGuests();

            var guests = mapper.Map<IEnumerable<GuestDTO>, List<GuestModel>>(data);
            return guests;
        }

        // GET: api/Guest/5 
        [ResponseType(typeof(GuestModel))]
        public GuestModel Get(HttpRequestMessage request, int id)
        {
            try
            {
                var guest = new GuestModel();
                var data = service.Get(id);
                if (data == null)
                {
                    throw new NullReferenceException();
                }

                guest = mapper.Map<GuestDTO, GuestModel>(data);
                return guest;
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
        }

        // POST: api/Guest
        [ResponseType(typeof(GuestModel))]
        public HttpResponseMessage Post(HttpRequestMessage request, GuestModel newGuest)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<GuestModel, GuestDTO>(); }).CreateMapper();

                service.Post(mapper.Map<GuestModel, GuestDTO>(newGuest));
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NullReferenceException)
            {
                return request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        // PUT: api/Guest/5
        [ResponseType(typeof(GuestModel))]
        public HttpResponseMessage Put(HttpRequestMessage request, int id, Guest guest)
        {
            try
            {
                service.Put(id, guest);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NullReferenceException)
            {
                return request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/Guest/5
        [ResponseType(typeof(GuestModel))]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            try
            {
                service.Delete(id);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NullReferenceException)
            {
                return request.CreateResponse(HttpStatusCode.NotFound);
            }
        }
    }
}
