using System.Collections.Generic;

namespace GedcomParser.Entities
{
    public class Person
    {
        public string Id { get; set; }
        public List<string> Uids { get; set; }
        public List<Person> Children { get; set; }
        public List<Person> Parents { get; set; }
        public List<Person> Spouses { get; set; }
        public string IdNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DatePlace Birth { get; set; }
        public DatePlace Death { get; set; }
        public DatePlace Buried { get; set; }
        public DatePlace Baptized { get; set; }
        public string Education { get; set; }
        public string Religion { get; set; }
        public string Note { get; set; }
        public string Changed { get; set; }
        public string Occupation { get; set; }
        public string Health { get; set; }
        public string Title { get; set; }
        public Address Address { get; set; }
        public Adoption Adoption { get; set; }
        public DatePlace Residence { get; set; }
        public DatePlace Emigrated { get; set; }
        public DatePlace Immigrated { get; set; }
        public DatePlace BecomingCitizen { get; set; }
        public DatePlace Graduation { get; set; }
        public bool Matched { get; set; }
        public string MatchedId { get; set; }
    }
}