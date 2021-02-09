using Microsoft.VisualStudio.TestTools.UnitTesting;
using Testing.Extensions;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Compare_2_Objects()
        {
            var testItem = new MyTestItem(1, "john Doe", "New York");
            var expectedItem = new MyTestItem(1, "Jane Doe", "New York");

            // This will compare all properties of the two objects and display a nice table if they don't match
            Assert.That.ObjectsAreEqual(() => testItem, () => expectedItem);
        }

    }

    public class MyTestItem
    {
        public MyTestItem(int id, string name, string location)
        {
            Id = id;
            Name = name;
            Location = location;
        }
        public int Id { get; }
        public string Name { get; }

        public string Location { get; }
    }
}