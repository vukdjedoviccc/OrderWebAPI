using Order.Domain.DomainValidations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.Model
{
    /// <summary>
    /// Klasa domena koja se odnosi na osobe
    /// </summary>
    public class Person : Customer
    {
        private string _firstName;
        private string _lastName;

        /// <summary>
        /// Bezparametarski konstruktor klase Person 
        /// </summary>
        public Person() : base() 
        {

        }

        /// <summary>
        /// Parametarski konstruktor klase Person 
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="adress"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="email"></param>
        /// <param name="id"></param>
        public Person(string firstName, string lastName, string adress, string phoneNumber, string email, int id) : base(adress, phoneNumber, email, id)
        {
            FirstName = firstName;
            LastName = lastName;
        }



        /// <summary>
        /// Ime osobe
        /// </summary>
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
        /// <summary>
        /// Prezime osobe
        /// </summary>
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
