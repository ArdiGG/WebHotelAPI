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
            
            var guests = mapper.Map<IEnumerable<GuestDTO>,List<GuestModel>> (data);
            return guests;
        }

        // GET: api/Guest/5 
        [ResponseType(typeof(GuestModel))]
        public HttpResponseMessage Get(HttpRequestMessage request,int id)
        {
            try
            {
                var guest = new GuestModel();
                var data = service.Get(id);
                if (data != null)
                {
                    guest = mapper.Map<GuestDTO, GuestModel>(data);
                }
                else
                {
                    throw new NullReferenceException();
                }

                return request.CreateResponse(HttpStatusCode.OK,guest);
            }
            catch (NullReferenceException ex)
            {
                return request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        // POST: api/Guest
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Guest/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Guest/5
        public void Delete(int id)
        {
        }
    }
}
