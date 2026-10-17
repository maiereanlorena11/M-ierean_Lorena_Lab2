using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Măierean_Lorena_Lab2.Models;

namespace Măierean_Lorena_Lab2.Pages.Authors;

public class IndexModel : PageModel
{
    private readonly Măierean_Lorena_Lab2Context _context;

    public IndexModel(Măierean_Lorena_Lab2Context context)
    {
        _context = context;
    }

    public IList<Author> Author { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Author = await _context.Author.ToListAsync();
    }
}
