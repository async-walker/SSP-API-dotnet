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

        /// <summary>
        /// Инициализация конфигурации <see cref="SspClientOptions"/>
        /// </summary>
        /// <param name="clientCertificates">Коллекция клиентских сертификатов</param>
        /// <param name="testApi">Использование адреса для тестирования</param>
        public SspClientOptions(
            X509Certificate2Collection clientCertificates,
            bool testApi = false)
        {
            ClientCertificates = clientCertificates;
            _isTestApi = testApi;  
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
        /// Коллекция клиентских сертификатов
        /// </summary>
        public X509Certificate2Collection ClientCertificates { get; }
    }
}