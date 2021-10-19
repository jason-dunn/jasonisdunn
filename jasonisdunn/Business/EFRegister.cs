using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace jasonisdunn.Business
{
    public class EFRegister
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Attempt { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Guid { get; set; }
        public string? Code { get; set; }
        public bool Confirm { get; set; }
    }
}
