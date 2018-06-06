using EntityTest.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            MockData mockData = new MockData();
            HcContext hcContext = new HcContext();
            hcContext.ClearDatabase();
            hcContext.Keys.AddRange(mockData.ListKey);
            hcContext.KeyValues.AddRange(mockData.ListKeyAndValue);
            hcContext.SaveChanges();

            ICollection<KeyDto> ListKeyDto = new List<KeyDto>();
            ICollection<KeyValueDto> ListKeyValueDto = new List<KeyValueDto>();

            var keys = hcContext.Keys;
            var keysValue = hcContext.KeyValues;

            foreach (var key in keys)
            {
                ListKeyDto.Add
                (
                    new KeyDto()
                    {
                        ResourceKey = key.ResourceKey
                    }
                );
            }

            foreach (var value in keysValue)
            {
                ListKeyValueDto.Add
                (
                    new KeyValueDto()
                    {
                        ResourceKey = value.ResourceKey,
                        ResourceValue = value.ResourceValue
                    }
                );
            }

            IEnumerable<KeyValueDto> keyValueList = NoDuplicate.CleanListOfResourceKeys(ListKeyValueDto, ListKeyDto);

            hcContext.KeyValues.RemoveRange(hcContext.KeyValues);

            foreach (var item in keyValueList)
            {
                hcContext.KeyValues.Add(new KeyValue()
                {
                    ResourceKey = item.ResourceKey,
                    ResourceValue = item.ResourceValue
                });
            }

            //hcContext.KeyValues.AddRange(keyValueList);
            hcContext.SaveChanges();

            var a = 1;
        }



    }
}
