using BasicApp.Services.Abstractions;

namespace BasicApp.Services.Command
{
    public class DeleteLabelFromItemCommand: ICommand<bool>
    {
        public int ItemId { get; set; }

        public int LabelId { get; set; }
    }
}