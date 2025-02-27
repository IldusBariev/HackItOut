namespace HuckItOut.API.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? SecondName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailName { get; set; }
        public string EmailDomen { get; set; }

        public Player()
        {
            
        }

        public Player(
            string lastName,
            string firstName,
            string? seconName,
            string phoneNumber,
            string emailName,
            string emailDomen)
        {
            LastName = lastName;
            FirstName = firstName;
            SecondName = seconName;
            PhoneNumber = phoneNumber;
            EmailName = emailName;
            EmailDomen = emailDomen;
        }

    }
}
