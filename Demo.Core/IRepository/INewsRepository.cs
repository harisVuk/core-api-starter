using System.Collections.Generic;
using Demo.Data.Models;

namespace Demo.Core.IRepository
{
    public interface INewsRepository
    {
        IEnumerable<News> GetAll();
    }
}