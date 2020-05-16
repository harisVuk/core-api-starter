using System.Collections.Generic;
using Demo.Core.IRepository;
using Demo.Data.DAL;
using Demo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Core.Repository
{
    public class NewsRepository : INewsRepository
    {
       #region Fields
            private DemoContext _context;
       #endregion Fields

       #region Constructor

            public NewsRepository(DemoContext context)
            {
                _context = context;
            }   

        #endregion Constructor

       #region Methods

            public IEnumerable<News> GetAll() 
            {
                return _context.News.Include(x=> x.User);
            }

        #endregion Methods
    }
}