using EntityTest.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTest
{
    public class NoDuplicate
    {
        public static IEnumerable<KeyValueDto> CleanListOfResourceKeys(IEnumerable<KeyValueDto> tableSource, IEnumerable<KeyDto> tableExlude)
        {
            foreach (var item in tableExlude)
            {
                if (tableSource.Any(v => v.ResourceKey == item.ResourceKey))
                {
                    tableSource = tableSource.Where(k => k.ResourceKey != item.ResourceKey);
                }
            }
            return tableSource;
        }
    }
}
