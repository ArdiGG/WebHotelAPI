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
    public class RoomController : ApiController
    {
        private IRoomService service;
        public RoomController() { }
        public IMapper mapper;
        public RoomController(IRoomService service)
        {
            this.service = service;
            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<RoomDTO, RoomModel>()).CreateMapper();
        }

        // GET: api/Room
        public IEnumerable<RoomModel> Get()
        {
            var data = service.GetAllRooms();
            var rooms = mapper.Map<IEnumerable<RoomDTO>, List<RoomModel>>(data);
            return rooms;
        }

        // GET: api/Room/5
        [ResponseType(typeof(RoomModel))]
        public HttpResponseMessage Get(HttpRequestMessage request, int id)
        {
            try
            {
                var data = service.Get(id);
                var room = new RoomModel();
                if (data != null)
                {
                    room = mapper.Map<RoomDTO, RoomModel>(data);
                }
                else
                {
                    throw new NullReferenceException();
                }

                return request.CreateResponse(HttpStatusCode.OK, room);
            }
            catch (NullReferenceException ex)
            {
                return request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        // POST: api/Room
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Room/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Room/5
        public void Delete(int id)
        {
        }
        
    }
}
