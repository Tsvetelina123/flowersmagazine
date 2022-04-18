using System.Collections.Generic;

namespace Flowersmagazine.Data
{
    public class TypeBouquet
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}