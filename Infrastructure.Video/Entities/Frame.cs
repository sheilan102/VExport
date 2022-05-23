using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoInfrastructure.Entities
{
    public class Frame
    {
        public int OriginalFrameNumber { get; set; }
        public double Timescale { get; set; }

        public Frame(int originalFrameNumber, double timescale)
        {
            OriginalFrameNumber = originalFrameNumber;
            Timescale = timescale;
        }
    }
}
