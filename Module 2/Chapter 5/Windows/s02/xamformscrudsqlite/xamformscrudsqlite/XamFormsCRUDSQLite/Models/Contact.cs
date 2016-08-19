using SQLite.Net.Attributes;
using System;

namespace XamFormsCRUDSQLite.Models
{
    public class Contact
    {
        [PrimaryKey]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
