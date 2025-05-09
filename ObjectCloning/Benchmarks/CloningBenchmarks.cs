using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Order;
using ObjectCloning.Cloners;
using ObjectCloning.Models;

namespace ObjectCloning.Benchmarks
{
    [MemoryDiagnoser]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    [SimpleJob(RuntimeMoniker.Net80)]

    public class CloningBenchmarks
    {
        private Person _simpleObject;
        private Person _complexObject;

        [GlobalSetup]
        public void Setup()
        {
            // Create a simple person object with minimal nested data
            _simpleObject = new Person
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1980, 1, 1),
                HomeAddress = new Address
                {
                    Street = "123 Main St",
                    City = "Anytown",
                    State = "CA",
                    ZipCode = "12345",
                    Country = "USA"
                }
            };

            // Create a complex person object with more nested data
            _complexObject = new Person
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Smith",
                DateOfBirth = new DateTime(1985, 5, 15),
                HomeAddress = new Address
                {
                    Street = "456 Oak Ave",
                    City = "Somewhere",
                    State = "NY",
                    ZipCode = "67890",
                    Country = "USA"
                },
                WorkAddress = new Address
                {
                    Street = "789 Business Blvd",
                    City = "Metropolis",
                    State = "IL",
                    ZipCode = "54321",
                    Country = "USA"
                }
            };

            // Add contacts
            _complexObject.Contacts.Add(new Contact { Type = "Email", Value = "jane.smith@example.com", IsPrimary = true });
            _complexObject.Contacts.Add(new Contact { Type = "Phone", Value = "555-123-4567", IsPrimary = false });
            _complexObject.Contacts.Add(new Contact { Type = "LinkedIn", Value = "linkedin.com/in/janesmith", IsPrimary = false });

            // Add attributes
            _complexObject.Attributes.Add("Department", "Engineering");
            _complexObject.Attributes.Add("Title", "Senior Developer");
            _complexObject.Attributes.Add("YearsOfExperience", "8");
            _complexObject.Attributes.Add("Skills", "C#, .NET, Azure, SQL");
        }

        [Benchmark]
        public Person ManualCloneSimple()
        {
            return ObjectCloner.DeepCloneManual(_simpleObject);
        }

        [Benchmark]
        public Person ProtobufCloneSimple()
        {
            return ObjectCloner.DeepCloneProtobuf(_simpleObject);
        }

        [Benchmark]
        public Person SystemTextJsonCloneSimple()
        {
            return ObjectCloner.DeepCloneSystemTextJson(_simpleObject);
        }

        [Benchmark(Baseline = true)]
        public Person NewtonsoftJsonCloneSimple()
        {
            return ObjectCloner.DeepCloneJson(_simpleObject);
        }

        [Benchmark]
        public Person ManualCloneComplex()
        {
            return ObjectCloner.DeepCloneManual(_complexObject);
        }

        [Benchmark]
        public Person ProtobufCloneComplex()
        {
            return ObjectCloner.DeepCloneProtobuf(_complexObject);
        }

        [Benchmark]
        public Person SystemTextJsonCloneComplex()
        {
            return ObjectCloner.DeepCloneSystemTextJson(_complexObject);
        }

        [Benchmark]
        public Person NewtonsoftJsonCloneComplex()
        {
            return ObjectCloner.DeepCloneJson(_complexObject);
        }
    }
}
