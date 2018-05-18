using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkpoint07.Domain;
using Checkpoint07.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Checkpoint07.Controllers
{
    [Route("api/person")]
    public class NameController : Controller
    {
        private readonly IPersonRepository _personRepository;

        public NameController(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        [HttpGet]
        public IActionResult GetAllPersons()
        {
            var persons = _personRepository.RealAllPersons();
            var personsString = "";
            foreach (var person in persons)
            {
                personsString += person.PersonToString() + "<br>";
            }
            return Ok(personsString);
        }

        [HttpPost]
        public IActionResult NewPerson()
        {
            _personRepository.CreatePerson(new Person());
            return Ok("New person");
        }

        [HttpDelete]
        public IActionResult Delete(Person person)
        {
            _personRepository.DeletePerson(person.Id);
            return Ok("Delete person");
        }
    }
}
