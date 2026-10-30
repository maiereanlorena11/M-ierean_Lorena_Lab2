using Măierean_Lorena_Lab2.Models;

namespace Măierean_Lorena_Lab2.ViewModels
{
    public class CategoryIndexData
    {
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}