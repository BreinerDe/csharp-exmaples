namespace Record_Types
{
    public record MyAwesomeRecord
    {
        public int Id { get; init; }
        public string Name { get; init; }

        public void Deconstruct(out int id, out string name) => (id, name) = (Id, Name);
    }
}