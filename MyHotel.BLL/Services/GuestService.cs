using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MyHotel.BLL.DTO;
using MyHotel.BLL.Interfaces;
using MyHotel.DAL.Entities;
using MyHotel.DAL.Interfaces;

namespace MyHotel.BLL.Services
{
    public class GuestService : IGuestService
    {
        private IWorkUnit Datebase { get; set; }

        public GuestService(IWorkUnit datebase)
        {
            this.Datebase = datebase;
        }

        public void Post(GuestDTO newGuest)
        {
            var mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GuestDTO, Guest>();
            }).CreateMapper();
            Datebase.Guests.Add(mapper.Map<GuestDTO,Guest>(newGuest));
        }

        public void Put(int id, Guest guest)
        {
            Datebase.Guests.Put(id, guest);
        }
        public IEnumerable<GuestDTO> GetAllGuests()
        {
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<Guest, GuestDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Guest>, List<GuestDTO>>(Datebase.Guests.GetAll()); 
        }
        public void Delete(int id)
        {
            Datebase.Guests.Delete(id);
        }
        public GuestDTO Get(int id)
        {
            var student = Datebase.Guests.Get(id);
            var mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<Guest, GuestDTO>()).CreateMapper();

            return mapper.Map<Guest, GuestDTO>(student);
        }
    }
}
