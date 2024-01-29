using System.Net;
using System.Security.Cryptography.X509Certificates;

namespace SSP_API
{
    /// <summary>
    /// Конфигурация для <see cref="ISspClient"/>
    /// </summary>
    public class SspClientOptions
    {
        const string baseUrl = "https://ssp.bki-okb.com/";
        const string baseUrlTest = "https://ssptest.bki-okb.com/";

        private readonly bool _isTestApi;
        private readonly string _username;
        private readonly string _password;

        /// <summary>
        /// Инициализация конфигурации <see cref="SspClientOptions"/>
        /// </summary>
        /// <param name="username">Имя пользователя</param>
        /// <param name="password">Пароль учетной записи</param>
        /// <param name="clientCertificates">Коллекция клиентских сертификатов</param>
        /// <param name="testApi">Использование адреса для тестирования</param>
        public SspClientOptions(
            string username, 
            string password, 
            X509Certificate2Collection clientCertificates,
            bool testApi = false)
        {
            ClientCertificates = clientCertificates;
            _isTestApi = testApi;   
            _username = username;
            _password = password;
        }

        /// <summary>
        /// Адрес API
        /// </summary>
        public string ApiAddress
        {
            get
            {
                if (_isTestApi)
                    return baseUrlTest;
                else return baseUrl;
            }
        }

        /// <summary>
        /// Учетные данные
        /// </summary>
        public NetworkCredential Credential
        {
            get
            {
                return new NetworkCredential(_username, _password);
            }
        }

        /// <summary>
        /// Коллекция клиентских сертификатов
        /// </summary>
        public X509Certificate2Collection ClientCertificates { get; }
    }
}