using System;

namespace Record_Types
{
    public class Program
    {
        static void Main(string[] args)
        {
            DeserializeRecord.Run();
            ShowRecordTypeExample();

        }

        private static void ShowRecordTypeExample()
        {
            var rec = new MyAwesomeRecord()
            {
                Id = 1,
                Name = ""
            };

            var rec2 = rec with { };
            var rec3 = rec with { Id = 4 };

            Console.WriteLine(rec.Id);
            Console.WriteLine(rec2.Id);
            Console.WriteLine(rec3.Id);
            Console.WriteLine(rec2 == rec);
            Console.WriteLine(rec3 == rec);

            var (id, name) = rec;

            Console.WriteLine(id);
            Console.WriteLine(name);
        }
    }
}