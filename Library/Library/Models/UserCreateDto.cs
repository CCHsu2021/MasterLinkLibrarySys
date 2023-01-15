namespace Library.Models
{
    public class UserCreateDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string Secret { get; set; } = null!;

        public string SecretRe { get; set; } = null!;
    }
}
