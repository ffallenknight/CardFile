using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardFileDAL.Entities
{
    public class ClientProfile
    {
        [Key]
        [ForeignKey("AppUser")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TextCounter { get; set; }

        public virtual AppUser AppUser { get; set; }
    }
}
