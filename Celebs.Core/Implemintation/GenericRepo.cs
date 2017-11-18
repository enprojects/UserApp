
using System;
using System.Collections.Generic;
using System.Linq;
using DAL;
using Application.Inetrface;

namespace Application.Implemintation
{
    public class GenericRepo<T> : IGenericRepo<T>
        where T : class
    {

        #region Properties
        private static IList<T> genericList;
        public static IList<T> GenericList
        {
            get
            {
                return genericList;
            }

            private set
            {
                genericList = value;
            }

        }
        #endregion
        #region ctors
        public GenericRepo()
        {
            genericList = genericList ?? FileStreamer<IList<T>>.GetJsonDataFromFile();

        }
        #endregion
        #region Interface method
        public IEnumerable<T> Get(Func<T, bool> func = null)
        {
            if (func != null)
            {
                return GenericList.Where(func);
            }

            return GenericList;
        }
        public bool Add(T obj)
        {
            GenericList.Add(obj);
            return Save();
        }
        public bool Remove(Func<T, bool> func)
        {
            var result = FindIndexElement(func);
            {
                if (result > -1)
                {
                    GenericList.RemoveAt(result);
                    return Save();
                }
            }
            return false;
        }
        public bool Update(Func<T, bool> func, T newObj)
        {
            var originCeleb = GenericList.FirstOrDefault(func);
            if (newObj != null)
            {
                var result = FindIndexElement(func);

                if (result > -1)
                {
                    GenericList[result] = newObj;
                }

                return Save();
            }

            return false;
        }

        #endregion
        #region private method
        private int FindIndexElement(Func<T, bool> func)
        {

            return GenericList.ToList().FindIndex(new Predicate<T>(func));
        }
        private bool Save()
        {

            return FileStreamer<IList<T>>.SaveJsonObjectToFile(GenericList);
        }
        #endregion
    }
}


