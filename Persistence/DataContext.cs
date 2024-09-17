using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
 public class DataContex: DbContext
 {
  public DbSet<weatherForecast> WeatherForecasts {get; set;}
  public string DbPath {get;} 
  public DataContex(){

   var folder = Environment.SpecialFolder.LocalApplicationData;
   var path = Environment.GetFolderPath(folder);

  }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");

        }
    }
}