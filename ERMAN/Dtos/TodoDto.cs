namespace ERMAN.Dtos
{
    public class TodoDto
    {
        public string UserType { get; set; } = null!;

        public string Text { get; set; } = null!;

        public string Type { get; set; } = null!;

        public bool Starred { get; set; }

        public string DueDate { get; set; } = null!;

        public int UserId { get; set; }

        public bool Done { get; set; }
    }
}
