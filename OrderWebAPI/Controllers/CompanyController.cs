using Microsoft.AspNetCore.Mvc;
using Order.Domain.Model;
using Order.Domain.Services;
using OrderWebAPI.Request;

namespace OrderWebAPI.Controllers;

/// <summary>
///     Kontroler koji služi za pozivanje operacija nad objektom "Company"
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class CompanyController : ControllerBase
{
    /// <summary>
    ///     Properti interfejsa servisa kompanije koji se inject-uje u konstruktoru servisa
    /// </summary>
    private readonly ICompanyService _companyService;

    /// <summary>
    ///     Konstruktor sa parametrom servisa kompanije koji inicijalizuje ovaj servis
    /// </summary>
    /// <param name="companyService"></param>
    public CompanyController(ICompanyService companyService)
    {
        _companyService = companyService;
    }

    /// <summary>
    ///     Metoda koja služi za ažuriranje kompanije u bazi
    /// </summary>
    /// <param name="id"></param>
    /// <param name="requestCompany"></param>
    [HttpPut("{id}")]
    public async Task Put(int? id, CreateCompanyRequest requestCompany)
    {
        if (id <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        if (string.IsNullOrEmpty(requestCompany.Adress))
            throw new ArgumentException("Address ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestCompany.FullName))
            throw new ArgumentException("FullName ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestCompany.PhoneNumber))
            throw new ArgumentException("PhoneNumber ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestCompany.Email))
            throw new ArgumentException("Email ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestCompany.RegistrationNumber))
            throw new ArgumentException("RegistrationNumber ne može biti null ili prazan string!");
        var company = await _companyService.GetById(id);
        if (company is null) throw new NullReferenceException($"Objekat sa Id-jem {id} se ne nalazi u bazi!");
        company.Adress = requestCompany.Adress;
        company.PhoneNumber = requestCompany.PhoneNumber;
        company.RegistrationNumber = requestCompany.RegistrationNumber;
        company.Email = requestCompany.Email;
        company.FullName = requestCompany.FullName;
        await _companyService.Update(id, requestCompany.Adress, requestCompany.FullName, requestCompany.Email,
            requestCompany.PhoneNumber, requestCompany.RegistrationNumber);
    }

    /// <summary>
    ///     Metoda koja služi za vraćanje liste svih kompanija iz baze
    /// </summary>
    [HttpGet("getAll")]
    public async Task<ActionResult<List<Company>>> GetAll()
    {
        var companies = await _companyService.GetAll();
        if (companies is null) throw new NullReferenceException("U bazi se ne nalazi ni jedan objekat kompanije!");
        return companies;
    }

    /// <summary>
    ///     Metoda koja služi za vraćanje konkretne kompanije iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    [HttpGet("{id}")]
    public async Task<ActionResult<Company>> GetById(int id)
    {
        if (id <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        var company = await _companyService.GetById(id);
        if (company is null) throw new NullReferenceException($"Objekat sa Id-jem {id} se ne nalazi u bazi!");
        return company;
    }

    /// <summary>
    ///     Metoda koja služi za brisanje konkretne kompanije iz baze na osnovu njenog id-ja
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        if (id <= 0) throw new ArgumentException("Id ne može biti negativan broj ili jednak nuli!");
        await _companyService.Delete(id);
    }

    /// <summary>
    ///     Metoda koja služi za dodavanje nove kompanije u bazu
    /// </summary>
    /// <param name="requestCompany"></param>
    [HttpPost]
    public async Task Post(CreateCompanyRequest requestCompany)
    {
        if (string.IsNullOrEmpty(requestCompany.FullName))
            throw new ArgumentException("FullName ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestCompany.RegistrationNumber))
            throw new ArgumentException("RegistrationNumber ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestCompany.Adress))
            throw new ArgumentException("Address ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestCompany.PhoneNumber))
            throw new ArgumentException("PhoneNumber ne može biti null ili prazan string!");
        if (string.IsNullOrEmpty(requestCompany.Email))
            throw new ArgumentException("Email ne može biti null ili prazan string!");
        var company = new Company();
        company.FullName = requestCompany.FullName;
        company.RegistrationNumber = requestCompany.RegistrationNumber;
        company.Adress = requestCompany.Adress;
        company.PhoneNumber = requestCompany.PhoneNumber;
        company.Email = requestCompany.Email;
        await _companyService.Add(company.FullName, company.RegistrationNumber, company.Adress, company.PhoneNumber,
            company.Email);
    }
}