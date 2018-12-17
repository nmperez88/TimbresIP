using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimbresIP.Model
{
    /*
     * Horario
     */
    class Horary
    {
        private String name { get; set; }
        private String randomId;
        private List<ToneCall> toneCallList = new List<ToneCall>();
        private ServerExtension serverExtension;
    }
}
