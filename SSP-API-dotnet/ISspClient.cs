using CryptoPro.Adapter.CryptCP.Types;
using SSP_API.Types.Xsd;

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
        /// <param name="signCriterias">КПС для подписи сообщения на получение информации об СПП</param>
        /// <param name="delSignCriterias">КПС для снятия подписи с ответа бюро</param>
        /// <returns>Экземпляр <see cref="RequestResult"/> с результатом запроса</returns>
        Task<RequestResult> SendRequestAsync(
            SspRequest sspRequest, 
            string directoryToSaveFiles,
            CriteriasSearchCertificates signCriterias,
            CriteriasSearchCertificates delSignCriterias);
        /// <summary>
        /// Получение отчёта
        /// </summary>
        /// <param name="answerId">Идентификатор ответа</param>
        /// <param name="directoryToSaveFiles">Директория сохранения файлов, необходимых и получаемых при обмене с бюро</param>
        /// <param name="delSignCriterias">КПС для снятия подписи с ответа бюро</param>
        /// <returns>Экземпляр <see cref="SspInfo"/> с информацией о сумме среднемесячных платежей</returns>
        Task<SspInfo> GetAnswerAsync(
            string answerId,
            string directoryToSaveFiles,
            CriteriasSearchCertificates delSignCriterias);
    }
}
