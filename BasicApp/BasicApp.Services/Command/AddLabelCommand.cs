using BasicApp.Services.Abstractions;

namespace BasicApp.Services.Command
{
    public class AddLabelCommand: ICommand<int>
    {
        public int ItemId { get; set; }

        public string Name { get; set; }
    }
}