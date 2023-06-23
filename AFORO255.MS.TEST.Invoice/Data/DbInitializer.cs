using AFORO255.MS.TEST.Invoice.etm.Persistences;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Invoice.etm.Data
{
    public class DbInitializer
    {
        public static void Initialize(ContextDatabase context)
        {
            context.Database.EnsureCreated();

            if (context.Invoice.Any()) return;

            var invoices = new Models.InvoiceModel[]
            {
                new Models.InvoiceModel{Amount = 3000, State = 1},
                new Models.InvoiceModel{Amount = 4500, State = 1},
                new Models.InvoiceModel{Amount = 750, State = 1},
                new Models.InvoiceModel{Amount = 8000, State = 1},
                new Models.InvoiceModel{Amount = 15000, State = 1},
                new Models.InvoiceModel{Amount = 10000, State = 1},
                new Models.InvoiceModel{Amount = 50000, State = 1},
                new Models.InvoiceModel{Amount = 130000, State = 1}
            };

            foreach (Models.InvoiceModel registro in invoices)
            {
                context.Invoice.Add(registro);
            }

            context.SaveChanges();
        }
    }
}