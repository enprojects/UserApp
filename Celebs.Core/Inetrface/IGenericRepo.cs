using System;
using System.Collections.Generic;

namespace Application.Inetrface

{
    public interface IGenericRepo<T>
    {
        IEnumerable<T> Get(Func<T, bool> func);
        bool Add(T obj);
        bool Remove(Func<T, bool> func);
        bool Update(Func<T, bool> func, T newObj);


    }
}