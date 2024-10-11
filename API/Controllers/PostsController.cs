using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;

namespace API.Controllers
{
 [ApiController]
 [Route("api/[controller]")]
 
 public class PostsController: ControllerBase{

  private readonly DataContex _contex;
  public PostsController(DataContex contex)
  {
   this._contex = contex;
  }

  // Get api/posts

  [HttpGet(Name ="Getposts")]
  public ActionResult<List<Post>> Get()
  {
   return this._contex.Posts.ToList();
  }
 }
}