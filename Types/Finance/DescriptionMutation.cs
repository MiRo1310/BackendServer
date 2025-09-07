using BackendServer.Data;
using BackendServer.Models.Finance;

namespace BackendServer.Types.Finance;

[MutationType]

public static class DescriptionMutation
{
     public static Description CreateDescription(FinanceDbContext dbContext, string text)
     {
          var description = new Description()
          {
               Id = Guid.NewGuid(),
               Text = text
          };
          
          dbContext.Descriptions.Add(description);
          dbContext.SaveChanges();
          
          return description;
     }

     public static Description? UpdateDescription(FinanceDbContext dbContext, Guid id, string text)
     {
          var description = dbContext.Descriptions.FirstOrDefault(description => description.Id == id);
          
          if(description is null )
          {
               return null;
          }

          description.Text = text;

          dbContext.SaveChanges();
          return description;
     }

     public static bool RemoveDescription(FinanceDbContext dbContext, Guid id)
     {
          var description = dbContext.Descriptions.FirstOrDefault(description1 => description1.Id == id);

          if (description is null)
          {
               return false;
          }

          dbContext.Descriptions.Remove(description);
          dbContext.SaveChanges();
          return true;
     }
}