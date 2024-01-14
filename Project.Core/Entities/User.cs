using Project.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Core.Entities
{
    public class User : BaseEntity
    {       
        public string Name { get; set; }
        public string DocumentNumber { get; set; }        
    }
}
