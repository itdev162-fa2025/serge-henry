using System.Runtime.CompilerServices;
using Domain;
 using Microsoft.AspNetCore.Mvc;
using Persistence;

 namespace API.Controllers;
 [ApiController]
 [Route("[controller]")]

 public class weatherForecastController : ControllerBase
 {
  private static readonly string[] Summaries = new[]
  {
   "Freezing","Bracing","Chilly","Cool","Mild","Warm","Balmy","Hot","Sweltering","Scorching"
  };

  private readonly ILogger<weatherForecastController>_logger;
  private readonly DataContex _context;
  public weatherForecastController(ILogger<weatherForecastController> logger, DataContex contex){

   _logger = logger;
   _context = contex;
  }
  [HttpGet(Name ="GetWeatherForecast")]
  public IEnumerable<weatherForecast> Get(){
   return Enumerable.Range(1, 5).Select(Index => new weatherForecast
   {
    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(Index)),
    TemperatureC = Random.Shared.Next(-20,55),
    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
   })
   .ToArray();
  }
  [HttpPost]
  public ActionResult<weatherForecast> Create(){
   // view in your Vs Code console -fly
   Console.WriteLine($"DataBase path: {_context.DbPath}");
   Console.WriteLine("Insert a new WeatherForeCast");

   var foreCast = new weatherForecast(){
    Date = new DateOnly(),
    TemperatureC = 75,
    Summary = "Warm"
   };

   _context.WeatherForecasts.Add(foreCast);
   var success = _context.SaveChanges() > 0;

   if (success)
   {
    return foreCast;
   }
   throw new Exception("Error creating WeatherForeCast");
  }
 }