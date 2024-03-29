using CryptoPro.Adapter.CryptCP.Types;
using SSP_API.Types.Xsd;
using System.Security.Cryptography.X509Certificates;

namespace SSP_API
{
    /// <summary>
    /// Интерфейс для взаимодействия с API
    /// </summary>
    public interface ISspClient
    {
        /// <summary>
        /// Направление запроса на получение ССП
        /// </summary>
        /// <param name="sspRequest">Запрос с запрашиваемыми данными на поиск СПП</param>
        /// <param name="directoryToSaveFiles">Директория сохранения файлов, необходимых и получаемых при обмене с бюро</param>
        /// <param name="thumbprint">Отпечаток сертификата для подписи</param>
        /// <param name="storeName">Наименование хранилища сертификата</param>
        /// <param name="storeLocation">Расположение хранилища сертификата</param>
        /// <returns>Экземпляр <see cref="RequestResult"/> с результатом запроса</returns>
        Task<RequestResult> SendRequestAsync(
            SspRequest sspRequest, 
            string directoryToSaveFiles,
            string thumbprint,
            StoreName storeName = StoreName.My,
            StoreLocation storeLocation = StoreLocation.CurrentUser);
        /// <summary>
        /// Получение отчёта
        /// </summary>
        /// <param name="answerId">Идентификатор ответа</param>
        /// <param name="directoryToSaveFiles">Директория сохранения файлов, необходимых и получаемых при обмене с бюро</param>
        /// <returns>Экземпляр <see cref="SspInfo"/> с информацией о сумме среднемесячных платежей</returns>
        Task<SspInfo> GetAnswerAsync(
            string answerId,
            string directoryToSaveFiles);
    }
}
