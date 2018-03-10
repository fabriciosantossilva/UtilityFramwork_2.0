using Newtonsoft.Json;

namespace UtilityFramework.Data.Repository
{
    public class BaseSettings
    {
        /// <summary>
        /// NOME DO BANCO DE DADOS
        /// </summary>
        [JsonProperty("DATABASE")]
        public string Database { get; set; }
        /// <summary>
        /// USER (OPTIONAL)
        /// </summary>
        [JsonProperty("USER")]
        public string User { get; set; }
        /// <summary>
        /// PASSWORD (OPTIONAL)
        /// </summary>
        [JsonProperty("PASSWORD")]

        public string Password { get; set; }
        /// <summary>
        /// IP BANCO REMOTO 
        /// </summary>
        [JsonProperty("REMOTE")]

        public string RemoteServer { get; set; }
        /// <summary>
        /// IP BANCO LOCAL
        /// </summary>
        [JsonProperty("LOCAL")]

        public string LocalServer { get; set; }
        /// <summary>
        /// SELECT USE LOCAL / REMOTE IP
        /// </summary>
        public static bool IsDev { get; set; }

    }



}