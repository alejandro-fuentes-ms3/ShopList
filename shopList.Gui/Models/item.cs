using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopList.Gui.Models
{
    public class item
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        public bool comprado { get; set; }

        public override string ToString()
        {
            return $"{this.Nombre} ({this.Cantidad})";
        }
    }
}
