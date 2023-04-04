using DiziCashier.Core.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DiziCashier.Core.Entities
{
    [Table("ItemCategory")]
    public class ItemCategory : BaseEntity
    {
        public Guid ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
