using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Services
{
    
    public interface IPersonService
    {
        
        Task Add(Person person);
        
        Task<Person> GetById(int id);
        
        Task<List<Person>> GetAll();
       
        Task Delete(int id);
        
        Task Update(Person person);
    }
}
