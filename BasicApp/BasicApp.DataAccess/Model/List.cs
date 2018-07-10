namespace BasicApp.DataAccess.Model
{
    using System.Collections.Generic;

    public class List : Entity
    {
        public string Name { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}