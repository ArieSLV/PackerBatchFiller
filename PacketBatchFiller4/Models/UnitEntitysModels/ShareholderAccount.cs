using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Тип лицевого счета
    /// </summary>
    public enum ShareholderAccountType
    {

        /// <summary>
        /// Владелец
        /// </summary>
        [StringValue("Владелец")]
        Owner,

        /// <summary>
        /// Номинальный держатель
        /// </summary>
        [StringValue("Номинальный держатель")]
        Nominee,

        /// <summary>
        /// Доверительный управляющий
        /// </summary>
        [StringValue("Доверительный управляющий")]
        Trustee,

        /// <summary>
        /// Депозитный
        /// </summary>
        [StringValue("Депозитный")]
        Deposit,

        /// <summary>
        /// Казначейский
        /// </summary>
        [StringValue("Казначейский")]
        Treasury,

        /// <summary>
        /// Центральный депозитарий
        /// </summary>
        [StringValue("Центральный депозитарий")]
        CentralDepository
    }

    /// <summary>
    /// Лицевой счет акционера
    /// </summary>
    [Serializable]
    [Table("ShareholderAccount")]
    public class ShareholderAccount
    {
        /// <summary>
        /// ID в базе данных лицевого счета
        /// </summary>
        public long ShareholderAccountId { get; set; }

        /// <summary>
        /// Номер лицевого счета
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Эмитент, в реестре которого открыт лицевой счет
        /// </summary>
        public virtual LegalEntity SecuritiesIssuer { get; set; }

        /// <summary>
        /// Тип лицевого счета
        /// </summary>
        public ShareholderAccountType ShareholderAccountType { get; set; }

        /// <summary>
        /// Лицо, которому принадлежит лицевой счет
        /// </summary>
        public Unit Unit { get; set; }


        /// <summary>
        /// Явное указание текстового представления лицевого счета
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var stringToReturn = new StringBuilder();

            var unitToReturn = Unit?.ToString() ?? string.Empty;
            var numberToReturn = Number ?? string.Empty;
            var siToReturn = SecuritiesIssuer != null ? SecuritiesIssuer.ShortName : string.Empty;

            if (!string.IsNullOrWhiteSpace(unitToReturn)) stringToReturn.Append($"{unitToReturn}");
            if (!string.IsNullOrWhiteSpace(numberToReturn) &&
                !string.IsNullOrWhiteSpace(siToReturn) &&
                !string.IsNullOrWhiteSpace(unitToReturn)) stringToReturn.Append(" (");
            if (!string.IsNullOrWhiteSpace(numberToReturn)) stringToReturn.Append(numberToReturn);
            if (numberToReturn != "[лицевой счет не выбран]") stringToReturn.Append($", {StringEnum.GetStringValue(ShareholderAccountType)}");
            if (!string.IsNullOrWhiteSpace(siToReturn)) stringToReturn.Append($", {siToReturn}");
            if (!string.IsNullOrWhiteSpace(numberToReturn) &&
                !string.IsNullOrWhiteSpace(siToReturn) &&
                !string.IsNullOrWhiteSpace(unitToReturn)) stringToReturn.Append(")");


            return stringToReturn.ToString();
        }
    }
}