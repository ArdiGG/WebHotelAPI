using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoMapper;
using Moq;
using MyHotel.BLL.DTO;
using MyHotel.BLL.Interfaces;
using MyHotel.DAL.Entities;
using MyHotelCF.APi.Controllers;
using MyHotelCF.APi.Models;

namespace Hotel.Test
{
    [TestClass]
    public class RoomCategoryControllerTest
    {
        [TestMethod]
        public void GetMethodIsRoomCategoryModel()
        {
            int id = 1;
            var mock = new Mock<IRoomCategoryService>();
            mock.Setup(a => a.Get(id)).Returns(new RoomCategoryDTO());

            RoomCategoryController controller = new RoomCategoryController(mock.Object);
            var result = controller.Get(new HttpRequestMessage(), 1);

            Assert.IsInstanceOfType(result, typeof(RoomCategoryModel));
        }

        [TestMethod]
        public void GetMethodTest()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoomCategoryDTO, RoomCategoryModel>();
            }).CreateMapper();

            int id = 1;
            var mock = new Mock<IRoomCategoryService>();
            mock.Setup(a => a.Get(id)).Returns(new RoomCategoryDTO());

            RoomCategoryController controller = new RoomCategoryController(mock.Object);
            var result = controller.Get(new HttpRequestMessage(), 1);

            var expected = mapper.Map<RoomCategoryDTO, RoomCategoryModel>(mock.Object.Get(id));

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetAllRoomCategoriesTest()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoomCategoryDTO, RoomCategoryModel>();
            }).CreateMapper();

            var mock = new Mock<IRoomCategoryService>();
            mock.Setup(a => a.GetAllRoomCategories()).Returns(new List<RoomCategoryDTO>());

            RoomCategoryController controller = new RoomCategoryController(mock.Object);
            var result = controller.Get();

            var expected = mapper.Map<IEnumerable<RoomCategoryDTO>, List<RoomCategoryModel>>(mock.Object.GetAllRoomCategories());

            Assert.AreEqual(expected.Count, result.Count());
        }
        [TestMethod]
        public void DeleteRoomCategoryTest()
        {
            int id = 1;
            var mock = new Mock<IRoomCategoryService>();
            mock.Setup(a => a.Delete(id));

            RoomCategoryController controller = new RoomCategoryController(mock.Object);
            var result = controller.Delete(new HttpRequestMessage(), id);

            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }
        [TestMethod]
        public void DeleteRoomCategoryNotNullTest()
        {
            int id = 1;
            var mock = new Mock<IRoomCategoryService>();
            mock.Setup(a => a.Delete(id));

            RoomCategoryController controller = new RoomCategoryController(mock.Object);
            var result = controller.Delete(new HttpRequestMessage(), id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void PostRoomCategoryNotNullTest()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoomCategoryModel, RoomCategoryDTO>();
            }).CreateMapper();

            RoomCategoryModel roomCategory = new RoomCategoryModel()
            {
                Bed = 2,
                Name = "Standart",
                Price = 200
            };

            var mock = new Mock<IRoomCategoryService>();
            mock.Setup(a => a.Post(mapper.Map<RoomCategoryModel,RoomCategoryDTO>(roomCategory)));

            RoomCategoryController controller = new RoomCategoryController(mock.Object);
            var result = controller.Post(new HttpRequestMessage(), roomCategory);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void PutRoomCategoryNotNullTest()
        {
            int id = 1;

            RoomCategory roomCategory = new RoomCategory()
            {
                Bed = 2,
                Name = "Standart",
                Price = 200
            };

            var mock = new Mock<IRoomCategoryService>();
            mock.Setup(a => a.Put(id,roomCategory));

            RoomCategoryController controller = new RoomCategoryController(mock.Object);
            var result = controller.Put(new HttpRequestMessage(), id,roomCategory);

            Assert.IsNotNull(result);
        }
    }
}
