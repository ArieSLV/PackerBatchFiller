using System.ComponentModel.DataAnnotations.Schema;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Тип документа, удостоверяющего личность физического лица
    /// </summary>
    [Table("CardIDTypes")]
    public class CardIDType
    {
        /// <summary>
        /// ID в базе данных типа документа, удостоверяющего личность физического лица
        /// </summary>
        public long CardIDTypeId { get; set; }

        /// <summary>
        /// Наименование типа документа, удостоверяющего личность физического лица
        /// </summary>
        public string Value { get; set; }


        /// <summary>
        /// Явное уазание текстового представления типа документа, удостоверяющего личность физического лица
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Value;
        public override bool Equals(object obj) => (obj as CardIDType)?.CardIDTypeId == CardIDTypeId;
        public override int GetHashCode() => base.GetHashCode();
    }
}