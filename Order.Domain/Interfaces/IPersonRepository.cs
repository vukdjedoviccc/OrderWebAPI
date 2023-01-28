using Order.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Interfaces
{
    
    public interface IPersonRepository
    {
        
        Task SaveChanges();
       
        Task Add(Person person);
        
        Task Delete(int id);
       
        Task<List<Person>> GetAll();
        
        Task<Person> GetById(int id);
        
        Task Update(Person person);
    }
}
