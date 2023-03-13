using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DataModels
{
    public class Teacher
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string NID { get; set; }

        //public int ClassDataModelId { get; set; }
        //[ForeignKey("ClassDataModelId")]
        //public virtual ClassDataModel ClassDataModel { get; set; }
    }
}
