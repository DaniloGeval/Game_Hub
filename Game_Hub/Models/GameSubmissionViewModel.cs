namespace Game_Hub.Models
{
    public class GameSubmissionViewModel
    {
        public int Id { get; set; }                           // 1. ID
        public string GameTitle { get; set; }                 // 2. Назва гри
        public string DeveloperStudio { get; set; }           // 3. Студія-розробник
        public int? ReleaseYear { get; set; }                 // 4. Рік випуску (Nullable)
        public decimal? Price { get; set; }                   // 5. Ціна (Nullable)
        public string Category { get; set; }                  // 6. Категорія
        public string ContactEmail { get; set; }              // 7. Email для зв'язку
        public string Description { get; set; }               // 8. Опис гри
        public int? AgeRating { get; set; }                   // 9. Віковий рейтинг (Nullable)
        public bool IsMultiplayer { get; set; }               // 10. Наявність мультиплеєра
    }
}