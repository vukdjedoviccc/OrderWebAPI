using Microsoft.EntityFrameworkCore;
using Order.Domain.Interfaces;
using Order.Domain.Model;
using Order.Persistance;
using Order.Persistance.Model;

namespace Order.Repositories;

public class CompanyRepository : ICompanyRepository
{
    // <summary>
    /// Properti datacontext-a zaduženog za rad sa bazom
    /// </summary>
    private readonly DatabaseContext _databaseContext;

    /// <summary>
    ///     Konstruktor sa parametrom datacontext-a(omogućava direktan pristup tabelama u bazi) koji ga inicijalizuje
    /// </summary>
    /// <param name="databaseContext"></param>
    public CompanyRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public async Task SaveChanges()
    {
        await _databaseContext.SaveChangesAsync();
    }

    public async Task Add(string fullName, string registrationNumber, string adress, string phoneNumber, string email)
    {
        var record = new CompanyRecord
        {
            Adress = adress,
            Email = email,
            FullName = fullName,
            PhoneNumber = phoneNumber,
            RegistrationNumber = registrationNumber
        };
        await _databaseContext.Companies.AddAsync(record);
    }

    public async Task Delete(int? id)
    {
        var record = await _databaseContext.Companies.Where(r => r.Id == id).FirstOrDefaultAsync();
        if (record != null)
            _databaseContext.Companies.Remove(record);
    }

    public async Task<List<Company>> GetAll()
    {
        var records = await _databaseContext.Companies.AsNoTracking().ToListAsync();
        if (records.Count == 0) return null;
        var companies = records.Select(x => new Company
        {
            Id = x.Id,
            PhoneNumber = x.PhoneNumber,
            Email = x.Email,
            Adress = x.Adress,
            FullName = x.FullName,
            RegistrationNumber = x.RegistrationNumber
        }).ToList();
        return companies;
    }

    public async Task<Company> GetById(int? id)
    {
        var record = await _databaseContext.Companies.Where(p => p.Id == id).AsNoTracking().FirstOrDefaultAsync();
        if (record is null) return null;
        var company = new Company
        {
            Id = record.Id,
            Adress = record.Adress,
            Email = record.Email,
            PhoneNumber = record.PhoneNumber,
            RegistrationNumber = record.RegistrationNumber,
            FullName = record.FullName
        };
        return company;
    }

    public async Task Update(int? id, string address, string fullName, string email, string phoneNumber,
        string registrationNumber)
    {
        var record = new CompanyRecord
        {
            Id = id,
            Adress = address,
            Email = email,
            PhoneNumber = phoneNumber,
            FullName = fullName,
            RegistrationNumber = registrationNumber
        };
        _databaseContext.Companies.Update(record);
    }
}