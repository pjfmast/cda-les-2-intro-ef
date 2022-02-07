namespace Les2EFIntro.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;

        public Team Team { get; set; } = null!;
        public int? TeamId { get; set; }

    }
}
