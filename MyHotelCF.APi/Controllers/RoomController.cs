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
    public class RoomController : ApiController
    {
        private IRoomService service;
        public RoomController() { }
        public IMapper mapper;

        private MapperConfiguration config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<RoomDTO, RoomModel>();
            cfg.CreateMap<RoomCategoryDTO, RoomCategoryModel>();
        });
        public RoomController(IRoomService service)
        {
            this.service = service;
            mapper = config.CreateMapper();
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
        public RoomModel Get(HttpRequestMessage request, int id)
        {
            try
            {
                var data = service.Get(id);
                var room = new RoomModel();
                if (data == null)
                {
                    throw new NullReferenceException();
                }

                room = mapper.Map<RoomDTO, RoomModel>(data);
                return room;
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
        }

        // POST: api/Room
        [ResponseType(typeof(RoomModel))]
        public HttpResponseMessage Post(HttpRequestMessage request, Room room)
        {
            try
            {
                service.Post(room);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NullReferenceException)
            {
                return request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        // PUT: api/Room/5
        [ResponseType(typeof(RoomModel))]
        public HttpResponseMessage Put(HttpRequestMessage request, int id, Room room)
        {
            try
            {
                service.Put(id, room);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NullReferenceException)
            {
                return request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/Room/5
        [ResponseType(typeof(RoomModel))]
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
