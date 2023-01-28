using Order.Domain.Interfaces;
using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Services
{
    
    public class PersonService : IPersonService
    {
        
        private readonly IPersonRepository _personRepository;
       
        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }
        public async Task Add(Person person)
        {
            await _personRepository.Add(person); 
            await _personRepository.SaveChanges();
        }

        public async Task Delete(int id)
        {
            await _personRepository.Delete(id);
            await _personRepository.SaveChanges();
        }

        public async Task<List<Person>> GetAll()
        {
            return await _personRepository.GetAll();
        }

        public async Task<Person> GetById(int id)
        {
            return await _personRepository.GetById(id);
        }

        public async Task Update(Person person)
        {
            await _personRepository.Update(person);
            await _personRepository.SaveChanges();
        }
    }
}
