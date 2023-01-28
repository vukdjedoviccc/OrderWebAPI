using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPIFaza4.Request;

namespace OrderWebAPIFaza4.Controllers
{
    /// <summary>
    /// Kontroler koji služi za pozivanje operacija nad objektom "Person"
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        /// <summary>
        /// Properti interfejsa servisa osobe koji se inject-uje u konstruktoru servisa
        /// </summary>
        private readonly IPersonService _personService;
        /// <summary>
        /// Konstruktor sa parametrom servisa kompanije koji inicijalizuje ovaj servis
        /// </summary>
        /// <param name="personService"></param>
        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        /// <summary>
        /// Metoda koja služi za ažuriranje osobe u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestPerson"></param>
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

        /// <summary>
        /// Metoda koja služi za vraćanje liste svih osoba iz baze
        /// </summary>
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Person>>> GetAll()
        {
            return await _personService.GetAll();
        }

        /// <summary>
        /// Metoda koja služi za vraćanje konkretne osobe iz baze na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
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

        /// <summary>
        /// Metoda koja služi za brisanje konkretne osobe iz baze na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _personService.Delete(id);
        }

        /// <summary>
        /// Metoda koja služi za dodavanje nove osobe u bazu
        /// </summary>
        /// <param name="requestPerson"></param>
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
