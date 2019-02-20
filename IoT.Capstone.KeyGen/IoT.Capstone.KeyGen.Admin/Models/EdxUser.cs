using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace IoT.Capstone.KeyGen.Admin.Models
{
    public class EdxUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:X8}")]
        public int Uid { get; set; }
        [Required]
        public string EdxId { get; set; }
    }
}
