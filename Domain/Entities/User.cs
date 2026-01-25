namespace Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string CreatedAt { get; set; }

        public User(string email, string username)
        {
            if (string.IsNullOrWhiteSpace(email))
                throw new ArgumentException("email cannot be empty", nameof(email));

            Email = email;
            Username = username;
        }
    }    
}
