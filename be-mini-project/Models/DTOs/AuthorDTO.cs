namespace Mini_projeto_Book_Samsys.Models.DTOs
{
    public class AuthorDTO
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public List<int> BookIds { get; set; }
    }
}
