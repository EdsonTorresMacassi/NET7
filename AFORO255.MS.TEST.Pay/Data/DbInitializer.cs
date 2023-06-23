using AFORO255.MS.TEST.Pay.etm.Persistences;

namespace AFORO255.MS.TEST.Pay.etm.Data
{
    public class DbInitializer
    {
        public static void Initialize(ContextDatabase context)
        {
            context.Database.EnsureCreated();
            context.SaveChanges();
        }
    }
}
