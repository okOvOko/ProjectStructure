using BasicApp.Services.Abstractions;

namespace BasicApp.Services.Command
{
    public class AddItemCommand: ICommand<int>
    {
        public int ListId { get; set; }

        public string Title { get; set; }
    }
}