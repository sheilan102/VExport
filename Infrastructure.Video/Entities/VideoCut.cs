using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoInfrastructure.Entities
{
    public class VideoCut
    {
        public int startFrame;
        public int endFrame;
        public List<Frame> Frames = new List<Frame>();
    }

}
