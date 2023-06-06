using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.IRepositories
{
    public interface INhanVienRepositories<T>
    {
        public IEnumerable<T> GetAllItem();
        T GetById(Guid id);
        public bool CreateItem(T item);
        public bool DeleteItem(T item);
        public bool UpdateItem(T item);
    }
}
