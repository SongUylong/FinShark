using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
// docker run -e "ACCEPT_EULA=Y" `
//            -e "MSSQL_SA_PASSWORD=P@ssword123!" `
//            -e "MSSQL_PID=Developer" `
//            -p 1433:1433 `
//            -v mssql_data:/var/opt/mssql `
//            --name mssql2022 `
//            -d mcr.microsoft.com/mssql/server:2022-latest

namespace api.Model
{
  public class Stock
  {
    public int Id { get; set; }
    public string Symbol { get; set; } = String.Empty;
    public string CompanyName { get; set; } = String.Empty;

    [Column(TypeName = "decimal(18,2)")]
    public decimal Purchase { get; set; }

    [Column(TypeName = "decimal(18,2)")]
    public decimal LastDiv { get; set; }

    public string Industry { get; set; } = String.Empty;

    public long MarketCap { get; set; }

    public List<Comment> Comments { get; set; } = new List<Comment>();


  }
}
