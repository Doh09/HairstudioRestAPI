using System.Collections.Generic;
using HSRestAPI_DLL.DB;
using HSRestAPI_DLL.Entities;

namespace HSRestAPI_DLL.Interfaces
{
    public interface IRepository<T> where T : IEntity
    {
        /// <summary>
        /// Method where the HairstudioDBContext used by this repository is set.
        /// </summary>
        /// <param name="ctx"></param>
        void SetContext(HairstudioDBContext ctx);
        /// <summary>
        /// Get a list of all objects the Repository holds.
        /// </summary>
        /// <returns></returns>
        IList<T> GetAll();

        /// <summary>
        /// Get a single object, based on its ID.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

        /// <summary>
        /// Remove an object from the Repositorys list.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        bool Remove(T t);

        /// <summary>
        /// Update/Replace objects in the Repositorys list, that have the same ID as the given object.
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        T Update(T t);

        /// <summary>
        /// Create an object in the Repository, this allows the Repository to handle ID creation.
        /// Will also automatically call the 'Add()' method to add the object created to the Repositorys list.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        T Create(T t);
    }
}

