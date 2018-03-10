using MongoDB.Driver;
using System;
using System.Collections.Generic;
using UtilityFramework.Data.Repository.Interface;
using UtilityFramework.Data.Repository.Models;
using MongoDB.Driver.Builders;
using System.Linq.Expressions;
using System.Threading.Tasks;
using UtilityFramework.Data.Repository.Enuns;

namespace UtilityFramework.Data.Repository
{
    public class Repository : IRepository
    {
        public IMongoQuery _query;
        public UpdateBuilder<T> _update;
        private static BaseSettings _settingsDataBase;

        private readonly MongoDatabase _db;
        private readonly IMongoDatabase _database;

        public Repository()
        {
            _settingsDataBase = AppSettingsBase.GetSettings();

            var client = new MongoClient(ReadMongoClientSettings());
            _database = client.GetDatabase(_settingsDataBase.Database);
#pragma warning disable CS0618 // Type or member is obsolete
            var server = client.GetServer();
#pragma warning restore CS0618 // Type or member is obsolete
            _db = server.GetDatabase(_settingsDataBase.Database);
        }

        #region Connection

        /// <summary>
        /// collection off documents 
        /// </summary>
        /// <returns></returns>

        public MongoCollection<T> GetCollection<T>() where T : ModelBase
        {
            // Create instance
            var entity = Activator.CreateInstance<T>();

            // Return instance
            return _db.GetCollection<T>(entity.CollectionName);
        }
        public IMongoCollection<T> GetCollectionAsync<T>() where T : ModelBase
        {
            // Create instance
            var entity = Activator.CreateInstance<T>();
            // Return instance
            return _database.GetCollection<T>(entity.CollectionName);
        }

        #endregion
        
        #region Configuration

        /// <summary>
        /// readconfig dataclient
        /// </summary>
        /// <returns></returns>
        private MongoClientSettings ReadMongoClientSettings()
        {

            var _return = new MongoClientSettings
            {
                ConnectionMode = ConnectionMode.Automatic,
                Servers = ListServers(),
                MaxConnectionPoolSize = 250,
                MinConnectionPoolSize = 50
            };

            if (string.IsNullOrEmpty(_settingsDataBase.Password) || string.IsNullOrEmpty(_settingsDataBase.User))
                return _return;

            var mongoCredential = MongoCredential.CreateMongoCRCredential(_settingsDataBase.Database,
                _settingsDataBase.User, _settingsDataBase.Password);

            _return.Credential = mongoCredential;

            return _return;
        }

        /// <summary>
        /// get servers configuration
        /// </summary>
        /// <returns></returns>
        private IEnumerable<MongoServerAddress> ListServers()
        {
            var servers = new List<MongoServerAddress>
            {
                BaseSettings.IsDev
                    ? new MongoServerAddress(_settingsDataBase.RemoteServer, 27017)
                    : new MongoServerAddress(_settingsDataBase.LocalServer, 27017)
            };

            return servers;
        }

        MongoCollection<T> IRepository.GetCollection<T>()
        {
            throw new NotImplementedException();
        }

        string IRepository.Create<T>(T entity)
        {
            throw new NotImplementedException();
        }

        T IRepository.CreateReturn<T>(T entity)
        {
            throw new NotImplementedException();
        }

        string IRepository.Update<T>(T entity)
        {
            throw new NotImplementedException();
        }

        T IRepository.UpdateReturn<T>(T entity)
        {
            throw new NotImplementedException();
        }

        void IRepository.UpdateCondition<T>(Expression<Func<T, bool>> condition, UpdateBuilder updateBuilder)
        {
            throw new NotImplementedException();
        }

        void IRepository.DeleteOne(string id)
        {
            throw new NotImplementedException();
        }

        void IRepository.DeleteMulti(List<string> ids)
        {
            throw new NotImplementedException();
        }

        void IRepository.Delete<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        void IRepository.DisableOne(string id)
        {
            throw new NotImplementedException();
        }

        void IRepository.Disable<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        void IRepository.EnableOne(string id)
        {
            throw new NotImplementedException();
        }

        void IRepository.Enable<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        long IRepository.CountLong<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        int IRepository.Count<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        bool IRepository.CheckBy<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        T IRepository.FindById<T>(string id)
        {
            throw new NotImplementedException();
        }

