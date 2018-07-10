namespace BasicApp.Services.DTOs
{
    using System.Collections.Generic;

    public class Item
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public bool IsDone { get; set; }

        public ICollection<Label> Labels { get; set; }
    }
}