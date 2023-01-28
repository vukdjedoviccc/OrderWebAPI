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
    
    [Route("api/[controller]")]
        [ApiController]
        public class CompanyController : ControllerBase
        {
        
        private readonly ICompanyService _companyService;

        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }

        
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

       
        [HttpGet("getAll")]
        public async Task<ActionResult<List<Company>>> GetAll()
        {
            return await _companyService.GetAll();
        }

       
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

        
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _companyService.Delete(id);
        }

       
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
