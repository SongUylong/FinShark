using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Interfaces;
using api.Mappers;
using api.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
  [Route("api/[Controller]")]
  [ApiController]
  public class StockController : ControllerBase
  {
    //Yes, exactly! By storing the repository instance in a field like this:

    private readonly ApplicationDBContext _context;
    private readonly IStockRepository _stockRepo;
    public StockController(ApplicationDBContext context, IStockRepository stockRepo)
    {
      _stockRepo = stockRepo;
      _context = context;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
      var stocks = await _stockRepo.GetAllAsync();
      var stocksDto = stocks.Select(s => s.ToStockDto());
      return Ok(stocksDto);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetbyId([FromRoute] int id)
    {
      var stock = await _context.Stocks.FindAsync(id);
      if (stock == null)
      {
        return NotFound();
      }
      return Ok(stock.ToStockDto());
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
    {
      var stockModel = stockDto.ToStockFromCreateDTO();
      await _context.Stocks.AddAsync(stockModel);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetbyId), new { id = stockModel.Id }, stockModel.ToStockDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update([FromBody] UpdateStockRequestDto UpdateStockDto, [FromRoute] int id)
    {
      var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
      if (stockModel == null)
      {
        return NotFound();
      }
      stockModel.Symbol = UpdateStockDto.Symbol;
      stockModel.Purchase = UpdateStockDto.Purchase;
      stockModel.CompanyName = UpdateStockDto.CompanyName;
      stockModel.MarketCap = UpdateStockDto.MarketCap;
      stockModel.LastDiv = UpdateStockDto.LastDiv;
      stockModel.MarketCap = UpdateStockDto.MarketCap;
      await _context.SaveChangesAsync();
      return Ok(stockModel.ToStockDto());
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
    {
      var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
      if (stockModel == null)
      {
        return NotFound();
      }
      _context.Remove(stockModel);
      await _context.SaveChangesAsync();
      return NoContent();
    }
  }

}
