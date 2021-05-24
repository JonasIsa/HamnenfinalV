using System;
using System.Collections.Generic;
using System.Text;

namespace Hamnenfinal
{
    class Harbor
    {

        public double Size { get; set; }

        public List<Slot> PSpots { get; set; }

    }

    class Slot
    {
        public double PSize { get; set; }
        public string ID { get; set; }
        public bool Bokad { get; set; }


    }
}
