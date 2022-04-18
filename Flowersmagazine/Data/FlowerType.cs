using System.Collections.Generic;

namespace Flowersmagazine.Data
{
    public class FlowerType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}