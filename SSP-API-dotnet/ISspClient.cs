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
        /// <param name="source">Источник данных с подписью</param>
        /// <returns>Экземпляр <see cref="RequestResult"/> с результатом запроса</returns>
        Task<RequestResult> SendRequestAsync(Stream source);
        /// <summary>
        /// Получение отчёта
        /// </summary>
        /// <param name="answerId">Идентификатор ответа</param>
        /// <returns>Экземпляр <see cref="SspInfo"/> с информацией о сумме среднемесячных платежей</returns>
        Task<SspInfo> GetAnswerAsync(string answerId);
    }
}
