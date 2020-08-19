using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using firstDemo.Common.Abstractions;

namespace firstDemo.Common {
    public class UnitOfWork : IUnitOfWork {
        private readonly DbContext _dataContext;

        public UnitOfWork (DbContext dataContext) {
            _dataContext = dataContext;
        }

        public virtual async Task<bool> CompleteAsync () {
            var modifiedCount = await _dataContext.SaveChangesAsync ();

            return modifiedCount > 0;
        }

        public virtual bool Complete () {
            var modifiedCount = _dataContext.SaveChanges ();

            return modifiedCount > 0;
        }
    }
}