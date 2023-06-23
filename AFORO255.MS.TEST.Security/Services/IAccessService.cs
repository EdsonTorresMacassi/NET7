using AFORO255.MS.TEST.Security.etm.Models;

namespace AFORO255.MS.TEST.Security.etm.Services
{
    public interface IAccessService
    {
        IEnumerable<Access> GetAll();
        bool Validate(string userName, string password);
    }
}
