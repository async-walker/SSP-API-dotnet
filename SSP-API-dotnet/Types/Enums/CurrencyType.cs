using System.Xml.Serialization;

namespace SSP_API.Types.Enums
{
    /// <summary>
    /// Общероссийский классификатор валют
    /// </summary>
    public enum CurrencyType
    {
        /// <summary>
        /// Юань
        /// </summary>
        [XmlEnum(Name = nameof(CNY))]
        CNY = 156,
        /// <summary>
        /// Российский рубль
        /// </summary>
        [XmlEnum(Name = nameof(RUB))]
        RUB = 643,
        /// <summary>
        /// Доллар США
        /// </summary>
        [XmlEnum(Name = nameof(USD))]
        USD = 840,
        /// <summary>
        /// Евро
        /// </summary>
        [XmlEnum(Name = nameof(EUR))]
        EUR = 978
    }
}
