namespace TemaLab19.DTOs
{
    public class StudentToGet
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public AddressToGet Address { get; set; }
    }
    public class StudentToCreate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class StudentToUpdate
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class AddressToGet
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
    }
    public class AddressToUpdate
    {
        public string City { get; set; }
        public string Street { get; set; }
        public int Number { get; set; }
    }

}
