namespace BasicApp.Services.DTOs
{
    using System.Collections.Generic;

    public class List
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}