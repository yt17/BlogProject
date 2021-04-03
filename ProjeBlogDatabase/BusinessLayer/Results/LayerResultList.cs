using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Results
{
    public class LayerResultList<T> where T:class
    {
        public List<T> Sonuc { get; set; }
    }
}
