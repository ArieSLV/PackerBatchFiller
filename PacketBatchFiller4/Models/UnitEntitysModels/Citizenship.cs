using System.ComponentModel.DataAnnotations.Schema;

namespace PacketBatchFiller4
{
    /// <summary>
    /// Гражданство
    /// </summary>
    [Table("Citizenships")]
    public class Citizenship : ISuggestable
    {
        /// <summary>
        /// Обозначение невыбранного типа гражданства
        /// </summary>
        public string DefaultValue { get; } = "[Страна не выбрана]";

        /// <summary>
        /// Указание на главное поле класса
        /// </summary>
        public string MainField { get; } = "Value";

        /// <summary>
        /// ID в базе данных гражданства
        /// </summary>
        public long CitizenshipId { get; set; }

        /// <summary>
        /// Имя страны
        /// </summary>
        public string Value { get; set; }

        /// <summary>
        /// Явное указание текстового представления гражданства
        /// </summary>
        /// <returns></returns>
        public override string ToString() => Value;

        
    }
}