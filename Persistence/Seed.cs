using Domain;
using Persistence;

public class Seed{
 public static void SeedBata(DataContex contex){
  if(!contex.Posts.Any()){
   var Posts = new List<Post>
   {
new Post  {
     Title = "First Post",
     Body = "Lorem ipsum, or lipsum as it is sometimes known, is dummy text used in laying out print",
     Date = DateTime.Now.AddDays(-10)
    },
    new Post  {
     Title = "Second Post",
     Body = "The purpose of lorem ipsum is to create a natural looking block of text (sentence, paragraph, page, etc.) that doesn't distract from the layout.",
     Date = DateTime.Now.AddDays(-7)
    },
    new Post  {
     Title = "Third Post",
     Body = "The placeholder text, begin ning with the line “Lorem ipsum dolor sit amet, consectetur adipiscing elit”, looks like Latin because in its youth, centuries ago, it was Latin.",
     Date = DateTime.Now.AddDays(-4)
    }
    
   };

   contex.Posts.AddRange(Posts);
   contex.SaveChanges();
  }
 }
}