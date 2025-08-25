using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Interfaces;
using api.Model;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
  public class StockRepository : IStockRepository
  {

    private readonly ApplicationDBContext _context;
    public StockRepository(ApplicationDBContext context)
    {
      _context = context;
    }
    public async Task<List<Stock>> GetAllAsync()
    {
      return await _context.Stocks.ToListAsync();
    }
    //StockRepository says, “I will provide the methods defined in IStockRepository.”You still need to fill in the real logic for those methods.
  }
}
