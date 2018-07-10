using BasicApp.Services.Abstractions;

namespace BasicApp.Services.Command
{
    public class AddListCommand: ICommand<int>
    {
        public string Name { get; set; }
    }
}