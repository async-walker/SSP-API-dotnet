//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// This code was generated by XmlSchemaClassGenerator version 2.1.963.0 using the following command:
// xscgen -n |C:\shemas\bki_api_sch\qcb_request.xsd=SSP_API.Types.Xsd -n |C:\shemas\bki_api_sch\qcb_common.xsd=SSP_API.Types.Xsd C:\shemas\bki_api_sch\qcb_request.xsd C:\shemas\bki_api_sch\qcb_common.xsd
namespace SSP_API.Types.Xsd
{


    /// <summary>
    /// <para>Фамилия, имя и отчество</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute("Фамилия, имя и отчество")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.1.963.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("ТипФИО", Namespace="")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FullName
    {
        private FullName() { }

        /// <summary>
        /// Инициализация <see cref="FullName"/>
        /// </summary>
        /// <param name="lastName">Фамилия</param>
        /// <param name="name">Имя</param>
        /// <param name="middleName">Отчество (при наличии)</param>
        public FullName(
            string lastName, 
            string name, 
            string middleName = default)
        {
            LastName = lastName;
            Name = name;
            MiddleName = middleName;
        }

        /// <summary>
        /// <para>Фамилия</para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 255.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Фамилия")]
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(255)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("Фамилия")]
        public string LastName { get; set; }
        
