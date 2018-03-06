using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Driver.Linq;
using UtilityFramework.Data.Repository.Interface;
using UtilityFramework.Data.Repository.Models;

namespace UtilityFramework.Data.Repository
{
    public class Repository : IRepository
    {
        public IMongoQuery _query;
        //public UpdateBuilder<T> _update;
        private static BaseSettings _settingsDataBase;

        private readonly MongoDatabase _db;
        private readonly IMongoDatabase _database;

        public Repository()
        {
            _settingsDataBase = AppSettingsBase.GetSettings();

            var client = new MongoClient(ReadMongoClientSettings());
            _database = client.GetDatabase(_settingsDataBase.DATABASE);
#pragma warning disable CS0618 // Type or member is obsolete
            var server = client.GetServer();
#pragma warning restore CS0618 // Type or member is obsolete
            _db = server.GetDatabase(_settingsDataBase.DATABASE);
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

            if (string.IsNullOrEmpty(_settingsDataBase.PASSWORD) || string.IsNullOrEmpty(_settingsDataBase.USER))
                return _return;

            var mongoCredential = MongoCredential.CreateMongoCRCredential(_settingsDataBase.DATABASE,
                _settingsDataBase.USER, _settingsDataBase.PASSWORD);

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
                BaseSettings.IS_DEV
                    ? new MongoServerAddress(_settingsDataBase.REMOTE_SERVER, 27017)
                    : new MongoServerAddress(_settingsDataBase.LOCAL_SERVER, 27017)
            };

            return servers;
        }


        #endregion

        public T FindById<T>(string id) where T : ModelBase
        {
            throw new NotImplementedException();
        }

        public async Task<IAsyncCursor<T>> FindByIdAsync<T>(string id) where T : ModelBase
        {
            throw new NotImplementedException();
        }

        public long Count<T>(Expression<Func<T, bool>> condition) where T : ModelBase
        {
            throw new NotImplementedException();
        }
    }
}