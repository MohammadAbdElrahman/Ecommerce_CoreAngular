using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class Pagination<Entity>where Entity:class
    {
        public Pagination(int pageSize, int pageIndex, int count, IReadOnlyList<Entity> entitties)
        {
            PageSize = pageSize;
            PageIndex = pageIndex;
            Count = count;
            Entitties = entitties;
        }

        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public int Count { get; set; }
        public IReadOnlyList<Entity> Entitties { get; set; }
    }
}
