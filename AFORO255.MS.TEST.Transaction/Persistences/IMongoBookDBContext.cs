using MongoDB.Driver;

namespace AFORO255.MS.TEST.Transaction.etm.Persistences
{
    public interface IMongoBookDBContext
    {
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
