using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Măierean_Lorena_Lab2.Models;
using Măierean_Lorena_Lab2.Data;

namespace Măierean_Lorena_Lab2.Pages.Publishers;

public class IndexModel : PageModel
{
    private readonly Măierean_Lorena_Lab2Context _context;

    public IndexModel(Măierean_Lorena_Lab2Context context)
    {
        _context = context;
    }

    public IList<Publisher> Publisher { get; set; } = default!;

    public async Task OnGetAsync()
    {
        if (_context.Publisher != null)
        {
            Publisher = await _context.Publisher.ToListAsync();
        }
    }
}
