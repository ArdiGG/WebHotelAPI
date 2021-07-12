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
    public class RoomCategoryController : ApiController
    {
        private IRoomCategoryService service;
        private IMapper mapper;
        public RoomCategoryController() { }
        public RoomCategoryController(IRoomCategoryService service)
        {
            this.service = service;
            mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<RoomCategoryDTO, RoomCategoryModel>()).CreateMapper();

        }
        // GET: api/RoomCategory
        public IEnumerable<RoomCategoryModel> Get()
        {
            var data = service.GetAllRoomCategories();
            var roomCategories = mapper.Map<IEnumerable<RoomCategoryDTO>, List<RoomCategoryModel>>(data);
            return roomCategories;
        }

        // GET: api/RoomCategory/5
        [ResponseType(typeof(RoomCategoryModel))]
        public RoomCategoryModel Get(HttpRequestMessage request, int id)
        {
            try
            {
                var data = service.Get(id);
                if (data == null)
                {
                    throw new NullReferenceException();
                }

                var roomCategory = mapper.Map<RoomCategoryDTO, RoomCategoryModel>(data);
                return roomCategory;
            }
            catch (NullReferenceException ex)
            {
                return null;
            }
        }

        // POST: api/RoomCategory
        [ResponseType(typeof(RoomCategory))]
        public HttpResponseMessage Post(HttpRequestMessage request,RoomCategoryModel roomCategory)
        {
            try
            {
                var mapper = new MapperConfiguration(cfg => { cfg.CreateMap<RoomCategoryModel, RoomCategoryDTO>(); })
                    .CreateMapper();

                service.Post(mapper.Map<RoomCategoryModel, RoomCategoryDTO>(roomCategory));
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NullReferenceException)
            {
                return request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        // PUT: api/RoomCategory/5
        [ResponseType(typeof(RoomCategory))]
        public HttpResponseMessage Put(HttpRequestMessage request,int id, RoomCategory roomCategory)
        {
            try
            {
                service.Put(id, roomCategory);
                return request.CreateResponse(HttpStatusCode.OK);
            }
            catch (NullReferenceException)
            {
                return request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        // DELETE: api/RoomCategory/5
        [ResponseType(typeof(RoomCategory))]
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
