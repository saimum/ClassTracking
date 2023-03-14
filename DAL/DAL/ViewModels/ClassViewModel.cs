using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.ViewModels
{
    public class ClassViewModel
    {
        public Int64? Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public Int64 MaxStudent { get; set; }

        public Int64? TeacherId { get; set; }
    }
}
