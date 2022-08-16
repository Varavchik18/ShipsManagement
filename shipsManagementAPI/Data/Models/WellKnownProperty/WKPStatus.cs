using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shipsManagementAPI.Data.Models.WellKnownProperty
{
    public static class WKPStatus
    {
        public static string Created { get; set; } = "Created";
        public static string Reviewed { get; set; } = "Reviewed";
        public static string Approved { get; set; } = "Approved";
        public static string Sent { get; set; } = "Sent";
        public static string ReviewedByReceiver { get; set; } = "Reviewed by receiver";
        public static string Received { get; set; } = "Received";
        public static string Closed { get; set; } = "Closed";
    }
}