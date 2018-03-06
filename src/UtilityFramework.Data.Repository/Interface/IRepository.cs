using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using UtilityFramework.Data.Repository.Models;

namespace UtilityFramework.Data.Repository.Interface
{
    public interface IRepository
    {
        T FindById<T>(string id) where T : ModelBase;
        Task<IAsyncCursor<T>> FindByIdAsync<T>(string id) where T : ModelBase;
        long Count<T>(Expression<Func<T, bool>> condition) where T : ModelBase;
    }
}