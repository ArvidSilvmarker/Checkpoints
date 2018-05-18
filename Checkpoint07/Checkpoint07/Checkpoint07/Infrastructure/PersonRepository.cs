using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Checkpoint07.Domain;
using Checkpoint07.Domain.Interfaces;

namespace Checkpoint07.Infrastructure
{
    public class PersonRepository : IPersonRepository
    {
        private readonly NameContext _context;

        public PersonRepository(NameContext context)
        {
            _context = context;
        }

        public void CreatePerson(Person person)
        {
            _context.Persons.Add(person);
            _context.SaveChanges();
        }

        public List<Person> RealAllPersons()
        {
            return _context.Persons.ToList();
        }

        public void DeletePerson(int id)
        {
            var personToRemove = _context.Persons.First(p => p.Id == id);
            _context.Remove(personToRemove);
            _context.SaveChanges();
        }
    }
}
