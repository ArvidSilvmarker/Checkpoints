using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Checkpoint07.Domain.Interfaces
{
    public interface IPersonRepository
    {
        void CreatePerson(Person person);
        List<Person> RealAllPersons();
        void DeletePerson(int id);
    }
}
