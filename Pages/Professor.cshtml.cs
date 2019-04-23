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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Lab11.Pages
{
    public class ProfessorModel : PageModel
    {
        private readonly ProfDbContext _context;
        public List<Professor> Professors { get; set; }
        public SelectList ProfessorDropDown { get; set; }
        public ProfessorModel(Models.ProfDbContext context, ILogger<ProfessorModel> log)
        {
            _context = context;
            _log = log;
        }
        
        public void OnGet()
        {
            Professors = _context.Professor.ToList();
            ProfessorDropDown = new SelectList(Professors, "ProfessorId", "FirstName");
            _log.LogWarning($"OnPost() Called. FirstName = {FirstName}");
        }
        private readonly ILogger _log;

        [BindProperty]
        public int professorId { get; set; }

        [BindProperty]
        [StringLength(60, MinimumLength = 3)]
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [BindProperty]
        [Display(Name = "Last Name")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string LastName { get; set; }
        public string select { get; set; }

        public void OnPost()
        {
            FirstName = _context.Professor.Where(p => p.ProfessorId == professorId).FirstOrDefault().FirstName;
            LastName = _context.Professor.Where(p => p.ProfessorId == professorId).FirstOrDefault().LastName;

            select = "You selected: " + FirstName + " " + LastName;
        }
    }
}