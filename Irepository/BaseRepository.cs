using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Irepository
{
  public  interface BaseRepository<T> where T:class
    {
        Task<T> AddDetails( T entity);

    }
}
