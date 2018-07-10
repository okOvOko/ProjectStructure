namespace BasicApp.DataAccess.Model
{
    using System.Collections.Generic;

    public class Label: Entity
    {
        public string Name { get; set; }

        public virtual ICollection<ItemLabel> IteamLabels { get; set; }
    }
}