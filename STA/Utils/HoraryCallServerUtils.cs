using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace STA.Utils
{
    class HoraryCallServerUtils
    {
        string id;
        string nameHorary;
        long startAt;
        long endAt;

        public long EndAt { get => endAt; set => endAt = value; }
        public long StartAt { get => startAt; set => startAt = value; }
        public string Id { get => id; set => id = value; }
        public string NameHorary { get => nameHorary; set => nameHorary = value; }
    }
}
