using Order.Domain.Interfaces;
using Order.Domain.Model;

namespace Order.Domain.Services;

/// <summary>
///     Klasa koja predstavlja servis za pozivanje metoda nad repozitorijumom kompanije kako bi se pristupilo bazi
/// </summary>
public class CompanyService : ICompanyService
{
    /// <summary>
    ///     Properti interfejsa repozitorijuma kompanije koji se inject-uje u konstruktoru servisa
    /// </summary>
    private readonly ICompanyRepository _companyRepository;

    /// <summary>
    ///     Konstruktor sa parametrom repozitorijuma kompanije koji inicijalizuje ovaj repozitorijum
    /// </summary>
    /// <param name="companyRepository"></param>
    public CompanyService(ICompanyRepository companyRepository)
    {
        _companyRepository = companyRepository;
    }

    public async Task Add(string fullName, string registrationNumber, string address, string phoneNumber, string email)
    {
        await _companyRepository.Add(fullName, registrationNumber, address, phoneNumber, email);
        await _companyRepository.SaveChanges();
    }

    public async Task Delete(int? id)
    {
        await _companyRepository.Delete(id);
        await _companyRepository.SaveChanges();
    }

    public async Task<List<Company>> GetAll()
    {
        return await _companyRepository.GetAll();
    }

    public async Task<Company> GetById(int? id)
    {
        return await _companyRepository.GetById(id);
    }

    public async Task Update(int? id, string address, string fullName, string email, string phoneNumber,
        string registrationNumber)
    {
        await _companyRepository.Update(id, address, fullName, email, phoneNumber, registrationNumber);
        await _companyRepository.SaveChanges();
    }
}