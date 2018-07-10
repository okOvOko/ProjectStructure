using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BasicApp.DataAccess.Model;
using BasicApp.Services.Command;
using BasicApp.Services.Queries;
using Microsoft.EntityFrameworkCore;
using Item = BasicApp.Services.DTOs.Item;
using List = BasicApp.Services.DTOs.List;
using Label = BasicApp.Services.DTOs.Label;

namespace BasicApp.Services.Handlers
{
    public class ToDoQueryHandler : IQueryHandlerFactory
    {
        private readonly ToDoDbContext context;
        private readonly IMapper mapper;

        public ToDoQueryHandler(ToDoDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Dictionary<Type, Func<object, Task<object>>> GetHandlers()
        {
            return new Dictionary<Type, Func<object, Task<object>>>
            {
                { typeof(GetListsQuery), async t => await HandleAsync(t as GetListsQuery) },
                { typeof(GetItemsFromListQuery), async t => await HandleAsync(t as GetItemsFromListQuery) },
                { typeof(GetLabelsFromItemQuery), async t => await HandleAsync(t as GetLabelsFromItemQuery) },
            };
        }

        private async Task<ICollection<List>> HandleAsync(GetListsQuery query)
        {
            var lists = await this.context.Lists.Include(l => l.Items).ThenInclude(i => i.IteamLabels).ThenInclude(il => il.Label).AsNoTracking().ToListAsync();
            return lists.Select(this.mapper.Map<DataAccess.Model.List, List>).ToList();
        }

        private async Task<ICollection<Item>> HandleAsync(GetItemsFromListQuery query)
        {
            var list = await this.context.Lists.Include(e => e.Items).FirstAsync(l => l.Id == query.ListId);
            return list.Items.Select(this.mapper.Map<DataAccess.Model.Item, Item>).ToList();
        }

        private async Task<ICollection<Label>> HandleAsync(GetLabelsFromItemQuery query)
        {
            var labels = await this.context.ItemLabels
                .Include(e => e.Label)
                .Where(il => il.ItemId == query.ItemId)
                .Select(il => il.Label)
                .ToListAsync();
            return labels.Select(this.mapper.Map<DataAccess.Model.Label, Label>).ToList();
        }
    }
}