        T IRepository.FindOneBy<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindAll<T>()
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindAll<T>(IMongoSortBy sortBy)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindAll<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindAll<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindAll<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby, int limit)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindBy<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindBy<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindBy<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby, int limit)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindBy<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby, int page, int limit)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindNearBy<T>(double lat, double lng, double maxDistance, string propertyName, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindNearBy<T>(double lat, double lng, double maxDistance, IMongoSortBy sortBy, string propertyName, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindNearBy<T>(double lat, double lng, double maxDistance, IMongoSortBy sortBy, int limit, string propertyName, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindNearBy<T>(double lat, double lng, double maxDistance, int limit, string propertyName, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindNearBy<T>(double lat, double lng, double maxDistance, int page, int limit, string propertyName, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindNearBy<T>(double lat, double lng, double maxDistance, IMongoSortBy sortBy, int page, int limit, string propertyName, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindByNearWithDistance<T>(double lat, double lng, double maxDistance, bool spherical, string propertyIndex, string distaceProperty, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindByNearWithDistance<T>(double lat, double lng, double maxDistance, int limit, bool spherical, string propertyIndex, string distaceProperty, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        IEnumerable<T> IRepository.FindByNearWithDistance<T>(double lat, double lng, double maxDistance, int page, int limit, bool spherical, string propertyIndex, string distaceProperty, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        IMongoCollection<T> IRepository.GetCollectionAsync<T>()
        {
            throw new NotImplementedException();
        }

        Task<string> IRepository.CreateAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository.CreateReturnAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }

        Task<string> IRepository.UpdateAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository.UpdateReturnAsync<T>(T entity)
        {
            throw new NotImplementedException();
        }

        Task IRepository.UpdateConditionAsync<T>(Expression<Func<T, bool>> condition, UpdateBuilder updateBuilder)
        {
            throw new NotImplementedException();
        }

        Task IRepository.DeleteOneAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task IRepository.DeleteMultiAsync(List<string> ids)
        {
            throw new NotImplementedException();
        }

        Task IRepository.DeleteAsync<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        Task IRepository.DisableOneAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task IRepository.DisableAsync<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        Task IRepository.EnableOneAsync(string id)
        {
            throw new NotImplementedException();
        }

        Task IRepository.EnableAsync<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        Task<long> IRepository.CountLongAsync<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        Task<int> IRepository.CountAsync<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        Task<bool> IRepository.CheckByAsync<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository.FindByIdAsync<T>(string id)
        {
            throw new NotImplementedException();
        }

        Task<T> IRepository.FindOneByAsync<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindAllAsync<T>()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindAllAsync<T>(IMongoSortBy sortBy)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindAllAsync<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindAllAsync<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindAllAsync<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby, int limit)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindByAsync<T>(Expression<Func<T, bool>> condition)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindByAsync<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindByAsync<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby, int limit)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindByAsync<T>(Expression<Func<T, bool>> condition, IMongoSortBy sortby, int page, int limit)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindNearByAsync<T>(double lat, double lng, double maxDistance, string propertyName, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindNearByAsync<T>(double lat, double lng, double maxDistance, IMongoSortBy sortBy, string propertyName, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindNearByAsync<T>(double lat, double lng, double maxDistance, IMongoSortBy sortBy, int limit, string propertyName, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindNearByAsync<T>(double lat, double lng, double maxDistance, int limit, string propertyName, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindNearByAsync<T>(double lat, double lng, double maxDistance, int page, int limit, string propertyName, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindNearByAsync<T>(double lat, double lng, double maxDistance, IMongoSortBy sortBy, int page, int limit, string propertyName, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindByNearWithDistanceAsync<T>(double lat, double lng, double maxDistance, bool spherical, string propertyIndex, string distaceProperty, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindByNearWithDistanceAsync<T>(double lat, double lng, double maxDistance, int limit, bool spherical, string propertyIndex, string distaceProperty, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<T>> IRepository.FindByNearWithDistanceAsync<T>(double lat, double lng, double maxDistance, int page, int limit, bool spherical, string propertyIndex, string distaceProperty, IEnumerable<IMongoQuery> queries, TypeMetric typeMetric)
        {
            throw new NotImplementedException();
        }

        #endregion





        //public async Task<IAsyncCursor<T>> FindByIdAsync<T>(string id) where T : ModelBase
        //{
        //    throw new NotImplementedException();
        //}

        //public string Create<T>(T entity) where T : ModelBase
        //{
        //    try
        //    {
        //        GetCollection<T>().Save(entity);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Registro não gerado", ex);
        //    }
        //    if (entity._id == ObjectId.Empty)
        //        throw new Exception("Registro não gerado");

        //    return entity._id.ToString();
        //}

        //public async Task<string> CreateAsync<T>(T entity) where T : ModelBase
        //{
        //    throw new NotImplementedException();
        //}

        //public string CreateReturn<T>(T entity) where T : ModelBase
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<string> CreateReturnAsync<T>(T entity) where T : ModelBase
        //{
        //    throw new NotImplementedException();

        //}

        //public long Count<T>(Expression<Func<T, bool>> condition) where T : ModelBase
        //{
        //    throw new NotImplementedException();
        //}
    }
}