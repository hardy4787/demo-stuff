using Catalog.API.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Catalog.API.Db
{
    public class CatalogContext : DbContext
    {
        public CatalogContext(DbContextOptions<CatalogContext> options) : base(options)
        {
        }

        public DbSet<CatalogItem> CatalogItems { get; set; }
    }
}
