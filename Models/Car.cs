namespace Models
{
    public class Car
    {
        public static readonly string GET = "SELECT Id, Name, Color, Year FROM Car WHERE Id = @Id";
        public static readonly string GET_ALL = "SELECT Id, Name, Color, Year FROM Car"; 
        public static readonly string INSERT = "INSERT INTO Car (Name, Color, Year) values (@Name, @Color, @Year)";
        public static readonly string UPDATE = "UPDATE Car SET Name = @Name, Color = @Color, Year = @Year WHERE Id = @Id";
        public static readonly string DELETE = "DELETE FROM Car WHERE Id = @Id";

        public int Id { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public int Year { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} \nNome: {Name} \nColor: {Color} \nAno: {Year}";
        }
    }
}
