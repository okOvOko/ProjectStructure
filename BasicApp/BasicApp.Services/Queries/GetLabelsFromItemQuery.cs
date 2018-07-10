using System.Collections.Generic;
using BasicApp.Services.Abstractions;
using BasicApp.Services.DTOs;

namespace BasicApp.Services.Queries
{
    public class GetLabelsFromItemQuery: IQuery<ICollection<Label>>
    {
        public int ItemId { get; set; }
    }
}