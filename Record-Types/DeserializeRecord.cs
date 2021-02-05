using System;
using System.Text.Json;

namespace Record_Types
{
    public static class DeserializeRecord
    {
        // with record types its possible to deserialize into immutable types, using System.Text.Json and init
        public static void Run()
        {
            var json = "{\"Id\":1,\"Name\":\"John Doe\"}";

            var deserialized = JsonSerializer.Deserialize<MyAwesomeRecord>(json);

            Console.WriteLine(deserialized.Id);
            Console.WriteLine(deserialized.Name);
        }
    }
}