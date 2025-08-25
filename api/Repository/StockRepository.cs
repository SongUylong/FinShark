using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using api.Model;
using Microsoft.AspNetCore.Http.HttpResults;
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

    public async Task<Stock?> GetByIdAsync(int id)
    {
      return await _context.Stocks.FindAsync(id);
    }

    public async Task<Stock> CreateAsync(Stock stockModel)
    {
      await _context.Stocks.AddAsync(stockModel);
      await _context.SaveChangesAsync();
      return stockModel;
    }
    public async Task<Stock?> DeleteAsync(int id)
    {
      var stockModel = await _context.Stocks.FindAsync(id);
      if (stockModel == null)
      {
        return null;
      }
      _context.Stocks.Remove(stockModel);
      await _context.SaveChangesAsync();
      return stockModel;
    }

    public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
    {
      var stockModel = await _context.Stocks.FindAsync(id);
      if (stockModel == null)
      {
        return null;
      }
      stockModel.Symbol = stockDto.Symbol;
      stockModel.Purchase = stockDto.Purchase;
      stockModel.CompanyName = stockDto.CompanyName;
      stockModel.MarketCap = stockDto.MarketCap;
      stockModel.LastDiv = stockDto.LastDiv;
      stockModel.MarketCap = stockDto.MarketCap;
      await _context.SaveChangesAsync();
      return stockModel;
    }

    //StockRepository says, “I will provide the methods defined in IStockRepository.”You still need to fill in the real logic for those methods.
  }
}
