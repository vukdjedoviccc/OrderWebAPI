using Order.Domain.DomainValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Model
{
    
    public class Person : Customer
    {
        private string _firstName;
        private string _lastName;

        
        public Person() : base() 
        {

        }

        
        public Person(string firstName, string lastName, string adress, string phoneNumber, string email, int id) : base(adress, phoneNumber, email, id)
        {
            FirstName = firstName;
            LastName = lastName;
        }



        
        public string FirstName 
        {
            get
            {
                return _firstName;
            }
            set
            {
                Validations.NotNullOrEmpty(value);
                Validations.StringLengthLessThanOrEqualTo(value, 15);
                _firstName = value;
            }
        }
        
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                Validations.NotNullOrEmpty(value);
                Validations.StringLengthLessThanOrEqualTo(value, 20);
                _lastName = value;
            }
        }
    }
}
