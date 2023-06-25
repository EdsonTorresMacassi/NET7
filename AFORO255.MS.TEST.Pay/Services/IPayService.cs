using AFORO255.MS.TEST.Pay.etm.Models;

namespace AFORO255.MS.TEST.Pay.etm.Services
{
    public interface IPayService
    {
        IEnumerable<PayModel> GetAll();
        PayModel Pay(PayModel transaction);
    }
}
