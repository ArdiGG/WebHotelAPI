using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using AutoMapper;
using MyHotel.BLL.Interfaces;
using MyHotelCF.APi.Controllers;
using NUnit.Framework.Internal;
using Moq;
using MyHotel.BLL.DTO;
using MyHotel.DAL.Entities;
using MyHotel.DAL.Interfaces;
using MyHotelCF.APi.Models;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Hotel.Test
{
    [TestClass]
    public class GuestControllerTest
    {
        [TestMethod]
        public void GetMethodIsGuestModel()
        {
            int id = 1;
            var mock = new Mock<IGuestService>();
            mock.Setup(a => a.Get(id)).Returns(new GuestDTO());

            GuestController controller = new GuestController(mock.Object);
            var result = controller.Get(new HttpRequestMessage(), 1);

            Assert.IsInstanceOfType(result,typeof(GuestModel));
        }

        [TestMethod]
        public void GetMethodTest()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GuestDTO, GuestModel>();
            }).CreateMapper();

            int id = 1;
            var mock = new Mock<IGuestService>();
            mock.Setup(a => a.Get(id)).Returns(new GuestDTO());

            GuestController controller = new GuestController(mock.Object);
            var result = controller.Get(new HttpRequestMessage(),1);

            var expected = mapper.Map<GuestDTO,GuestModel>( mock.Object.Get(id));

            Assert.AreEqual(expected,result);
        }

        [TestMethod]
        public void GetAllGuestTest()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GuestDTO, GuestModel>();
            }).CreateMapper();

            var mock = new Mock<IGuestService>();
            mock.Setup(a => a.GetAllGuests()).Returns(new List<GuestDTO>());

            GuestController controller = new GuestController(mock.Object);
            var result = controller.GetAllGuests();

            var expected = mapper.Map<IEnumerable<GuestDTO>, List<GuestModel>>(mock.Object.GetAllGuests());

            Assert.AreEqual(expected.Count, result.Count());
        }
        [TestMethod]
        public void DeleteGuestTest()
        {
            int id = 1;
            var mock = new Mock<IGuestService>();
            mock.Setup(a => a.Delete(id));

            GuestController controller = new GuestController(mock.Object);
            var result = controller.Delete(new HttpRequestMessage(),id);

            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }
        [TestMethod]
        public void DeleteGuestNotNullTest()
        {
            int id = 1;
            var mock = new Mock<IGuestService>();
            mock.Setup(a => a.Delete(id));

            GuestController controller = new GuestController(mock.Object);
            var result = controller.Delete(new HttpRequestMessage(), id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void PostGuestNotNullTest()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GuestModel, GuestDTO>();
            }).CreateMapper();

            GuestModel guest = new GuestModel()
            {
                FullName = "Movchan Vladislav Ivanovich",
                Address = "prov. Electro 6-B",
                Birthday = new DateTime(2002, 01, 28),
                PassportId = 0004827534
            };

            var mock = new Mock<IGuestService>();
            mock.Setup(a => a.Post(mapper.Map<GuestModel,GuestDTO>(guest)));


            GuestController controller = new GuestController(mock.Object);
            var result = controller.Post(new HttpRequestMessage(), guest);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void PutGuestNotNullTest()
        {
            int id = 1;
            Guest guest = new Guest()
            {
                FullName = "Movchan Vladislav Ivanovich",
                Address = "prov. Electro 6-B",
                Birthday = new DateTime(2002, 01, 28),
                PassportId = 0004827534
            };

            var mock = new Mock<IGuestService>();
            mock.Setup(a => a.Put(id,guest));


            GuestController controller = new GuestController(mock.Object);
            var result = controller.Put(new HttpRequestMessage(), id,guest);

            Assert.IsNotNull(result);
        }
    }
}
