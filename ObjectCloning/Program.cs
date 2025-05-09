using System;
using System.Text.Json;
using BenchmarkDotNet.Running;
using ObjectCloning.Benchmarks;
using ObjectCloning.Cloners;
using ObjectCloning.Models;

namespace ObjectCloning
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length > 0 && args[0] == "test")
            {
                RunTests();
            }
            else
            {
                Console.WriteLine("Running benchmarks...");
                var summary = BenchmarkRunner.Run<CloningBenchmarks>();
                Console.WriteLine("Benchmarks complete. Press any key to exit.");
                Console.ReadKey();
            }
        }

        static void RunTests()
        {
            Console.WriteLine("Running validation tests...");
            
            // Create a test person
            var original = new Person
            {
                Id = 1,
                FirstName = "Test",
                LastName = "User",
                DateOfBirth = new DateTime(1990, 1, 1),
                HomeAddress = new Address
                {
                    Street = "123 Test St",
                    City = "TestCity",
                    State = "TS",
                    ZipCode = "12345",
                    Country = "TestLand"
                }
            };
            
            original.Contacts.Add(new Contact { Type = "Email", Value = "test@example.com", IsPrimary = true });
            original.Attributes.Add("TestKey", "TestValue");

            // Test Newtonsoft.Json cloning
            Console.WriteLine("Testing Newtonsoft.Json cloning...");
            var newtonsoftClone = ObjectCloner.DeepCloneJson(original);
            
            // Modify original to verify deep clone
            original.FirstName = "Modified";
            original.HomeAddress.Street = "Modified Street";
            original.Contacts[0].Value = "modified@example.com";
            original.Attributes["TestKey"] = "ModifiedValue";
            
            Console.WriteLine($"Original FirstName: {original.FirstName}, Clone FirstName: {newtonsoftClone.FirstName}");
            Console.WriteLine($"Original Street: {original.HomeAddress.Street}, Clone Street: {newtonsoftClone.HomeAddress.Street}");
            Console.WriteLine($"Original Email: {original.Contacts[0].Value}, Clone Email: {newtonsoftClone.Contacts[0].Value}");
            Console.WriteLine($"Original Attribute: {original.Attributes["TestKey"]}, Clone Attribute: {newtonsoftClone.Attributes["TestKey"]}");
            
            // Reset original for System.Text.Json test
            original = new Person
            {
                Id = 1,
                FirstName = "Test",
                LastName = "User",
                DateOfBirth = new DateTime(1990, 1, 1),
                HomeAddress = new Address
                {
                    Street = "123 Test St",
                    City = "TestCity",
                    State = "TS",
                    ZipCode = "12345",
                    Country = "TestLand"
                }
            };
            
            original.Contacts.Add(new Contact { Type = "Email", Value = "test@example.com", IsPrimary = true });
            original.Attributes.Add("TestKey", "TestValue");
            
            // Test System.Text.Json cloning
            Console.WriteLine("\nTesting System.Text.Json cloning...");
            var systemTextJsonClone = ObjectCloner.DeepCloneSystemTextJson(original);
            
            // Modify original to verify deep clone
            original.FirstName = "Modified";
            original.HomeAddress.Street = "Modified Street";
            original.Contacts[0].Value = "modified@example.com";
            original.Attributes["TestKey"] = "ModifiedValue";
            
            Console.WriteLine($"Original FirstName: {original.FirstName}, Clone FirstName: {systemTextJsonClone.FirstName}");
            Console.WriteLine($"Original Street: {original.HomeAddress.Street}, Clone Street: {systemTextJsonClone.HomeAddress.Street}");
            Console.WriteLine($"Original Email: {original.Contacts[0].Value}, Clone Email: {systemTextJsonClone.Contacts[0].Value}");
            Console.WriteLine($"Original Attribute: {original.Attributes["TestKey"]}, Clone Attribute: {systemTextJsonClone.Attributes["TestKey"]}");
            
            // Reset original for Protobuf test
            original = new Person
            {
                Id = 1,
                FirstName = "Test",
                LastName = "User",
                DateOfBirth = new DateTime(1990, 1, 1),
                HomeAddress = new Address
                {
                    Street = "123 Test St",
                    City = "TestCity",
                    State = "TS",
                    ZipCode = "12345",
                    Country = "TestLand"
                }
            };
            
            original.Contacts.Add(new Contact { Type = "Email", Value = "test@example.com", IsPrimary = true });
            original.Attributes.Add("TestKey", "TestValue");
            
            // Test Protobuf cloning
            Console.WriteLine("\nTesting Protobuf cloning...");
            var protobufClone = ObjectCloner.DeepCloneProtobuf(original);
            
            // Modify original to verify deep clone
            original.FirstName = "Modified";
            original.HomeAddress.Street = "Modified Street";
            original.Contacts[0].Value = "modified@example.com";
            original.Attributes["TestKey"] = "ModifiedValue";
            
            Console.WriteLine($"Original FirstName: {original.FirstName}, Clone FirstName: {protobufClone.FirstName}");
            Console.WriteLine($"Original Street: {original.HomeAddress.Street}, Clone Street: {protobufClone.HomeAddress.Street}");
            Console.WriteLine($"Original Email: {original.Contacts[0].Value}, Clone Email: {protobufClone.Contacts[0].Value}");
            Console.WriteLine($"Original Attribute: {original.Attributes["TestKey"]}, Clone Attribute: {protobufClone.Attributes["TestKey"]}");
            
            // Reset original for manual clone test
            original = new Person
            {
                Id = 1,
                FirstName = "Test",
                LastName = "User",
                DateOfBirth = new DateTime(1990, 1, 1),
                HomeAddress = new Address
                {
                    Street = "123 Test St",
                    City = "TestCity",
                    State = "TS",
                    ZipCode = "12345",
                    Country = "TestLand"
                }
            };
            
            original.Contacts.Add(new Contact { Type = "Email", Value = "test@example.com", IsPrimary = true });
            original.Attributes.Add("TestKey", "TestValue");
            
            // Test manual cloning
            Console.WriteLine("\nTesting manual cloning...");
            var manualClone = ObjectCloner.DeepCloneManual(original);
            
            // Modify original to verify deep clone
            original.FirstName = "Modified";
            original.HomeAddress.Street = "Modified Street";
            original.Contacts[0].Value = "modified@example.com";
            original.Attributes["TestKey"] = "ModifiedValue";
            
            Console.WriteLine($"Original FirstName: {original.FirstName}, Clone FirstName: {manualClone.FirstName}");
            Console.WriteLine($"Original Street: {original.HomeAddress.Street}, Clone Street: {manualClone.HomeAddress.Street}");
            Console.WriteLine($"Original Email: {original.Contacts[0].Value}, Clone Email: {manualClone.Contacts[0].Value}");
            Console.WriteLine($"Original Attribute: {original.Attributes["TestKey"]}, Clone Attribute: {manualClone.Attributes["TestKey"]}");
            
            Console.WriteLine("\nTests complete. Press any key to exit.");
            Console.ReadKey();
        }
    }
}
