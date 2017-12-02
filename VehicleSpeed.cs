using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace highwaytraffic
{
    public class VehicleSpeed
    {
        
        [JsonProperty(PropertyName = "vehicleNumber")]
        public string VehicleNumber { get; set; }

        [JsonProperty(PropertyName = "speed")]
        public double Speed { get; set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; set; }

    }
}
