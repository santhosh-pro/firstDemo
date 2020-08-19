using System.Threading.Tasks;

namespace firstDemo.Common.Abstractions {
    public interface IUnitOfWork {
        Task<bool> CompleteAsync ();
        bool Complete ();
    }
}