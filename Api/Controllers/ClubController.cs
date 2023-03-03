using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;

        public ClubController(IClubService clubService) =>
            _clubService = clubService;

        [HttpGet]
        public async Task<IActionResult> RecoverAll()
        {
            var clubs = await _clubService.RecoverAllClubs();
            if (clubs == null)
            {
                return NotFound();
            }
            return Ok(clubs);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetClubById(int id)
        {
            var club = await _clubService.GetClubById(id);
            if (club == null) {
                return NotFound();
            }
            return Ok(club);
        }

        [HttpPost]
        public async Task<IActionResult> Register(Club club)
        {
            var id = await _clubService.RegisterAClub(club);

            return Ok(id);
        }
    }
}
