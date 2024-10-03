namespace Mini_projeto_Book_Samsys.Models.DTOs
{
    public class BookDTO
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool Active { get; set; }
        public List<int> AuthorIds { get; set; }

        public BookDTO(float price)
        {
            //IdAuthor = idAuthor;
            Price = price;
        }
    }
}

