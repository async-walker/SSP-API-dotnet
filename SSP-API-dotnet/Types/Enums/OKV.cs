using System.Xml.Serialization;

namespace SSP_API.Types.Enums
{
    /// <summary>
    /// Общероссийский классификатор валют
    /// </summary>
    public enum OKV
    {
        /// <summary>
        /// Юань
        /// </summary>
        [XmlEnum("156")]
        CNY,
        /// <summary>
        /// Тенге
        /// </summary>
        [XmlEnum("398")]
        KZT,
        /// <summary>
        /// Сом
        /// </summary>
        [XmlEnum("417")]
        KGS,
        /// <summary>
        /// Российский рубль
        /// </summary>
        [XmlEnum("643")] 
        RUB,
        /// <summary>
        /// Доллар США
        /// </summary>
        [XmlEnum("840")] 
        USD,
        /// <summary>
        /// Узбекский сум
        /// </summary>
        [XmlEnum("860")] 
        UZS,
        /// <summary>
        /// Евро
        /// </summary>
        [XmlEnum("978")] 
        EUR
    }
}
