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
        /// <returns></returns>
        Task<RequestResult> SendRequestAsync(SspRequest sspRequest);
        /// <summary>
        /// Получение отчёта
        /// </summary>
        /// <param name="answerId">Идентификатор ответа</param>
        /// <returns></returns>
        Task<SspInfo> GetAnswerAsync(string answerId);
    }
}
