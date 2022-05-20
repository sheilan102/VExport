using System;
using System.IO;
using ScriptPortal.Vegas;

namespace VExport
{
    public class EntryPoint
    {
        public Velocity veloSequence = new Velocity();
        private string videoName { get; set; }

        public void FromVegas(Vegas myVegas)
        {
            var VideoEvents = VegasUtil.GetSelectedVideoEvents(myVegas);
            // Check if the user selected any video event
            if (VideoEvents.Count > 0)
            {
                videoName = VideoEvents[0].ActiveTake.Name;
                foreach (var vevnt in VideoEvents)
                {
                    if (vevnt.ActiveTake.Name != videoName)
                        continue;
                    VideoCut cut = new VideoCut();
                    // Media name
                    var videoMedia = vevnt.ActiveTake.Media;
                    videoName = vevnt.ActiveTake.Name;
                    // Video envelope
                    Envelope VelEnv = VegasUtil.FindVEEnvelope(vevnt, EnvelopeType.Velocity);
                    cut.startFrame = (int)vevnt.ActiveTake.Offset.FrameCount;
                    // Total frames in vegas (NOT CUT!)
                    long totalFrames = vevnt.End.FrameCount - vevnt.Start.FrameCount;
                    if (VelEnv != null)
                    {
                        // i = currentFrame
                        for (int i = 0; i < totalFrames; i++)
                        {
                            double frameNumber = 0.0;
                            for (int f = 0; f < i; f++)
                            {
                                Timecode valueAt = Timecode.FromFrames(f);
                                frameNumber += VelEnv.ValueAt(valueAt);
                            }
                            Timecode currentFrame = Timecode.FromFrames(i);
                            var timescale = VelEnv.ValueAt(currentFrame);
                            cut.endFrame = (int)Math.Round(frameNumber, MidpointRounding.AwayFromZero);
                            if (!cut.velocity.ContainsKey(cut.endFrame))
                                cut.velocity.Add(cut.endFrame, timescale);
                        }
                        cut.endFrame += cut.startFrame;
                    }
                    veloSequence.Cuts.Add(cut);
                }
            }
            // Loop over tracks
            string outputPath = VeloSaveFileDialog.ShowSaveFileDialog("Velocity file (*.velo)|*.velo",
                                                   "Save Velocity // © SHEILAN",
                                                   videoName + "_cut");

            veloSequence.SaveVelocityBin(outputPath);
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
        }
    }
}
