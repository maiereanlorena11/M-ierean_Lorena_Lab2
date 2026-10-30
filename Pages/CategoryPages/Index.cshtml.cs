using Măierean_Lorena_Lab2.Data;
using Măierean_Lorena_Lab2.Models;
using Măierean_Lorena_Lab2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Măierean_Lorena_Lab2.Pages.CategoryPages
{
    public class IndexModel : PageModel
    {
        private readonly Măierean_Lorena_Lab2.Data.Măierean_Lorena_Lab2Context _context;

        public IndexModel(Măierean_Lorena_Lab2.Data.Măierean_Lorena_Lab2Context context)
        {
            _context = context;
        }

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)
                    .ThenInclude(c => c.Book)
                        .ThenInclude(a => a.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                Category category = CategoryData.Categories
                    .Where(i => i.ID == id.Value).Single();
                CategoryData.Books = category.BookCategories.Select(s => s.Book);
            }
        }
    }
}
