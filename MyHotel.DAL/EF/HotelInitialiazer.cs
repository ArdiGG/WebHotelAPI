using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyHotel.DAL.Entities;

namespace MyHotel.DAL.EF
{
    public class MyHotelInitializer : DropCreateDatabaseAlways<Hotel>
    {
        private void RoomInitializer(Hotel context)
        {
            List<Room> roomList = new List<Room>
            {
                new Room()
                {
                    CategoryId = 1,
                    RoomNumber = 505,
                },
                new Room()
                {
                    CategoryId = 2,
                    RoomNumber = 805,
                },
                new Room()
                {
                    CategoryId = 3,
                    RoomNumber = 102,
                },
                new Room()
                {
                    CategoryId = 4,
                    RoomNumber = 702,
                },
            };

            foreach (var room in roomList)
            {
                context.Rooms.Add(room);
            }
            context.SaveChanges();
        }

        private void RoomCategoryInitializer(Hotel context)
        {
            List<RoomCategory> roomList = new List<RoomCategory>
            {
                new RoomCategory()
                {
                    Name = "Standart",
                    Bed = 2,
                    Price = 200,
                },
                new RoomCategory()
                {
                    Name = "Econom",
                    Bed = 1,
                    Price = 100,
                },
                new RoomCategory()
                {
                    Name = "Lux",
                    Bed = 3,
                    Price = 500,
                },
                new RoomCategory()
                {
                    Name = "President",
                    Bed = 4,
                    Price = 1000,
                }
            };

            foreach (var roomCategory in roomList)
            {
                context.RoomCategories.Add(roomCategory);
            }
            context.SaveChanges();
        }
        private void GuestInitializer(Hotel context)
        {
            var guestList = new List<Guest>
            {
                new Guest()
                {
                    PassportId = 0005423535,
                    FullName = "Kryzhanivskiy Arkadiy Sergeevich",
                    Address = "prov. Electroinstrumentalniy",
                    Birthday = new DateTime(2002,03,05),
                },
                new Guest()
                {
                    PassportId = 0005847345,
                    FullName = "Denisenko Ivan Sergeevich",
                    Address = "prov. Electroinstrumentalniy",
                    Birthday = new DateTime(2001,10,13),

                }
            };

            foreach (var guest in guestList)
            {
                context.Guests.Add(guest);
            }

            context.SaveChanges();
        }

        private void BookingInitializer(Hotel context)
        {
            var bookingList = new List<Booking>
            {
                new Booking()
                {
                    GuestId = 1,
                    RoomId = 1,
                    BookingDate = new DateTime(2022,04,29),
                    ArriveDate = new DateTime(2021,06,26),
                    DepartureDate = new DateTime(2021,07,03),
                    Set = true
                },
                new Booking()
                {
                    GuestId = 1,
                    RoomId = 2,
                    BookingDate = new DateTime(2022,05,01),
                    ArriveDate = new DateTime(2022,05,03),
                    DepartureDate = new DateTime(2022,06,21),
                    Set = false
                }
            };
            List<DateTime?[]> listDates = new List<DateTime?[]>();
            foreach (var booking in bookingList)
            {
                context.Bookings.Add(booking);
            }

            context.SaveChanges();
        }
        protected override void Seed(Hotel context)
        {
            RoomCategoryInitializer(context);
            RoomInitializer(context);
            GuestInitializer(context);
            BookingInitializer(context);
        }
    }
}
