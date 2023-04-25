using Microsoft.EntityFrameworkCore;
using Order.Domain.Interfaces;
using Order.Domain.Model;
using Order.Persistance;
using Order.Persistance.Model;

namespace Order.Repositories;

/// <summary>
///     Klasa koja predstavlja repozitorijum osobe za pozivanje odgovarajućih metoda koje rade direktno nad bazom
/// </summary>
public class PersonRepository : IPersonRepository
{
    // <summary>
    /// Properti datacontext-a zaduženog za rad sa bazom
    /// </summary>
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    ///     Konstruktor sa parametrom datacontext-a(omogućava direktan pristup tabelama u bazi) koji ga inicijalizuje
    /// </summary>
    /// <param name="databaseContext"></param>
    public PersonRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task SaveChanges()
    {
        await _databaseContext.SaveChangesAsync();
    }

    public async Task Add(string firstName, string lastName, string email, string adress, string phoneNumber)
    {
        var record = new PersonRecord
        {
            FirstName = firstName,
            LastName = lastName,
            Adress = adress,
            Email = email,
            PhoneNumber = phoneNumber
        };

        await _databaseContext.Persons.AddAsync(record);
    }

    public async Task Delete(int? id)
    {
        var record = await _databaseContext.Persons.Where(r => r.Id == id).FirstOrDefaultAsync();
        if (record != null)
            _databaseContext.Persons.Remove(record);
    }

    public async Task<List<Person>> GetAll()
    {
        var records = await _databaseContext.Persons.AsNoTracking().ToListAsync();
        if (records.Count == 0) return null;
        var persons = records.Select(x => new Person
        {
            Id = x.Id,
            FirstName = x.FirstName,
            LastName = x.LastName,
            PhoneNumber = x.PhoneNumber,
            Email = x.Email,
            Adress = x.Adress
        }).ToList();
        return persons;
    }

    public async Task<Person> GetById(int? id)
    {
        var record = await _databaseContext.Persons.Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();
        if (record is null) return null;
        var person = new Person
        {
            Id = record.Id,
            Adress = record.Adress,
            FirstName = record.FirstName,
            Email = record.Email,
            PhoneNumber = record.PhoneNumber,
            LastName = record.LastName
        };
        return person;
    }

    public async Task Update(int? id, string firstName, string lastName, string email, string adress,
        string phoneNumber)
    {
        var record = new PersonRecord
        {
            Id = id,
            FirstName = firstName,
            LastName = lastName,
            Adress = adress,
            Email = email,
            PhoneNumber = phoneNumber
        };
        _databaseContext.Persons.Update(record);
    }
}