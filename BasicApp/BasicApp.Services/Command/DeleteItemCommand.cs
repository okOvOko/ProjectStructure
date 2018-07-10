using BasicApp.Services.Abstractions;

namespace BasicApp.Services.Command
{
    public class DeleteItemCommand : ICommand<bool>
    {
        public int ItemId { get; set; }
    }
}