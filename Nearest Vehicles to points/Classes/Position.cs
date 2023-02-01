using System;
using System.Collections.Generic;
using System.Text;

namespace Nearest_Vehicles_to_points.Classes
{
    /// <summary>
    /// Vehicle Position
    /// </summary>
    public class Position
    {
        public int PositionID { get; set; }
        public string VehicleRegistration { get; set; }
        public float Latitude { get; set; }
        public float Longitute { get; set; }
    }
}
