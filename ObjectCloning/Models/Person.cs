using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ProtoBuf;

namespace ObjectCloning.Models
{
    [Serializable]
    [ProtoContract]
    public class Person
    {
        [ProtoMember(1)]
        public int Id { get; set; }
        
        [ProtoMember(2)]
        public string FirstName { get; set; }
        
        [ProtoMember(3)]
        public string LastName { get; set; }
        
        [ProtoMember(4)]
        public DateTime DateOfBirth { get; set; }
        
        [ProtoMember(5)]
        public Address HomeAddress { get; set; }
        
        [ProtoMember(6)]
        public Address WorkAddress { get; set; }
        
        [ProtoMember(7)]
        public List<Contact> Contacts { get; set; }
        
        [ProtoMember(8)]
        public Dictionary<string, string> Attributes { get; set; }

        public Person()
        {
            Contacts = new List<Contact>();
            Attributes = new Dictionary<string, string>();
        }

        // Manual deep clone implementation
        public Person DeepCloneManual()
        {
            var clone = new Person
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                DateOfBirth = this.DateOfBirth,
                HomeAddress = this.HomeAddress?.DeepCloneManual(),
                WorkAddress = this.WorkAddress?.DeepCloneManual(),
                Contacts = new List<Contact>(),
                Attributes = new Dictionary<string, string>()
            };

            // Clone contacts
            foreach (var contact in this.Contacts)
            {
                clone.Contacts.Add(contact.DeepCloneManual());
            }

            // Clone attributes dictionary
            foreach (var kvp in this.Attributes)
            {
                clone.Attributes.Add(kvp.Key, kvp.Value);
            }

            return clone;
        }
    }

    [Serializable]
    [ProtoContract]
    public class Address
    {
        [ProtoMember(1)]
        public string Street { get; set; }
        
        [ProtoMember(2)]
        public string City { get; set; }
        
        [ProtoMember(3)]
        public string State { get; set; }
        
        [ProtoMember(4)]
        public string ZipCode { get; set; }
        
        [ProtoMember(5)]
        public string Country { get; set; }

        public Address DeepCloneManual()
        {
            return new Address
            {
                Street = this.Street,
                City = this.City,
                State = this.State,
                ZipCode = this.ZipCode,
                Country = this.Country
            };
        }
    }

    [Serializable]
    [ProtoContract]
    public class Contact
    {
        [ProtoMember(1)]
        public string Type { get; set; }
        
        [ProtoMember(2)]
        public string Value { get; set; }
        
        [ProtoMember(3)]
        public bool IsPrimary { get; set; }

        public Contact DeepCloneManual()
        {
            return new Contact
            {
                Type = this.Type,
                Value = this.Value,
                IsPrimary = this.IsPrimary
            };
        }
    }
}
