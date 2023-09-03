using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_8_Raw_SQL_Dapper.Model
{
    public class Student
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string? Name { get; set; }
        public string? Family { get; set; }
        public byte Age { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public bool Gender { get; set; }
    }
}
