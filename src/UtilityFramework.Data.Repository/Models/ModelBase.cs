using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UtilityFramework.Data.Repository.Models {
    [BsonIgnoreExtraElements]
    public abstract class ModelBase {
        
        protected ModelBase () {
            Created = DateTimeOffset.Now.ToUnixTimeSeconds ();
        }

        /// <summary>
        /// Collection on Database
        /// </summary>
        public abstract string CollectionName { get; }

        /// <summary>
        /// Identification
        /// </summary>
        public ObjectId _id { get; set; }

        /// <summary>
        /// Flag delete
        /// </summary>
        public long? Disabled { get; set; }
        /// <summary>
        /// date register
        /// </summary>
        /// <returns></returns>
        public long? Created { get; set; }

        /// <summary>
        /// last update object
        /// </summary>
        /// <returns></returns>
        public long? LastUpdate { get; set; }
    }
}