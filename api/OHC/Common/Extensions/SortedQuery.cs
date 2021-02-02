using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Extensions
{
    public abstract class SortedQuery
    {
        public string PropertyName { get; set; }
        public string SortOrder { get; set; }
    }
}
