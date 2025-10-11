namespace Core.Models
{
    public partial class Translation
    {
        public int TranslationId { get; set; }
        public string EntityName { get; set; }
        public int EntityId { get; set; }
        public string LanguageCode { get; set; }
        public string FieldName { get; set; }
        public string TranslatedText { get; set; }
    }
}
