namespace ERMAN.Dtos
{
    public class UserDto
    {
        public UserType UserType { get; set; }

        public string Email { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int BilkentId { get; set; }

        public string Department { get; set; } = null!;

        public string Faculty { get; set; } = null!;

        public string University { get; set; } = null!;

        public string DurationPreffered { get; set; } = null!;

        public string Program { get; set; } = null!;
    }
}
