using ForumDocument.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Services
{
    public class BaseService<T> : IBaseService<T>
    {

        public BaseService()
        {

        }

        public IQueryable<T> GetAll()
        {
            return null;
        }
    }
}
