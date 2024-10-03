using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
 public class DataContex: DbContext
 {
  public DbSet<weatherForecast> WeatherForecasts {get; set;}
  public DbSet<post> Posts {get; set;}
  public string DbPath {get;} 
  public DataContex(){

   var folder = Environment.SpecialFolder.LocalApplicationData;
   var path = Environment.GetFolderPath(folder);
   DbPath = System.IO.Path.Join(path, "Blogbox.db");
  }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite($"Data Source={DbPath}");

        }
    }
}