using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Data.Models
{
    public class StreamVideo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Url)]
        public string URL { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
    }
}
