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
    public class RoomControllerTest
    {
        [TestMethod]
        public void GetMethodIsRoomCategoryModel()
        {
            int id = 1;
            var mock = new Mock<IRoomService>();
            mock.Setup(a => a.Get(id)).Returns(new RoomDTO());

            RoomController controller = new RoomController(mock.Object);
            var result = controller.Get(new HttpRequestMessage(), 1);

            Assert.IsInstanceOfType(result, typeof(RoomModel));
        }

        [TestMethod]
        public void GetMethodTest()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<RoomDTO, RoomModel>();
            }).CreateMapper();

            int id = 1;
            var mock = new Mock<IRoomService>();
            mock.Setup(a => a.Get(id)).Returns(new RoomDTO());

            RoomController controller = new RoomController(mock.Object);
            var result = controller.Get(new HttpRequestMessage(), 1);

            var expected = mapper.Map<RoomDTO, RoomModel>(mock.Object.Get(id));
            
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetAllRoomCategoriesTest()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GuestDTO, GuestModel>();
            }).CreateMapper();

            var mock = new Mock<IRoomService>();
            mock.Setup(a => a.GetAllRooms()).Returns(new List<RoomDTO>());

            RoomController controller = new RoomController(mock.Object);
            var result = controller.Get();

            var expected = mapper.Map<IEnumerable<RoomDTO>, List<RoomModel>>(mock.Object.GetAllRooms());

            Assert.AreEqual(expected.Count, result.Count());
        }
        [TestMethod]
        public void DeleteRoomTest()
        {
            int id = 1;
            var mock = new Mock<IRoomService>();
            mock.Setup(a => a.Delete(id));

            RoomController controller = new RoomController(mock.Object);
            var result = controller.Delete(new HttpRequestMessage(), id);

            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }
        [TestMethod]
        public void DeleteRoomNotNullTest()
        {
            int id = 1;
            var mock = new Mock<IRoomService>();
            mock.Setup(a => a.Delete(id));

            RoomController controller = new RoomController(mock.Object);
            var result = controller.Delete(new HttpRequestMessage(), id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void PostRoomNotNullTest()
        {
            Room room = new Room()
            {
                CategoryId = 2,
                RoomNumber = 106
            };

            var mock = new Mock<IRoomService>();
            mock.Setup(a => a.Post(room));

            RoomController controller = new RoomController(mock.Object);
            var result = controller.Post(new HttpRequestMessage(), room);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PutRoomNotNullTest()
        {
            int id = 1;

            Room room = new Room()
            {
                CategoryId = 2,
                RoomNumber = 106
            };

            var mock = new Mock<IRoomService>();
            mock.Setup(a => a.Put(id,room));

            RoomController controller = new RoomController(mock.Object);
            var result = controller.Put(new HttpRequestMessage(), id, room);

            Assert.IsNotNull(result);
        }
    }
}
