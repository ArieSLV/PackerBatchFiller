using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Юридическое лицо
    /// </summary>
    [Serializable]
    [Table("LegalEntities")]
    public class LegalEntity : Unit
    {
        /// <summary>
        /// Код причины постановки на учет
        /// </summary>
        public string KPP { get; set; }

        /// <summary>
        /// Общероссийский классификатор предприятий и организаций
        /// </summary>
        public string OKPO { get; set; }

        /// <summary>
        /// Общероссийский классификатор видов экономической деятельности
        /// </summary>
        public string OKVED { get; set; }

        /// <summary>
        /// Свидетельство о государственной регистрации
        /// </summary>
        public virtual RegistrationCertificate RegistrationCertificate { get; set; }

        /// <summary>
        /// Единоличный исполнительный орган юридического лица
        /// </summary>
        public Unit FirstPersonOfCompany { get; set; }

        /// <summary>
        /// Указание на то, является ли данное лицо эмитентом
        /// </summary>
        public bool RoleIsSecuritiesIssuerFlag { get; set; }

        /// <summary>
        /// Организационно-правовая форма юридического лица
        /// </summary>
        public FormOfIncorporation FormOfIncorporation { get; set; }

        /// <summary>
        /// Краткое наименование по Уставу
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Выпуски ценных бумаг данного юридического лица
        /// </summary>
        public ObservableCollection<IssueOfSecurities> IssuesOfSecurities { get; set; }
    }
}