using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Măierean_Lorena_Lab2.Models;
using Măierean_Lorena_Lab2.Data;

namespace Măierean_Lorena_Lab2.Pages.BookPages;

public class DetailsModel : PageModel
{
    private readonly Măierean_Lorena_Lab2Context _context;
    public DetailsModel(Măierean_Lorena_Lab2Context context)
    {
        _context = context;
    }

    public Book Book { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null || _context.Book == null)
        {
            return NotFound();
        }

        var book = await _context.Book
            .Include(b => b.Author)
            .Include(b => b.Publisher)
            .Include(b => b.BookCategories) // sau .Categories, în funcție de cum ai numit relația
                .ThenInclude(bc => bc.Category)
            .FirstOrDefaultAsync(m => m.ID == id);
        if (book == null)
        {
            return NotFound();
        }
        else
        {
            Book = book;
        }

        return Page();
    }
}
