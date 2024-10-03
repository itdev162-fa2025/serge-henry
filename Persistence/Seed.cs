using Domain;
using Persistence;

public class Seed{
 public static void SeedBata(DataContex contex){
  if(!contex.Posts.Any()){
   var Posts = new List<post>
   {
new post  {
     Title = "First Post",
     Body = "Lorem ipsum, or lipsum as it is sometimes known, is dummy text used in laying out print",
     Date = DateTime.Now.AddDays(-10)
    },
    new post  {
     Title = "Second Post",
     Body = "The purpose of lorem ipsum is to create a natural looking block of text (sentence, paragraph, page, etc.) that doesn't distract from the layout.",
     Date = DateTime.Now.AddDays(-7)
    },
    new post  {
     Title = "Third Post",
     Body = "The placeholder text, beginning with the line “Lorem ipsum dolor sit amet, consectetur adipiscing elit”, looks like Latin because in its youth, centuries ago, it was Latin.",
     Date = DateTime.Now.AddDays(-4)
    },
     new post  {
     Title = "forth Post",
     Body = "The decade that brought us Star Trek and Doctor Who also resurrected Cicero—or at least what used to be Cicero—in an attempt to make the days before computerized design a little less painstaking.",
     Date = DateTime.Now.AddDays(-1)
    }
    
   };

   contex.Posts.AddRange(Posts);
   contex.SaveChanges();
  }
 }
}