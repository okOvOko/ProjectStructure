namespace BasicApp.Services.DTOs
{
    public class ItemLabel
    {
        public int ItemId { get; set; }

        public Item Item { get; set; }

        public int LabelId { get; set; }

        public Label Label { get; set; }
    }
}