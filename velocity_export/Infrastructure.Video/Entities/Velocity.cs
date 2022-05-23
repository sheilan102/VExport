using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoInfrastructure.Entities
{
    public class Velocity
    {
        public List<VideoCut> Cuts = new List<VideoCut> { };

        public void SaveVelocityBin(string Path)
        {
            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(Path)))
            {
                writer.Write((ushort)300); // original fps
                writer.Write((ushort)30); // target fps
                writer.Write((byte) Cuts.Count);
                foreach (VideoCut cut in Cuts)
                {
                    writer.Write(cut.startFrame);
                    writer.Write(cut.endFrame);
                    foreach (var frame in cut.Frames)
                    {
                        writer.Write(frame.OriginalFrameNumber);
                        writer.Write(frame.Timescale);
                    }
                }
            }
        }
    }
    
}
