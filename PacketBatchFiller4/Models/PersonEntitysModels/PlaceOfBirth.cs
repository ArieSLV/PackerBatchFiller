using System.ComponentModel.DataAnnotations.Schema;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Место рождения
    /// </summary>
    [Table("PlaceOfBirths")]
    public class PlaceOfBirth
    {
        /// <summary>
        /// ID в базе данных места рождения
        /// </summary>
        public long PlaceOfBirthId { get; set; }

        /// <summary>
        /// Наименование места рождения
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Явное указание текстового представления места рождения
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Value;
    }
}