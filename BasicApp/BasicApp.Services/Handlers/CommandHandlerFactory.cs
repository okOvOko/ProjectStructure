using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BasicApp.DataAccess.Model;
using BasicApp.Services.Command;
using Microsoft.EntityFrameworkCore;

namespace BasicApp.Services.Handlers
{
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        private readonly ToDoDbContext context;

        public CommandHandlerFactory(ToDoDbContext context)
        {
            this.context = context;
        }

        public Dictionary<Type, Func<object, Task<object>>> GetHandlers()
        {
            return new Dictionary<Type, Func<object, Task<object>>>
            {
                { typeof(DeleteListCommand), async t => await HandleAsync(t as DeleteListCommand) },
                { typeof(DeleteItemCommand), async t => await HandleAsync(t as DeleteItemCommand) },
                { typeof(DeleteLabelFromItemCommand), async t => await HandleAsync(t as DeleteLabelFromItemCommand) },
                { typeof(AddListCommand), async t => await HandleAsync(t as AddListCommand) },
                { typeof(AddItemCommand), async t => await HandleAsync(t as AddItemCommand) },
                { typeof(AddLabelCommand), async t => await HandleAsync(t as AddLabelCommand) }
            };
        }

        private async Task<bool> HandleAsync(DeleteListCommand command)
        {
            var list = await this.context.Lists.FindAsync(command.Id);
            this.context.Lists.Remove(list);
            var count = await this.context.SaveChangesAsync();
            return count >= 0;
        }

        private async Task<bool> HandleAsync(DeleteItemCommand command)
        {
            var item = await this.context.Items.FindAsync(command.ItemId);
            this.context.Items.Remove(item);
            var count = await this.context.SaveChangesAsync();
            return count >= 0;
        }

        private async Task<bool> HandleAsync(DeleteLabelFromItemCommand command)
        {
            var itemLabel = await this.context.ItemLabels
                .FirstOrDefaultAsync(il =>il.LabelId == command.LabelId && il.ItemId == command.ItemId);

            if (itemLabel == null) return true;

            this.context.ItemLabels.Remove(itemLabel);
            var count = await this.context.SaveChangesAsync();
            return count >= 0;

        }

        private async Task<int> HandleAsync(AddListCommand command)
        {
            var list = new List { Name = command.Name };
            await this.context.Lists.AddAsync(list);
            await this.context.SaveChangesAsync();
            return list.Id;
        }

        private async Task<int> HandleAsync(AddItemCommand command)
        {
            var item = new Item { Title = command.Title, IsDone = false, ListId = command.ListId };
            await this.context.Items.AddAsync(item);
            await this.context.SaveChangesAsync();
            return item.Id;
        }

        private async Task<int> HandleAsync(AddLabelCommand command)
        {
            var label = await this.context.Labels.FirstOrDefaultAsync(l => l.Name == command.Name);
            if (label == null)
            {
                label = new Label { Name = command.Name };
                await this.context.Labels.AddAsync(label);
                await this.context.SaveChangesAsync();
            }

            if (await this.context.ItemLabels.FirstOrDefaultAsync(il =>
                    il.ItemId == command.ItemId && il.LabelId == label.Id) != null)
            {
                return label.Id;
            }

            await this.context.ItemLabels.AddAsync(new ItemLabel { ItemId = command.ItemId, Label = label });
            await this.context.SaveChangesAsync();
            return label.Id;
        }
    }
}