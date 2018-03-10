using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using UtilityFramework.Data.Repository.Enuns;
using UtilityFramework.Data.Repository.Models;

namespace UtilityFramework.Data.Repository.Interface
{
    public interface IRepository
    {
        #region Sync

        MongoCollection<T> GetCollection<T>() where T : ModelBase;
        string Create<T>(T entity) where T : ModelBase;
        T CreateReturn<T>(T entity) where T : ModelBase;
        string Update<T>(T entity) where T : ModelBase;
        T UpdateReturn<T>(T entity) where T : ModelBase;
        void UpdateCondition<T>(Expression<Func<T, bool>> condition, UpdateBuilder updateBuilder) where T : ModelBase;
        void DeleteOne(string id);
        void DeleteMulti(List<string> ids);
        void Delete<T>(Expression<Func<T, bool>> condition) where T : ModelBase;
        void DisableOne(string id);
        void Disable<T>(Expression<Func<T, bool>> condition) where T : ModelBase;
        void EnableOne(string id);
        void Enable<T>(Expression<Func<T, bool>> condition) where T : ModelBase;
        long CountLong<T>(Expression<Func<T, bool>> condition) where T : ModelBase;
        int Count<T>(Expression<Func<T, bool>> condition) where T : ModelBase;
        bool CheckBy<T>(Expression<Func<T, bool>> condition) where T : ModelBase;
        T FindById<T>(string id) where T : ModelBase;
        T FindOneBy<T>(Expression<Func<T, bool>> condition) where T : ModelBase;
        IEnumerable<T> FindAll<T>();
        IEnumerable<T> FindAll<T>(IMongoSortBy sortBy);
        IEnumerable<T> FindAll<T>(Expression<Func<T, bool>> condition);
        IEnumerable<T> FindAll<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby);
        IEnumerable<T> FindAll<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby, int limit = 30);
        IEnumerable<T> FindBy<T>(Expression<Func<T, bool>> condition);
        IEnumerable<T> FindBy<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby);
        IEnumerable<T> FindBy<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby, int limit = 30);
        IEnumerable<T> FindBy<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby, int page, int limit = 30);
        IEnumerable<T> FindNearBy<T>(double lat, double lng, double maxDistance, string propertyName = "Location", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        IEnumerable<T> FindNearBy<T>(double lat, double lng, double maxDistance, IMongoSortBy sortBy, string propertyName = "Location", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        IEnumerable<T> FindNearBy<T>(double lat, double lng, double maxDistance, IMongoSortBy sortBy, int limit = 30, string propertyName = "Location", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        IEnumerable<T> FindNearBy<T>(double lat, double lng, double maxDistance, int limit = 30, string propertyName = "Location", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        IEnumerable<T> FindNearBy<T>(double lat, double lng, double maxDistance, int page, int limit = 30, string propertyName = "Location", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        IEnumerable<T> FindNearBy<T>(double lat, double lng, double maxDistance, IMongoSortBy sortBy, int page, int limit = 30, string propertyName = "Location", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        IEnumerable<T> FindByNearWithDistance<T>(double lat, double lng, double maxDistance, bool spherical = true, string propertyIndex = "Location", string distaceProperty = "Distance", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        IEnumerable<T> FindByNearWithDistance<T>(double lat, double lng, double maxDistance, int limit = 30, bool spherical = true, string propertyIndex = "Location", string distaceProperty = "Distance", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        IEnumerable<T> FindByNearWithDistance<T>(double lat, double lng, double maxDistance, int page, int limit = 30, bool spherical = true, string propertyIndex = "Location", string distaceProperty = "Distance", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);

        #endregion

        #region Async

        IMongoCollection<T> GetCollectionAsync<T>() where T : ModelBase;
        Task<string> CreateAsync<T>(T entity) where T : ModelBase;
        Task<T> CreateReturnAsync<T>(T entity) where T : ModelBase;
        Task<string> UpdateAsync<T>(T entity) where T : ModelBase;
        Task<T> UpdateReturnAsync<T>(T entity) where T : ModelBase;
        Task UpdateConditionAsync<T>(Expression<Func<T, bool>> condition, UpdateBuilder updateBuilder) where T : ModelBase;
        Task DeleteOneAsync(string id);
        Task DeleteMultiAsync(List<string> ids);
        Task DeleteAsync<T>(Expression<Func<T, bool>> condition) where T : ModelBase;
        Task DisableOneAsync(string id);
        Task DisableAsync<T>(Expression<Func<T, bool>> condition) where T : ModelBase;
        Task EnableOneAsync(string id);
        Task EnableAsync<T>(Expression<Func<T, bool>> condition) where T : ModelBase;
        Task<long> CountLongAsync<T>(Expression<Func<T, bool>> condition) where T : ModelBase;
        Task<int> CountAsync<T>(Expression<Func<T, bool>> condition) where T : ModelBase;
        Task<bool> CheckByAsync<T>(Expression<Func<T, bool>> condition) where T : ModelBase;
        Task<T> FindByIdAsync<T>(string id) where T : ModelBase;
        Task<T> FindOneByAsync<T>(Expression<Func<T, bool>> condition) where T : ModelBase;
        Task<IEnumerable<T>> FindAllAsync<T>();
        Task<IEnumerable<T>> FindAllAsync<T>(IMongoSortBy sortBy);
        Task<IEnumerable<T>> FindAllAsync<T>(Expression<Func<T, bool>> condition);
        Task<IEnumerable<T>> FindAllAsync<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby);
        Task<IEnumerable<T>> FindAllAsync<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby, int limit = 30);
        Task<IEnumerable<T>> FindByAsync<T>(Expression<Func<T, bool>> condition);
        Task<IEnumerable<T>> FindByAsync<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby);
        Task<IEnumerable<T>> FindByAsync<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby, int limit = 30);
        Task<IEnumerable<T>> FindByAsync<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby, int page, int limit = 30);
        Task<IEnumerable<T>> FindNearByAsync<T>(double lat, double lng, double maxDistance, string propertyName = "Location", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        Task<IEnumerable<T>> FindNearByAsync<T>(double lat, double lng, double maxDistance, IMongoSortBy sortBy, string propertyName = "Location", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        Task<IEnumerable<T>> FindNearByAsync<T>(double lat, double lng, double maxDistance, IMongoSortBy sortBy, int limit = 30, string propertyName = "Location", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        Task<IEnumerable<T>> FindNearByAsync<T>(double lat, double lng, double maxDistance, int limit = 30, string propertyName = "Location", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        Task<IEnumerable<T>> FindNearByAsync<T>(double lat, double lng, double maxDistance, int page, int limit = 30, string propertyName = "Location", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        Task<IEnumerable<T>> FindNearByAsync<T>(double lat, double lng, double maxDistance, IMongoSortBy sortBy, int page, int limit = 30, string propertyName = "Location", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        Task<IEnumerable<T>> FindByNearWithDistanceAsync<T>(double lat, double lng, double maxDistance, bool spherical = true, string propertyIndex = "Location", string distaceProperty = "Distance", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        Task<IEnumerable<T>> FindByNearWithDistanceAsync<T>(double lat, double lng, double maxDistance, int limit = 30, bool spherical = true, string propertyIndex = "Location", string distaceProperty = "Distance", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);
        Task<IEnumerable<T>> FindByNearWithDistanceAsync<T>(double lat, double lng, double maxDistance, int page, int limit = 30, bool spherical = true, string propertyIndex = "Location", string distaceProperty = "Distance", IEnumerable<IMongoQuery> queries = null, TypeMetric typeMetric = TypeMetric.KILOMETERS);


        #endregion

    }
}