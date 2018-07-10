namespace BasicApp.DataAccess.Model
{
    using System.Collections.Generic;

    public class Item : Entity
    {
        public string Title { get; set; }

        public bool IsDone { get; set; }

        public int ListId { get; set; }

        public virtual List List { get; set; }

        public virtual ICollection<ItemLabel> IteamLabels { get; set; }
    }
}