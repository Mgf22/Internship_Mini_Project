using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static System.Reflection.Metadata.BlobBuilder;

namespace Mini_projeto_Book_Samsys.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string ISBN { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Author> Authors { get; set; }

        public Book()
        {
            this.Authors = new HashSet<Author>();
        }

        public bool ActivateBook()
        {
            if (Active == false)
            {
                Active = true;
                return true;
            }
            return false;
        }

        public bool DeleteBook()
        {
            if (Active == true)
            {
                Active = false;
                return true;
            }
            return false;
        }

        public void Update(Book book)
        {
            ISBN = book.ISBN;
            Name = book.Name;
            Price = book.Price;
        }
    }
}
