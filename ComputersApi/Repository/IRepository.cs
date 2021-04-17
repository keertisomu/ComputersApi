using ComputersApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ComputersApi.Repository
{
    public interface IRepository<T>
    {
        IList<T> Get();

        T Create();

        void Update(T t);
    }
}
