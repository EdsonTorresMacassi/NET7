using AFORO255.MS.TEST.Security.etm.Persistences;

namespace AFORO255.MS.TEST.Security.etm.Data
{
    public class DbInitializer
    {
        public static void Initialize(ContextDatabase context)
        {
            context.Database.EnsureCreated();

            if (context.Access.Any()) return;

            var orders = new Models.Access[]
            {
                new Models.Access{Username="44481918",Password="macassi"},
                new Models.Access{Username="99999999",Password="admin"},
                new Models.Access{Username="00000000",Password="root"},
            };
            foreach (Models.Access s in orders)
            {
                context.Access.Add(s);
            }
            context.SaveChanges();
        }
    }
}
