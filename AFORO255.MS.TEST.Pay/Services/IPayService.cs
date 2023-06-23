using AFORO255.MS.TEST.Pay.etm.Models;

namespace AFORO255.MS.TEST.Pay.etm.Services
{
    public interface IPayService
    {
        PayModel Pay(PayModel transaction);
    }
}
