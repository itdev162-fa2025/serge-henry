namespace Domain{
 public class Post{
  public Guid Id{ get; set;}
  public required string Title {get; set;}
  public required string Body {get; set;}
  public DateTime Date {get; set;}
 }
}