using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Flowersmagazine.Data
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Size { get; set; }
        public string Description { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Price { get; set; }
        public int FlowerId { get; set; }
        public FlowerType FlowerType { get; set; }
        public int BoquetId { get; set; }
        public TypeBouquet TypeBouquet { get; set; }
        public DateTime OrderedOn { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
       
    }
}
