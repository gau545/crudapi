namespace CrudOperation.Models.Domain
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = null!;
        public string Text { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }
}
