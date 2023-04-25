using Microsoft.AspNetCore.Mvc;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Request;

namespace OrderWebAPI.Controllers;

/// <summary>
///     Kontroler koji služi za pozivanje operacija nad objektom "Person"
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class PersonController : ControllerBase
{
    /// <summary>
    ///     Properti interfejsa servisa osobe koji se inject-uje u konstruktoru servisa
    /// </summary>
    private readonly IPersonService _personService;

    /// <summary>
    ///     Konstruktor sa parametrom servisa kompanije koji inicijalizuje ovaj servis
    /// </summary>
    /// <param name="personService"></param>
    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }

    /// <summary>
    ///     Metoda koja služi za ažuriranje osobe u bazi
    /// </summary>
    /// <param name="id"></param>
    /// <param name="requestPerson"></param>
    [HttpPut("{id}")]
    public async Task Put(int? id, CreatePersonRequest requestPerson)
    {
        if (id <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        if (string.IsNullOrEmpty(requestPerson.FirstName))
            throw new ArgumentException("FirstName ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestPerson.LastName))
            throw new ArgumentException("LastName ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestPerson.Email))
            throw new ArgumentException("Email ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestPerson.Adress))
            throw new ArgumentException("Address ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestPerson.PhoneNumber))
            throw new ArgumentException("PhoneNumber ne može biti null ili prazan string!");
        var person = await _personService.GetById(id);
        if (person == null) throw new NullReferenceException($"Objekat sa Id-jem {id} se ne nalazi u bazi!");
        person.FirstName = requestPerson.FirstName;
        person.LastName = requestPerson.LastName;
        person.Email = requestPerson.Email;
        person.Adress = requestPerson.Adress;
        await _personService.Update(id, requestPerson.FirstName, requestPerson.LastName, requestPerson.Email,
            requestPerson.Adress, requestPerson.PhoneNumber);
    }

    /// <summary>
    ///     Metoda koja služi za vraćanje liste svih osoba iz baze
    /// </summary>
    [HttpGet("getAll")]
    public async Task<ActionResult<List<Person>>> GetAll()
    {
        var persons = await _personService.GetAll();
        if (persons is null) throw new NullReferenceException("U bazi se ne nalazi ni jedan objekat osobe!");
        return persons;
    }

    /// <summary>
    ///     Metoda koja služi za vraćanje konkretne osobe iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    public async Task<ActionResult<Person>> GetById(int? id)
    {
        if (id <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        var person = await _personService.GetById(id);
        if (person == null) throw new NullReferenceException($"Objekat sa Id-jem {id} se ne nalazi u bazi!");
        return person;
    }

    /// <summary>
    ///     Metoda koja služi za brisanje konkretne osobe iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task Delete(int? id)
    {
        if (id <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        await _personService.Delete(id);
    }

    /// <summary>
    ///     Metoda koja služi za dodavanje nove osobe u bazu
    /// </summary>
    /// <param name="requestPerson"></param>
    [HttpPost]
    public async Task Post(CreatePersonRequest requestPerson)
    {
        if (string.IsNullOrEmpty(requestPerson.FirstName))
            throw new ArgumentException("FirstName ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestPerson.LastName))
            throw new ArgumentException("LastName ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestPerson.Adress))
            throw new ArgumentException("Address ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestPerson.Email))
            throw new ArgumentException("Email ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestPerson.PhoneNumber))
            throw new ArgumentException("PhoneNumber ne može biti null ili prazan string!");
        var person = new Person();
        person.FirstName = requestPerson.FirstName;
        person.LastName = requestPerson.LastName;
        person.Email = requestPerson.Email;
        person.Adress = requestPerson.Adress;
        person.PhoneNumber = requestPerson.PhoneNumber;
        await _personService.Add(person.FirstName, person.LastName, person.Email, person.Adress, person.PhoneNumber);
    }
}