        /// <summary>
        /// <para>Имя</para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 255.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Имя")]
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(255)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("Имя")]
        public string Name { get; set; }
        
        /// <summary>
        /// <para>Отчество (обязательно при наличии)</para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 255.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Отчество (обязательно при наличии)")]
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(255)]
        [System.Xml.Serialization.XmlElementAttribute("Отчество")]
        public string MiddleName { get; set; }
    }
    
    /// <summary>
    /// <para>Перечень документов, удостоверяющих личность</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute("Перечень документов, удостоверяющих личность")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.1.963.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("СправочникДУЛ", Namespace="")]
    public enum IdentityDocumentType
    {
        
        /// <summary>
        /// <para>Паспорт гражданина Российской Федерации</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Паспорт гражданина Российской Федерации")]
        [System.Xml.Serialization.XmlEnumAttribute("21")]
        Item21,
        
        /// <summary>
        /// <para>Паспорт гражданина Российской Федерации, удостоверяющий его личность за пределами территории Российской Федерации</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Паспорт гражданина Российской Федерации, удостоверяющий его личность за пределами" +
            " территории Российской Федерации")]
        [System.Xml.Serialization.XmlEnumAttribute("22.1")]
        Item221,
        
        /// <summary>
        /// <para>Дипломатический паспорт, удостоверяющий личность гражданина Российской Федерации за пределами территории Российской Федерации</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Дипломатический паспорт, удостоверяющий личность гражданина Российской Федерации " +
            "за пределами территории Российской Федерации")]
        [System.Xml.Serialization.XmlEnumAttribute("22.2")]
        Item222,
        
        /// <summary>
        /// <para>Служебный паспорт, удостоверяющий личность гражданина Российской Федерации за пределами территории Российской Федерации</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Служебный паспорт, удостоверяющий личность гражданина Российской Федерации за пре" +
            "делами территории Российской Федерации")]
        [System.Xml.Serialization.XmlEnumAttribute("22.3")]
        Item223,
        
        /// <summary>
        /// <para>Удостоверение личности моряка</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Удостоверение личности моряка")]
        [System.Xml.Serialization.XmlEnumAttribute("23")]
        Item23,
        
        /// <summary>
        /// <para>Удостоверение личности военнослужащего</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Удостоверение личности военнослужащего")]
        [System.Xml.Serialization.XmlEnumAttribute("24")]
        Item24,
        
        /// <summary>
        /// <para>Военный билет военнослужащего</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Военный билет военнослужащего")]
        [System.Xml.Serialization.XmlEnumAttribute("25")]
        Item25,
        
        /// <summary>
        /// <para>Временное удостоверение личности гражданина Российской Федерации, выдаваемое на период оформления паспорта гражданина Российской Федерации</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Временное удостоверение личности гражданина Российской Федерации, выдаваемое на п" +
            "ериод оформления паспорта гражданина Российской Федерации")]
        [System.Xml.Serialization.XmlEnumAttribute("26")]
        Item26,
        
        /// <summary>
        /// <para>Свидетельство о рождении гражданина Российской Федерации</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Свидетельство о рождении гражданина Российской Федерации")]
        [System.Xml.Serialization.XmlEnumAttribute("27")]
        Item27,
        
        /// <summary>
        /// <para>Иной документ, удостоверяющий личность гражданина Российской Федерации в соответствии с законодательством Российской Федерации</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Иной документ, удостоверяющий личность гражданина Российской Федерации в соответс" +
            "твии с законодательством Российской Федерации")]
        [System.Xml.Serialization.XmlEnumAttribute("28")]
        Item28,
        
        /// <summary>
        /// <para>Паспорт иностранного гражданина либо иной документ, установленный федеральным законом или признаваемый в соответствии с международным договором Российской Федерации в качестве документа, удостоверяющего личность иностранного гражданина</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Паспорт иностранного гражданина либо иной документ, установленный федеральным зак" +
            "оном или признаваемый в соответствии с международным договором Российской Федера" +
            "ции в качестве документа, удостоверяющего личность иностранного гражданина")]
        [System.Xml.Serialization.XmlEnumAttribute("31")]
        Item31,
        
        /// <summary>
        /// <para>Документ, выданный иностранным государством и признаваемый в соответствии с международным договором Российской Федерации в качестве документа, удостоверяющего личность лица без гражданства</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Документ, выданный иностранным государством и признаваемый в соответствии с между" +
            "народным договором Российской Федерации в качестве документа, удостоверяющего ли" +
            "чность лица без гражданства")]
        [System.Xml.Serialization.XmlEnumAttribute("32")]
        Item32,
        
        /// <summary>
        /// <para>Иной документ, признаваемый документом, удостоверяющим личность лица без гражданства в соответствии с законодательством Российской Федерации и международным договором Российской Федерации</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Иной документ, признаваемый документом, удостоверяющим личность лица без гражданс" +
            "тва в соответствии с законодательством Российской Федерации и международным дого" +
            "вором Российской Федерации")]
        [System.Xml.Serialization.XmlEnumAttribute("35")]
        Item35,
        
        /// <summary>
        /// <para>Удостоверение беженца</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Удостоверение беженца")]
        [System.Xml.Serialization.XmlEnumAttribute("37")]
        Item37,
        
        /// <summary>
        /// <para>Удостоверение вынужденного переселенца</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Удостоверение вынужденного переселенца")]
        [System.Xml.Serialization.XmlEnumAttribute("38")]
        Item38,
        
        /// <summary>
        /// <para>Иной документ</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Иной документ")]
        [System.Xml.Serialization.XmlEnumAttribute("999")]
        Item999,
    }
    
    /// <summary>
    /// <para>Документ, удостоверяющий личность</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute("Документ, удостоверяющий личность")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.1.963.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("ТипДУЛ", Namespace="")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class IdentityDocument
    {
        
        /// <summary>
        /// <para>Серия</para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 32.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Серия")]
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(32)]
        [System.Xml.Serialization.XmlElementAttribute("Серия")]
        public string Series { get; set; }
        
        /// <summary>
        /// <para>Номер</para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 32.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Номер")]
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(32)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("Номер")]
        public string Number { get; set; }
        
        /// <summary>
        /// <para>Дата выдачи</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Дата выдачи")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("ДатаВыдачи", DataType="date")]
        public System.DateTime DateIssue { get; set; }
        
        /// <summary>
        /// <para>Код страны гражданства по ОКСМ</para>
        /// <para>Код страны по ОКСМ</para>
        /// <para xml:lang="en">Pattern: \d\d\d.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Код страны гражданства по ОКСМ")]
        [System.ComponentModel.DataAnnotations.RegularExpressionAttribute("\\d\\d\\d")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("Гражданство")]
        public string Citizen { get; set; }
        
        /// <summary>
        /// <para>Код ДУЛ</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Код ДУЛ")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlAttributeAttribute("КодДУЛ")]
        public IdentityDocumentType CodeIdentityDocument { get; set; }
    }
    
    /// <summary>
    /// <para>Документ, удостоверяющий личность индивидуального предпринимателя</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute("Документ, удостоверяющий личность")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.1.963.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("ТипДУЛПредпринимателя", Namespace="")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class EntrepreneurIdentityDocument
    {
        private EntrepreneurIdentityDocument() { }

        /// <summary>
        /// Инициализация экзмепляра <see cref="EntrepreneurIdentityDocument"/>
        /// </summary>
        /// <param name="series">Серия</param>
        /// <param name="number">Номер</param>
        /// <param name="dateIssue">Дата выдачи</param>
        /// <param name="authorityIssued">Наименование органа выдавшего ДУЛ</param>
        /// <param name="departmentCode">Код подразделения</param>
        /// <param name="documentType">Код ДУЛ</param>
        /// <param name="nameOtherIdentityDocument">Наименование иного ДУЛ</param>
        public EntrepreneurIdentityDocument(
            string series,
            string number,
            DateOnly dateIssue,
            string authorityIssued,
            string departmentCode,
            IdentityDocumentType documentType,
            string nameOtherIdentityDocument = default)
        {
            Series = series;
            Number = number;
            DateIssue = dateIssue;
            AuthorityIssuedIdentityDocument = authorityIssued;
            DepartmentCode = departmentCode;
            CodeIdentityDocument = documentType;
            NameOtherIdentityDocument = nameOtherIdentityDocument;
        }
        
        /// <summary>
        /// <para>Серия</para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 32.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Серия")]
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(32)]
        [System.Xml.Serialization.XmlElementAttribute("Серия")]
        public string Series { get; set; }
        
        /// <summary>
        /// <para>Номер</para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 32.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Номер")]
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(32)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("Номер")]
        public string Number { get; set; }
        
        /// <summary>
        /// <para>Дата выдачи</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Дата выдачи")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("ДатаВыдачи", DataType="date")]
        public System.DateOnly DateIssue { get; set; }
        
        /// <summary>
        /// <para>Наименование органа выдавшего ДУЛ</para>
        /// <para>Наименование</para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 2000.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Наименование органа выдавшего ДУЛ")]
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(2000)]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("НаименованиеОргана")]
        public string AuthorityIssuedIdentityDocument { get; set; }
        
        /// <summary>
        /// <para>Код подразделения</para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 16.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Код подразделения")]
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(16)]
        [System.Xml.Serialization.XmlElementAttribute("КодПодразделения")]
        public string DepartmentCode { get; set; }
        
        /// <summary>
        /// <para>Код ДУЛ</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Код ДУЛ")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlAttributeAttribute("КодДУЛ")]
        public IdentityDocumentType CodeIdentityDocument { get; set; }
        
        /// <summary>
        /// <para>Наименование иного ДУЛ</para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 2000.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Наименование иного ДУЛ")]
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(2000)]
        [System.Xml.Serialization.XmlAttributeAttribute("НаименованиеДУЛ")]
        public string NameOtherIdentityDocument { get; set; }
    }
    
    /// <summary>
    /// <para>Информация о субъекте (титульная часть)</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute("Информация о субъекте (титульная часть)")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.1.963.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("ТипСубъектТитул", Namespace="")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class SubjectInfo
    {
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<FullName> _fullname;

        /// <summary>
        /// <para>Фамилия, имя и отчество</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("ФИО")]
        public System.Collections.ObjectModel.Collection<FullName> Fullname
        {
            get
            {
                return _fullname;
            }
            private set
            {
                _fullname = value;
            }
        }
        
        /// <summary>
        /// <para xml:lang="en">Initializes a new instance of the <see cref="SubjectInfo" /> class.</para>
        /// </summary>
        public SubjectInfo()
        {
            this._fullname = new System.Collections.ObjectModel.Collection<FullName>();
            this._identityDocument = new System.Collections.ObjectModel.Collection<IdentityDocument>();
        }
        
        /// <summary>
        /// <para>Дата рождения</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Дата рождения")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("ДатаРождения", DataType="date")]
        public System.DateTime BirthDate { get; set; }
        
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        private System.Collections.ObjectModel.Collection<IdentityDocument> _identityDocument;

        /// <summary>
        /// <para>Документ, удостоверяющий личность</para>
        /// </summary>
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlElementAttribute("ДокументЛичности")]
        public System.Collections.ObjectModel.Collection<IdentityDocument> IdentityDocument
        {
            get
            {
                return _identityDocument;
            }
            private set
            {
                _identityDocument = value;
            }
        }
        
        /// <summary>
        /// <para>ИНН (при наличии)</para>
        /// <para>Индивидуальный номер налогоплательщика физического лица</para>
        /// <para xml:lang="en">Pattern: \d{12}.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("ИНН (при наличии)")]
        [System.ComponentModel.DataAnnotations.RegularExpressionAttribute("\\d{12}")]
        [System.Xml.Serialization.XmlElementAttribute("ИНН")]
        public string Inn { get; set; }
        
        /// <summary>
        /// <para>Номер налогоплательщика, присвоенный иностранным государством</para>
        /// <para xml:lang="en">Minimum length: 1.</para>
        /// <para xml:lang="en">Maximum length: 255.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Номер налогоплательщика, присвоенный иностранным государством")]
        [System.ComponentModel.DataAnnotations.MinLengthAttribute(1)]
        [System.ComponentModel.DataAnnotations.MaxLengthAttribute(255)]
        [System.Xml.Serialization.XmlElementAttribute("ИнНомер")]
        public string TaxpayerNumber { get; set; }
        
        /// <summary>
        /// <para>СНИЛС (при наличии)</para>
        /// <para>Страховой номер индивидуального лицевого счета</para>
        /// <para xml:lang="en">Pattern: \d\d\d-\d\d\d-\d\d\d \d\d.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("СНИЛС (при наличии)")]
        [System.ComponentModel.DataAnnotations.RegularExpressionAttribute("\\d\\d\\d-\\d\\d\\d-\\d\\d\\d \\d\\d")]
        [System.Xml.Serialization.XmlElementAttribute("СНИЛС")]
        public string Snils { get; set; }
    }
    
    /// <summary>
    /// <para>Среднемесячный платеж</para>
    /// </summary>
    [System.ComponentModel.DescriptionAttribute("Среднемесячный платеж")]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("XmlSchemaClassGenerator", "2.1.963.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute("ТипСреднемесячныйПлатеж", Namespace="")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AverageMonthlyPayment
    {
        
        /// <summary>
        /// <para xml:lang="en">Gets or sets the text value.</para>
        /// </summary>
        [System.Xml.Serialization.XmlTextAttribute()]
        public double Value { get; set; }
        
        /// <summary>
        /// <para>Валюта договора</para>
        /// <para>Буквенный код валюты по ОКВ</para>
        /// <para xml:lang="en">Pattern: [A-Z]{3}.</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Валюта договора")]
        [System.ComponentModel.DataAnnotations.RegularExpressionAttribute("[A-Z]{3}")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlAttributeAttribute("Валюта")]
        public string Currency { get; set; }
        
        /// <summary>
        /// <para>Дата расчета величины среднемесячного платежа</para>
        /// </summary>
        [System.ComponentModel.DescriptionAttribute("Дата расчета величины среднемесячного платежа")]
        [System.ComponentModel.DataAnnotations.RequiredAttribute()]
        [System.Xml.Serialization.XmlAttributeAttribute("ДатаРасчета", DataType="date")]
        public System.DateTime CalculationDate { get; set; }
    }
}
