using BasicApp.Services.Abstractions;

namespace BasicApp.Services.Command
{
    public class DeleteListCommand: ICommand<bool>
    {
        public int Id { get; set; }
    }
}