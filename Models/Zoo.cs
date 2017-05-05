using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Zoo
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ManagerId { get; set; }
        public virtual Employee Manager { get; set; }

        public List<Animal> Animals { get; set; }
        public List<Employee> Employees { get; set; }

    }
}
