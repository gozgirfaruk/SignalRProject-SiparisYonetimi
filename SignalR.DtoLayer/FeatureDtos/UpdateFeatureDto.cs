﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DtoLayer.FeatureDtos
{
    public class UpdateFeatureDto
    {
        public int FeatureID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
