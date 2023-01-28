using Microsoft.AspNetCore.Mvc;
using Order.Domain.Model;
using Order.Domain.Request;
using Order.Domain.Services;
using OrderWebAPIFaza4.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Controllers
{
    /// <summary>
    /// Kontroler koji služi za pozivanje operacija nad objektom "Company"
    /// </summary>
    [Route("api/[controller]")]
        [ApiController]
        public class CompanyController : ControllerBase
        {
        /// <summary>
        /// Properti interfejsa servisa kompanije koji se inject-uje u konstruktoru servisa
        /// </summary>
        private readonly ICompanyService _companyService;

        /// <summary>
        /// Konstruktor sa parametrom servisa kompanije koji inicijalizuje ovaj servis
        /// </summary>
        /// <param name="companyService"></param>
        
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        /// <summary>
        /// Metoda koja služi za ažuriranje kompanije u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="requestCompany"></param>
        [HttpPut("{id}")]
        public async Task Put(int id, CreateCompanyRequest requestCompany)
        {
            var company = await _companyService.GetById(id);
            if (company != null)
            {
                company.Adress = requestCompany.Adress;
                company.PhoneNumber = requestCompany.PhoneNumber;
                company.RegistrationNumber = requestCompany.RegistrationNumber;
                company.Email = requestCompany.Email;
                company.FullName = requestCompany.FullName;
                await _companyService.Update(company);
            }
            else
            {
                throw new NullReferenceException($"Objekat sa id {id} se ne nalazi u bazi!");
            }

        }

        /// <summary>
        /// Metoda koja služi za vraćanje liste svih kompanija iz baze
        /// </summary>
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Company>>> GetAll()
        {
            return await _companyService.GetAll();
        }

        /// <summary>
        /// Metoda koja služi za vraćanje konkretne kompanije iz baze na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
        [HttpGet("{id}")]
        public async Task<ActionResult<Company>> GetById(int id)
        {
            Company company = await _companyService.GetById(id);
            if (company != null)
            {
                return company;
            }
            else
            {
                throw new NullReferenceException($"Objekat sa id {id} se ne nalazi u bazi!");
            }
        }

        /// <summary>
        /// Metoda koja služi za brisanje konkretne kompanije iz baze na osnovu njenog id-ja
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _companyService.Delete(id);
        }

        /// <summary>
        /// Metoda koja služi za dodavanje nove kompanije u bazu
        /// </summary>
        /// <param name="requestCompany"></param>
        [HttpPost]
        public async Task Post(CreateCompanyRequest requestCompany)
        {
            Company company = new Company();
            company.FullName = requestCompany.FullName;
            company.RegistrationNumber = requestCompany.RegistrationNumber;
            company.Adress = requestCompany.Adress;
            company.PhoneNumber = requestCompany.PhoneNumber;
            company.Email = requestCompany.Email;
            await _companyService.Add(company);
        }

    }
}
