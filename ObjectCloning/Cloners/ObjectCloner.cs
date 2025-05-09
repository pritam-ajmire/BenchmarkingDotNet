using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Newtonsoft.Json;
using ObjectCloning.Models;
using ProtoBuf;

namespace ObjectCloning.Cloners
{
    public static class ObjectCloner
    {
        /// <summary>
        /// Creates a deep clone of an object using Newtonsoft.Json serialization
        /// </summary>
        public static T DeepCloneJson<T>(T source)
        {
            if (source == null)
            {
                return default;
            }

            // Serialize to JSON string
            string json = JsonConvert.SerializeObject(source);
            
            // Deserialize back to object
            return JsonConvert.DeserializeObject<T>(json);
        }
        
        /// <summary>
        /// Creates a deep clone of an object using System.Text.Json serialization
        /// </summary>
        public static T DeepCloneSystemTextJson<T>(T source)
        {
            if (source == null)
            {
                return default;
            }

            // Configure options
            var options = new System.Text.Json.JsonSerializerOptions
            {
                WriteIndented = false,
                PropertyNameCaseInsensitive = true
            };
            
            // Serialize to JSON string
            string json = System.Text.Json.JsonSerializer.Serialize(source, options);
            
            // Deserialize back to object
            return System.Text.Json.JsonSerializer.Deserialize<T>(json, options);
        }
        
        /// <summary>
        /// Creates a deep clone of an object using Protobuf serialization
        /// </summary>
        public static T DeepCloneProtobuf<T>(T source)
        {
            if (source == null)
            {
                return default;
            }

            // Use MemoryStream for serialization
            using (var stream = new MemoryStream())
            {
                // Serialize to stream
                Serializer.Serialize(stream, source);
                
                // Reset stream position
                stream.Position = 0;
                
                // Deserialize from stream
                return Serializer.Deserialize<T>(stream);
            }
        }

        /// <summary>
        /// Creates a deep clone of a Person object using manual property copying
        /// </summary>
        public static Person DeepCloneManual(Person source)
        {
            if (source == null)
            {
                return null;
            }

            return source.DeepCloneManual();
        }
    }
}
