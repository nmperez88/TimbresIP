using System;
using System.Collections.Generic;

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
