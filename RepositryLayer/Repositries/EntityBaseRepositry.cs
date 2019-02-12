using DATALayer.Domain;
using DATALayer.Infrastucture;
using RepositryLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RepositryLayer.Repositries
{

    //Base Repositry for common type of request <Generic>
    public class EntityBaseRepositry<T>: IEntityBaseRepositry<T> where T : class, new()
    {
        public EntityBaseRepositry(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }


        private EmahaSchoolEntities dataContext;

     
        //property of idbset type
        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected EmahaSchoolEntities DbContext
        {
            get { return dataContext ?? (dataContext = DbFactory.Init()); }
        }
       
        
        //generic method to save all type of data in tables//
     
        public void Save(T entity)
        {
            DbContext.Set<T>().Add(entity);
        }

        //generic method to get List of all kind of data 
        public IQueryable<T> GetAll()
        {
           return DbContext.Set<T>();
        }

        //Generic method to perform searching sorting and pagination
        public IQueryable<T> GetDataList(string search, int page, int itemsPerPage = 5, string sortBy = " ")
        {
           return DbContext.Set<T>().AsQueryable();
        }     
    }
}
