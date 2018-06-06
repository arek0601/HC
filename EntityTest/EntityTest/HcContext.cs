using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityTest
{
    public class HcContext : DbContext
    {
        public HcContext() : base()
        {

        }

        public DbSet<Key> Keys { get; set; }

        public DbSet<KeyValue> KeyValues { get; set; }

        public void ClearDatabase()
        {
            Keys.RemoveRange(Keys);
            KeyValues.RemoveRange(KeyValues);
            SaveChanges();
        }
    }
}
