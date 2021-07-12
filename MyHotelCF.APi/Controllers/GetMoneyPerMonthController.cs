using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyHotel.BLL.Interfaces;

namespace MyHotelCF.APi.Controllers
{
    public class GetMoneyPerMonthController : ApiController
    {
        private IBookingService service;

        public GetMoneyPerMonthController(IBookingService service)
        {
            this.service = service;
        }
        // GET: api/GetMoneyPerMonth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GetMoneyPerMonth/5
        public string Get(int id)
        {
            float sum = 0;
            foreach (var booking in service.GetAllBookings())
            {
                float price = booking.BookingRoom.Category.Price;
                
                DateTime? start = booking.ArriveDate.Value;
                DateTime? end = booking.DepartureDate.Value;
                if (start.Value.Month == id)
                {
                    for (; start.Value.Month == id && (start.Value <= end.Value); start = start.Value.AddDays(1))
                    {
                        sum += price;

                    }
                }
                else
                {
                    int i = 1;
                    for (; end.Value.Month == id && (i <= end.Value.Day); i++)
                    {
                        sum += price;
                    }
                }
            }


            return sum+"";
        }

        // POST: api/GetMoneyPerMonth
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GetMoneyPerMonth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GetMoneyPerMonth/5
        public void Delete(int id)
        {
        }
    }
}
