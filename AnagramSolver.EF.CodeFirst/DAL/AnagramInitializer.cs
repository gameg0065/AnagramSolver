using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AnagramSolver.Models;

namespace AnagramSolver.DAL
{
    public class AnagramInitializer
    {
        public static void Initialize(AnagramContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.WordEntities.Any())
            {
                return;   // DB has been seeded
            }
            
            var wordEntities = new List<WordEntity>
            {
                new WordEntity{ID=1,Word="Alexander",Category="lol"},
            };

            wordEntities.ForEach(s => context.WordEntities.Add(s));
            context.SaveChanges();
        }
    }
}