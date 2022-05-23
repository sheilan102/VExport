using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VExport
{
    public interface IVideoHandler
    {
        /// <summary>
        /// NOT IMPLEMENTED YET.
        /// Takes a video event, envelope type and returns the requested envelope
        /// </summary>
        /// <param name="vevnt">Selected video.</param>
        /// <param name="etype">Type of the requested envelope/effect </param>
        /// <returns>Video effect of type <paramref name="etype"/>.</returns>
        //Envelope FindVEEnvelope(VideoEvent vevnt, EnvelopeType etype);
    }
}
