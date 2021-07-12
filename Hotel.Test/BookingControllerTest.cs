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
    public class BookingControllerTest
    {
        [TestMethod]
        public void GetMethodIsBookingModel()
        {
            int id = 1;
            var mock = new Mock<IBookingService>();
            mock.Setup(a => a.Get(id)).Returns(new BookingDTO());

            BookingController controller = new BookingController(mock.Object);
            var result = controller.Get(new HttpRequestMessage(), 1);

            Assert.IsInstanceOfType(result, typeof(BookingModel));
        }

        [TestMethod]
        public void GetMethodTest()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookingDTO, BookingModel>();
            }).CreateMapper();

            int id = 1;
            var mock = new Mock<IBookingService>();
            mock.Setup(a => a.Get(id)).Returns(new BookingDTO());

            BookingController controller = new BookingController(mock.Object);
            var result = controller.Get(new HttpRequestMessage(), 1);

            var expected = mapper.Map<BookingDTO, BookingModel>(mock.Object.Get(id));

            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void GetAllRoomCategoriesTest()
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<BookingDTO, BookingModel>();
            }).CreateMapper();

            var mock = new Mock<IBookingService>();
            mock.Setup(a => a.GetAllBookings()).Returns(new List<BookingDTO>());

            BookingController controller = new BookingController(mock.Object);
            var result = controller.GetAllBookings();

            var expected = mapper.Map<IEnumerable<BookingDTO>, List<BookingModel>>(mock.Object.GetAllBookings());

            Assert.AreEqual(expected.Count, result.Count());
        }
        [TestMethod]
        public void DeleteBookingTest()
        {
            int id = 1;
            var mock = new Mock<IBookingService>();
            mock.Setup(a => a.Delete(id));

            BookingController controller = new BookingController(mock.Object);
            var result = controller.Delete(new HttpRequestMessage(), id);
            
            Assert.AreEqual(result.StatusCode, HttpStatusCode.OK);
        }
        [TestMethod]
        public void DeleteBookingNotNullTest()
        {
            int id = 1;
            var mock = new Mock<IBookingService>();
            mock.Setup(a => a.Delete(id));

            BookingController controller = new BookingController(mock.Object);
            var result = controller.Delete(new HttpRequestMessage(), id);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void PostBookingNotNullTest()
        {
            Booking booking = new Booking()
            {
                Set = true,
                ArriveDate = new DateTime(2002, 04, 04),
                BookingDate = new DateTime(2005, 04, 02),
            };

            var mock = new Mock<IBookingService>();
            mock.Setup(a => a.Post(booking));


            BookingController controller = new BookingController(mock.Object);
            var result = controller.Post(new HttpRequestMessage(), booking);

            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void PutBookingNotNullTest()
        {
            int id = 1;

            Booking booking = new Booking()
            {
                Set = true,
                ArriveDate = new DateTime(2002, 04, 04),
                BookingDate = new DateTime(2005, 04, 02),
            };

            var mock = new Mock<IBookingService>();
            mock.Setup(a => a.Put(id,booking));


            BookingController controller = new BookingController(mock.Object);
            var result = controller.Put(new HttpRequestMessage(),id, booking);

            Assert.IsNotNull(result);
        }
    }
}
