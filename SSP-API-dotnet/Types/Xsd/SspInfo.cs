//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 2.1.963.0 using the following command:
// xscgen -n SSP_API.Types.Xsd C:\schemas\bki_api_sch\qcb_answer.xsd
using SSP_API.Extensions;
using System.ComponentModel.DataAnnotations;

namespace SSP_API.Types.Xsd
{
    
    
    /// <summary>
    /// <para>Сведения о среднемесячных платежах</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute("Сведения о среднемесячных платежах")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.1.963.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("СведенияОПлатежах", Namespace="", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlRootAttribute("СведенияОПлатежах", Namespace="")]
    public partial class SspInfo
    {
         
        /// <summary>
        /// <para>Титульная часть ответа</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Титульная часть ответа")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("ТитульнаяЧасть")]
        public SSP_API.Types.Xsd.SubjectInfo TitlePart { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<PaymentsInfoKbki> _kbki;
        
        /// <summary>
        /// <para>КБКИ - источник информации.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("КБКИ - источник информации.")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("КБКИ")]
        public System.Collections.ObjectModel.Collection<PaymentsInfoKbki> Kbki
        {
            get
            {
                return _kbki;
            }
            private set
            {
                _kbki = value;
            }
        }
        
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="SspInfo" /> class.</para>
        /// </summary>
        public SspInfo()
        {
            this._kbki = new System.Collections.ObjectModel.Collection<PaymentsInfoKbki>();
        }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private string _version = "1.2";
        
        /// <summary>
        /// <para>Версия схемы</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Версия схемы")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlAttributeAttribute("Версия")]
        public string Version
        {
            get
            {
                return _version;
            }
            set
            {
                _version = value;
            }
        }
        
        /// <summary>
        /// <para>Идентификатор запроса, в ответ на который подготовлен данный ответ</para>
        /// <para>Уникальный идентификатор</para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 255.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Идентификатор запроса, в ответ на который подготовлен данный ответ")]
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(255)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlAttributeAttribute("ИдентификаторЗапроса")]
        public string RequestId { get; set; }

        /// <summary>
        /// <para>Уникальный идентификатор ответа</para>
        /// <para>Уникальный идентификатор</para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 255.</para>
        /// </summary>
        [Display(Name = "Уникальный идентификатор ответа")]
        [System.ComponentModel.DescriptionAttribute("Уникальный идентификатор ответа")]
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(255)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlAttributeAttribute("ИдентификаторОтвета")]
        public string AnswerId { get; set; }

        /// <summary>
        /// <para>ОГРН КБКИ сформировавшего ответ</para>
        /// <para>Основной государственный регистрационный номер юридического лица</para>
        /// <para xml:lang="en">Pattern: \d{13}.</para>
        /// </summary>
        [Display(Name = "ОГРН КБКИ сформировавшего ответ")]
        [System.ComponentModel.DescriptionAttribute("ОГРН КБКИ сформировавшего ответ")]
        [System.ComponentModel.DataAnnotations.RegularExpressionAttribute("\\d{13}")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlAttributeAttribute("ОГРН")]
        public string Ogrn { get; set; }

        /// <summary>
        /// <para>Тип ответа</para>
        /// </summary>
        [Display(Name = "Тип ответа")]
        [System.ComponentModel.DescriptionAttribute("Тип ответа")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlAttributeAttribute("ТипОтвета")]
        public PaymentsInfoAnswerType AnswerType { get; set; }

