using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoalkeeperSchoolDataAcess.Models.Core
{
    public abstract class BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid ID { get; set; }

        public BaseModel()
        {
            ID = Guid.NewGuid();
        }
    }
}