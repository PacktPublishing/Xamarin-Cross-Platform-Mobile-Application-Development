using System.Collections.Generic;
using XamFormsMVVM.Models;

namespace XamFormsMVVM.Data
{
    public static class DataService
    {
        public static IEnumerable<Contact> GetAll()
        {
            return new List<Contact>
            {
                new Contact()
                {
                    FirstName = "Chris",
                    LastName = "Smith",
                    Profession = "Computer Scientist"
                },
                new Contact()
                {
                    FirstName = "Georgios",
                    LastName = "Taskos",
                    Profession = "Software Engineer"
                }
            };
        }
    }
}