        /// <summary>
        /// Десериализация XML
        /// </summary>
        /// <param name="xml">Данные XML</param>
        /// <returns>Экземпляр <see cref="SspInfo"/></returns>
        public SspInfo Deserialize(string xml)
        {
            var sspInfo = xml.DeserializeXml<SspInfo>();

            return sspInfo;
        }
    }

    /// <summary>
    /// <para>КБКИ - источник информации.</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.1.963.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("СведенияОПлатежахКбки", Namespace="", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PaymentsInfoKbki
    {
        
        /// <summary>
        /// <para>Описание ошибки</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Описание ошибки")]
        [System.Xml.Serialization.XmlElementAttribute("Ошибка")]
        public PaymentsInfoKbkiError Error { get; set; }
        
        /// <summary>
        /// <para>Субъект в соответствующем КБКИ не найден</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Субъект в соответствующем КБКИ не найден")]
        [System.Xml.Serialization.XmlElementAttribute("СубъектНеНайден")]
        public object SubjectNotFound { get; set; }
        
        /// <summary>
        /// <para>В КБКИ отсутсвует информация о действующих обязательствах</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("В КБКИ отсутсвует информация о действующих обязательствах")]
        [System.Xml.Serialization.XmlElementAttribute("ОбязательствНет")]
        public object NoObligations { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<PaymentsInfoKbkiObligationsBki> _obligations;
        
        /// <summary>
        /// <para>Действующие обязательства субъекта</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Действующие обязательства субъекта")]
        [System.Xml.Serialization.XmlArrayAttribute("Обязательства")]
        [System.Xml.Serialization.XmlArrayItemAttribute("БКИ")]
        public System.Collections.ObjectModel.Collection<PaymentsInfoKbkiObligationsBki> Obligations
        {
            get
            {
                return _obligations;
            }
            private set
            {
                _obligations = value;
            }
        }
        
        /// <summary>
        /// <para xml:lang="en">Gets a value indicating whether the Обязательства collection is empty.</para>
        /// </summary>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ObligationsSpecified
        {
            get
            {
                return (this.Obligations.Count != 0);
            }
        }
        
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="PaymentsInfoKbki" /> class.</para>
        /// </summary>
        public PaymentsInfoKbki()
        {
            this._obligations = new System.Collections.ObjectModel.Collection<PaymentsInfoKbkiObligationsBki>();
        }

        /// <summary>
        /// <para>ОГРН КБКИ - источника информации</para>
        /// </summary>
        [Display(Name = "ОГРН КБКИ - источника информации")]
        [System.ComponentModel.DescriptionAttribute("ОГРН КБКИ - источника информации")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlAttributeAttribute("ОГРН")]
        public string Ogrn { get; set; }

        /// <summary>
        /// <para>Дата и время по состоянию на которые подготовлен ответ</para>
        /// </summary>
        [Display(Name = "Дата и время по состоянию на которые подготовлен ответ")]
        [System.ComponentModel.DescriptionAttribute("Дата и время по состоянию на которые подготовлен ответ")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlAttributeAttribute("ПоСостояниюНа", DataType="dateTime")]
        public System.DateTime At { get; set; }
        
        /// <summary>
        /// <para>Идентификатор ответа КБКИ - источника информации</para>
        /// <para>Уникальный идентификатор</para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 255.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Идентификатор ответа КБКИ - источника информации")]
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(255)]
        [System.Xml.Serialization.XmlAttributeAttribute("ИдентификаторОтвета")]
        public string AnswerId { get; set; }
    }

    /// <summary>
    /// <para>Описание ошибки</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.1.963.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("СведенияОПлатежахКбкиОшибка", Namespace="")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PaymentsInfoKbkiError
    {
        
        /// <summary>
        /// <para xml:lang="en">Gets or sets the text value.</para>
        /// </summary>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value { get; set; }
        
        /// <summary>
        /// <para>Код ошибки</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Код ошибки")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlAttributeAttribute("Код")]
        public string Code { get; set; }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.1.963.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("СведенияОПлатежахКбкиОбязательства", Namespace="", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PaymentsInfoKbkiObligations
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<PaymentsInfoKbkiObligationsBki> _bki;
        
        /// <summary>
        /// <para>БКИ - источник информации</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("БКИ - источник информации")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("БКИ")]
        public System.Collections.ObjectModel.Collection<PaymentsInfoKbkiObligationsBki> Bki
        {
            get
            {
                return _bki;
            }
            private set
            {
                _bki = value;
            }
        }
        
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="PaymentsInfoKbkiObligations" /> class.</para>
        /// </summary>
        public PaymentsInfoKbkiObligations()
        {
            this._bki = new System.Collections.ObjectModel.Collection<PaymentsInfoKbkiObligationsBki>();
        }
    }

    /// <summary>
    /// <para>Действующие обязательства субъекта</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.1.963.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("СведенияОПлатежахКбкиОбязательстваБки", Namespace="", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PaymentsInfoKbkiObligationsBki
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<PaymentsInfoKbkiObligationsBkiContract> _contract;
        
        /// <summary>
        /// <para>Сведения о договоре (сделке)</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Сведения о договоре (сделке)")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("Договор")]
        public System.Collections.ObjectModel.Collection<PaymentsInfoKbkiObligationsBkiContract> Contract
        {
            get
            {
                return _contract;
            }
            private set
            {
                _contract = value;
            }
        }
        
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="PaymentsInfoKbkiObligationsBki" /> class.</para>
        /// </summary>
        public PaymentsInfoKbkiObligationsBki()
        {
            this._contract = new System.Collections.ObjectModel.Collection<PaymentsInfoKbkiObligationsBkiContract>();
        }
        
        /// <summary>
        /// <para>ОГРН БКИ - источника информации</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("ОГРН БКИ - источника информации")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlAttributeAttribute("ОГРН")]
        public string Ogrn { get; set; }
    }

    /// <summary>
    /// <para>Сведения о договоре (сделке)</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.1.963.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("СведенияОПлатежахКбкиОбязательстваБкиДоговор", Namespace="", AnonymousType=true)]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class PaymentsInfoKbkiObligationsBkiContract
    {
        
        /// <summary>
        /// <para>Величина среднемесячного платежа</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Величина среднемесячного платежа")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("СреднемесячныйПлатеж")]
        public SSP_API.Types.Xsd.AverageMonthlyPayment AverageMonthlyPayment { get; set; }
        
        /// <summary>
        /// <para>Универсальный идентификатор договора (сделки)</para>
        /// <para>Универсальный идентификатор договора (сделки)</para>
        /// <para xml:lang="en">Pattern: [a-f\d]{8}-[a-f\d]{4}-[a-f\d]{4}-[a-f\d]{4}-[a-f\d]{12}-[a-f\d].</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Универсальный идентификатор договора (сделки)")]
        [System.ComponentModel.DataAnnotations.RegularExpressionAttribute("[a-f\\d]{8}-[a-f\\d]{4}-[a-f\\d]{4}-[a-f\\d]{4}-[a-f\\d]{12}-[a-f\\d]")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlAttributeAttribute("УИД")]
        public string ContractUniversalId { get; set; }
    }

    /// <summary>
    /// <para>Тип ответа</para>
    /// </summary>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.1.963.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("СведенияОПлатежахТипОтвета", Namespace="", AnonymousType=true)]
    public enum PaymentsInfoAnswerType
    {

        /// <summary>
        /// Сведения одного КБКИ
        /// </summary>
        [Display(Name = "Сведения одного КБКИ")]
        [System.Xml.Serialization.XmlEnumAttribute("1")]
        Item1,

        /// <summary>
        /// Сведения всех КБКИ ("Одно окно")
        /// </summary>
        [Display(Name = "Сведения всех КБКИ (\"Одно окно\")")]
        [System.Xml.Serialization.XmlEnumAttribute("2")]
        Item2,
    }
}
