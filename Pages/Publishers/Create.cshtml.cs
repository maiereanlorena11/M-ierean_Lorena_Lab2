using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Măierean_Lorena_Lab2.Models;
using Măierean_Lorena_Lab2.Data;

namespace Măierean_Lorena_Lab2.Pages.Publishers;

public class CreateModel : PageModel
{
    private readonly Măierean_Lorena_Lab2Context _context;

    public CreateModel(Măierean_Lorena_Lab2Context context)
    {
        _context = context;
    }

    public IActionResult OnGet()
    {
        return Page();
    }

    [BindProperty]
    public Models.Publisher Publisher { get; set; } = default!;
    // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD.
    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Publisher.Add(Publisher);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
