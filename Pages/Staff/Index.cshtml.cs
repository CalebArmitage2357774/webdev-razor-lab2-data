using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MyRazorApp.Data;
using MyRazorApp.Models;

namespace MyRazorApp.Pages.Staff;

public class IndexModel : PageModel
{
    // -------------------------------------------------------------------------
    // LAB 2 - STEP 01: Database Integration
    // -------------------------------------------------------------------------
    // In Step 01, you will:
    // 1. Install Microsoft.EntityFrameworkCore.Sqlite
    // 2. Create Models/Staff.cs and Data/ApplicationDbContext.cs
    // 3. Register ApplicationDbContext in Program.cs
    // 4. Inject ApplicationDbContext via constructor dependency injection:
    //
    private readonly ApplicationDbContext _context;

    // Dependency Injection via constructor
    public IndexModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Models.Staff> StaffMembers { get; set; } = [];
    public int ActiveCount { get; set; }

    public async Task OnGetAsync()
    {
        StaffMembers = await _context.Staff.ToListAsync();
        ActiveCount = StaffMembers.Count(s => s.IsActive == 1);
    }
    // -------------------------------------------------------------------------
}
