using Domain.Adapters;
using Domain.Entities;
using Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ClubServiceManager : IClubService
    {
        //private readonly IEmailAdapter _emailAdapter;
        private readonly IClubRepository _clubRepository;

        //public ClubServiceManager(IEmailAdapter emailAdapter, IClubRepository clubRepository) =>
        //    (_emailAdapter, _clubRepository) = (emailAdapter, clubRepository);
        public ClubServiceManager(IClubRepository clubRepository) => _clubRepository = clubRepository;

        public async Task<IEnumerable<Club>> RecoverAllClubs()
        {
            return await ApplyBusinessRule();
        }

        public async Task<Club> GetClubById(int id) 
        {
            return await ApplyBusinessRule(id);
        }

        private async Task<Club> ApplyBusinessRule(int id) 
        {
            var club = await _clubRepository.GetClubById(id);
            club = ApplyRule(club);
            return await Task.FromResult(club);
        }

        private async Task<IEnumerable<Club>> ApplyBusinessRule()
        {
            var clubs = await _clubRepository.GetAll();
            clubs.ToList().ForEach(club => {
                club = ApplyRule(club);
            });

            return clubs;
        }

        private Club ApplyRule(Club club) 
        {
            switch (club?.Id)
            {
                case 1:
                    club.Name = $"Aqui é {club.Name}, mano!";
                    break;
                case 2:
                    club.Name = $"Aqui é {club.Name}, meu!";
                    break;
                default:
                    Console.WriteLine();
                    break;

            }
            return club;
        }

        public async Task<int> RegisterAClub(Club club)
        {
            var id = await _clubRepository.Insert(club);

            //_ = _emailAdapter.SendEmail("", "", "", "");

            return id;
        }
    }
}
