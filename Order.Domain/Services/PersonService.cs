using Order.Domain.Interfaces;
using Order.Domain.Model;

namespace Order.Domain.Services;

/// <summary>
///     Klasa koja predstavlja servis za pozivanje metoda nad repozitorijumom osobe kako bi se pristupilo bazi
/// </summary>
public class PersonService : IPersonService
{
    // <summary>
    /// Properti interfejsa repozitorijuma osobe koji se inject-uje u konstruktoru servisa
    /// </summary>
    private readonly IPersonRepository _personRepository;

    /// <summary>
    ///     Konstruktor sa parametrom repozitorijuma osobe koji inicijalizuje ovaj repozitorijum
    /// </summary>
    /// <param name="personRepository"></param>
    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public async Task Add(string firstName, string lastName, string email, string adress, string phoneNumber)
    {
        await _personRepository.Add(firstName, lastName, email, adress, phoneNumber);
        await _personRepository.SaveChanges();
    }

    public async Task Delete(int? id)
    {
        await _personRepository.Delete(id);
        await _personRepository.SaveChanges();
    }

    public async Task<List<Person>> GetAll()
    {
        return await _personRepository.GetAll();
    }

    public async Task Update(int? id, string firstName, string lastName, string email, string adress,
        string phoneNumber)
    {
        await _personRepository.Update(id, firstName, lastName, email, adress, phoneNumber);
        await _personRepository.SaveChanges();
    }

    public async Task<Person> GetById(int? id)
    {
        return await _personRepository.GetById(id);
    }
}