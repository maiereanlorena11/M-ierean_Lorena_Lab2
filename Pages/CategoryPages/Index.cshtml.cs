using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Măierean_Lorena_Lab2.Models;
using Măierean_Lorena_Lab2.Data;

namespace Măierean_Lorena_Lab2.Pages.CategoryPages;

public class IndexModel : PageModel
{
    private readonly Măierean_Lorena_Lab2Context _context;

    public IndexModel(Măierean_Lorena_Lab2Context context)
    {
        _context = context;
    }

    public IList<Category> Category { get; set; } = default!;

    public async Task OnGetAsync()
    {
        Category = await _context.Category.ToListAsync();
    }
}
