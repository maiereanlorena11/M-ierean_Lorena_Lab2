using Măierean_Lorena_Lab2.Data;
using Măierean_Lorena_Lab2.Models;
using Măierean_Lorena_Lab2.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Măierean_Lorena_Lab2.Pages.Publishers;

public class IndexModel : PageModel
{
    private readonly Măierean_Lorena_Lab2.Data.Măierean_Lorena_Lab2Context _context;

    public IndexModel(Măierean_Lorena_Lab2.Data.Măierean_Lorena_Lab2Context context)
    {
        _context = context;
    }

    public IList<Publisher> Publisher { get; set; } = default!;

    public PublisherIndexData PublisherData { get; set; }
    public int PublisherID { get; set; }
    public int BookID { get; set; }
    public async Task OnGetAsync(int? id, int? bookID)
    {
        PublisherData = new PublisherIndexData();
        PublisherData.Publishers = await _context.Publisher
        .Include(i => i.Books)
        .ThenInclude(c => c.Author)
        .OrderBy(i => i.PublisherName)
        .ToListAsync();
        if (id != null)
        {
            PublisherID = id.Value;
            Publisher publisher = PublisherData.Publishers
            .Where(i => i.ID == id.Value).Single();
            PublisherData.Books = publisher.Books;
        }
    }
}
