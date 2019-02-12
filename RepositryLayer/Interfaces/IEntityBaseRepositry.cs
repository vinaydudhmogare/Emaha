using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositryLayer.Interfaces
{
    public interface IEntityBaseRepositry<T> where T:class,new()
    {
        void Save(T entity);

        IQueryable<T> GetAll();

        IQueryable<T> GetDataList(string search, int page, int itemsPerPage = 5, string sortBy = " ");

    }
}
