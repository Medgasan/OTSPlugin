using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTSPlugin
{
    public class OTSResponse
    {
        /// <summary>
        /// The customer ID, which represents you.
        /// </summary>
        public string CustId { get; set; }

        /// <summary>
        /// The unique key for the secret you created. This is the key that you can share.
        /// </summary>
        public string Secret_Key { get; set; }

        /// <summary>
        /// The time-to-live (TTL) that was specified when the secret was created.
        /// </summary>
        public int Ttl { get; set; }

        /// <summary>
        /// The time the metadata was created, in Unix time (UTC).
        /// </summary>
        public long Created { get; set; }

        /// <summary>
        /// The time the metadata was last updated, in Unix time (UTC).
        /// </summary>
        public long Updated { get; set; }

    }
}
