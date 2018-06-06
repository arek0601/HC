using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTest
{
    public class MockData
    {
        public List<Key> ListKey { get; private set; } = new List<Key>();

        public List<KeyValue> ListKeyAndValue { get; private set; } = new List<KeyValue>();

        public MockData()
        {
            for (int i = 0; i < 5; i++)
            {
                ListKey.Add(new Key() { ResourceKey = $"key_{i}" });
            }

            for (int i = 0; i < 6; i++)
            {
                ListKeyAndValue.Add(new KeyValue()
                {
                    ResourceKey = $"key_{i}",
                    ResourceValue = $"Value_{i}"
                });
            }

            ListKeyAndValue.Add(new KeyValue()
            {
                ResourceKey = $"key_1",
                ResourceValue = $"Value_1"
            });
        }
    }
}
