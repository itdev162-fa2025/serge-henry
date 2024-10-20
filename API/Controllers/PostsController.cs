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

 [HttpGet("{id}", Name = "GetBayId")]

 public ActionResult<Post> GetById(Guid id){
  var post = this._contex.Posts.Find(id);
  if(post is null){
   return NotFound();
  }
  return Ok(post);
 }

 [HttpPost(Name ="Create")]
 public ActionResult<Post> Create([FromBody] Post request){
  var post = new Post
  {
   Id = request.Id,
   Title = request.Title,
   Body = request.Body,
   Date = request.Date
  };

  _contex.Posts.Add(post);
  var success = _contex.SaveChanges() >0;

  if (success){
   return Ok(post);
  }

  throw new Exception("Error create post");
 }

 [HttpPut(Name = "Update")]
 public ActionResult<Post> Update([FromBody]Post request)
 {
  var post =_contex.Posts.Find(request.Id);
  if (post ==null){
   throw new Exception("could not find post");
  }

  post.Title = request.Title != null? request.Title:post.Title;
  post.Body = request.Body!= null? request.Body: post.Body;
  post.Date = request.Date!= DateTime.MinValue? request.Date : post.Date;

  var success =_contex.SaveChanges() >0;
  if (success)
  {
   return Ok(post);
  }

  throw new Exception("error updating post");
 }

 }
}

