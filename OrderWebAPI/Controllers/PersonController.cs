using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPIFaza4.Request;

namespace OrderWebAPIFaza4.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        
        private readonly IPersonService _personService;
        
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

       
        [HttpPut("{id}")]
        public async Task Put(int id, CreatePersonRequest requestPerson)
        {
            var person = await _personService.GetById(id);
            if (person != null)
            {
                person.FirstName = requestPerson.FirstName;
                person.LastName = requestPerson.LastName;   
                person.Email = requestPerson.Email;
                person.Adress = requestPerson.Adress;
                await _personService.Update(person);
            }
            else
            {
                throw new NullReferenceException($"Objekat sa id {id} se ne nalazi u bazi!");
            }

        }

        
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Person>>> GetAll()
        {
            return await _personService.GetAll();
        }

        
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetById(int id)
        {
            Person person = await _personService.GetById(id);
            if (person != null)
            {
                return person;
            }
            else
            {
                throw new NullReferenceException($"Objekat sa id {id} se ne nalazi u bazi!");
            }
            
        }

        
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _personService.Delete(id);
        }

        
        [HttpPost]
        public async Task Post(CreatePersonRequest requestPerson)
        {
            Person person = new Person();
            person.FirstName = requestPerson.FirstName;
            person.LastName = requestPerson.LastName;
            person.Email = requestPerson.Email;
            person.Adress = requestPerson.Adress;
            person.PhoneNumber = requestPerson.PhoneNumber;
            await _personService.Add(person);
        }

    }
}
