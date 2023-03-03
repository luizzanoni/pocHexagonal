using Domain.Adapters;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.DataBase.InMemory.Repositories
{
    public class ClubRepository : IClubRepository
    {
        public Task<IEnumerable<Club>> GetAll()
        {
            var curintcha = new Club
            {
                Id= 1,
                Name= "Curintcha"
            };
            var parmeira = new Club
            {
                Id = 2,
                Name = "Parmeira"
            };
            var clubList = new List<Club> {
                curintcha,
                parmeira
            };
            return Task.FromResult(clubList.AsEnumerable());
        }

        public Task<Club> GetClubById(int id)
        {
            var clubs = GetAll();
            var clubRes = clubs.GetAwaiter().GetResult();
            var clubList = clubRes.ToList();
            var club = clubList.Find(c => c.Id == id);
            return Task.FromResult(club);
        }

        public Task<int> Insert(Club club)
        {
            throw new NotImplementedException();
        }
    }
}
