using ForumDocument.Entities.DatabaseContext;
using ForumDocument.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForumDocument.Services
{
    public class BaseService : IBaseService
    {
        protected readonly DataContext _context;
        protected readonly IAuthService _authenService;

        public BaseService(DataContext context, IAuthService authService)
        {
            _context = context;
            _authenService = authService;
        }

        public IQueryable GetAll()
        {
            return null;
        }
    }
}
