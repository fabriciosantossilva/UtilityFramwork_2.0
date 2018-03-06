namespace UtilityFramework.Data.Repository
{
    public class BaseSettings
    {
        /// <summary>
        /// NOME DO BANCO DE DADOS
        /// </summary>
        public string DATABASE { get; set; }
        /// <summary>
        /// USER (OPTIONAL)
        /// </summary>
        public string USER { get; set; }
        /// <summary>
        /// PASSWORD (OPTIONAL)
        /// </summary>
        public string PASSWORD { get; set; }
        /// <summary>
        /// IP BANCO REMOTO 
        /// </summary>
        public string REMOTE_SERVER { get; set; }
        /// <summary>
        /// IP BANCO LOCAL
        /// </summary>
        public string LOCAL_SERVER { get; set; }
        /// <summary>
        /// SELECT USE LOCAL / REMOTE IP
        /// </summary>
        public static bool IS_DEV { get; set; }

    }



}