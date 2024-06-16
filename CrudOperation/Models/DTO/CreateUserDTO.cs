namespace CrudOperation.Models.DTO
{
    public class CreateUserDTO
    {
        public string Username { get; set; } = null!;
        public string Text { get; set; } = null!;
        public DateTime CreatedDate { get; set; }
    }

    public class UpdateUserDTO
    {
        public string Username { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
}
