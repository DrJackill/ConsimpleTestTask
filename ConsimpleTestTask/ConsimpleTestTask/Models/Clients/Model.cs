namespace ConsimpleTestTask.Models.Clients
{
    public class Client
    {
        public Client(string fullName, DateTimeOffset birthDate, DateTimeOffset registrationDate)
        {
            FullName = fullName;
            BirthDate = birthDate;
            RegistrationDate = registrationDate;
        }

        public Guid Id { get; set; }

        public string FullName{get; set;}

        public DateTimeOffset BirthDate{get; set;}

        public DateTimeOffset RegistrationDate{get; set;}
    }
}