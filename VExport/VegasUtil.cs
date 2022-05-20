using ScriptPortal.Vegas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VExport
{
    internal class VegasUtil
    {
        public static Envelope FindVEEnvelope(VideoEvent vevnt, EnvelopeType etype)
        {
            foreach (Envelope env in vevnt.Envelopes)
            {
                if (env.Type == etype)
                {
                    return env;
                }
            }
            return null;
        }

        public static List<VideoEvent> GetSelectedVideoEvents(Vegas myVegas)
        {
            List<VideoEvent> videoEvents = new List<VideoEvent>();
            foreach (Track track in myVegas.Project.Tracks)
            {
                if (track.IsVideo()) // Check if track is video
                    foreach (TrackEvent evnt in track.Events) // Loop over events in the track
                        if (evnt.Selected) // Load if selected
                            videoEvents.Add((VideoEvent)evnt);
            }

            return videoEvents;
        }
    }
}
