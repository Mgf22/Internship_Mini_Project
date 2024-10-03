using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Mini_projeto_Book_Samsys.Models
{
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        public Author()
        {
            this.Books = new HashSet<Book>();
        }
        public bool DeleteAuthor()
        {
            if (Active == true)
            {
                Active = false;
                return true;
            }
            return false;
        }

        public void Update(Author author)
        {
            Name = author.Name;
        }
    }
}
