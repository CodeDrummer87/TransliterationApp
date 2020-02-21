using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransliterationApp.Models.DbSets
{
    public class TransAppContext : DbContext
    {
        public DbSet<Alphabet> Alphabets { get; set; }
        public DbSet<SourceText> SourceTexts { get; set; }

        public TransAppContext(DbContextOptions<TransAppContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}