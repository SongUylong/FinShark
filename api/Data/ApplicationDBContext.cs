using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
  public class ApplicationDBContext : DbContext
  {
    public ApplicationDBContext(DbContextOptions dbContextOptions)
    : base(dbContextOptions)
    {
      //pass to actual DbContext
    }

    public DbSet<Stock> Stock { get; set; }
    // I want a table for Stock and I want to query/manipulate it
    public DbSet<Comment> Comments { get; set; }
  }
}
