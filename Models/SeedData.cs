using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Lab11.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProfDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProfDbContext>>()))
            {
                // Look for any movies.
                if (context.Professor.Any())
                {
                    return;   // DB has been seeded
                }

                context.Professor.AddRange(

                    new Professor
                    {
                        FirstName = "Katherine",
                        LastName = "Carl"
                    },

                    new Professor
                    {
                        FirstName = "Kareem",
                        LastName ="Dana"
                    },

                    new Professor
                    {
                        FirstName = "Jeffry",
                        LastName ="Babb"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}