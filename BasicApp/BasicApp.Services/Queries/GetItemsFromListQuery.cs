using System.Collections.Generic;
using BasicApp.Services.Abstractions;
using BasicApp.Services.DTOs;

namespace BasicApp.Services.Queries
{
    public class GetItemsFromListQuery: IQuery<ICollection<Item>>
    {
        public int ListId { get; set; }
    }
}