using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Lab11.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;

namespace Lab11.Pages
{
    public class IndexModel : PageModel
    {
        private readonly Lab11.Models.ProfDbContext _context;
        public List<Lab11.Models.Professor> Professors {get; set;}

       public IndexModel(Lab11.Models.ProfDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Professors = _context.Professor.ToList();

        }
    }
}
