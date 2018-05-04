using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkpoint06.Domain;
using Checkpoint06.Domain.Interfaces;
using Checkpoint06.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Checkpoint06.Api
{
    [Route("api/bird")]
    public class BirdController : Controller
    {
        private readonly IBirdRepository _birdRepository = new BirdRepository();

        [HttpPost("AddObservation")]
        public IActionResult AddObservation(Observation bird)
        {
            try
            {
                _birdRepository.AddObservation(bird);
                return Ok($"Lade till fågel med Id={bird.Id}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("GetAllSpecies")]
        public IActionResult GetAllSpecies()
        {
            try
            {
                List<string> allSpecies = _birdRepository.GetAllSpecies();
                return  Ok(string.Join("<br>",allSpecies));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpGet("GetAllObservations")]
        public IActionResult GetAllObservations()
        {
            try
            {
                List<Observation> allObservations = _birdRepository.GetAllObservations();
                return Json(allObservations);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
