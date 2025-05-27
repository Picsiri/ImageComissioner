using ImageCommissioner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageComissioner
{
    public class ProjectData
    {
        public required string SourcePath { get; set; }
        public required string DestinationPath { get; set; }
        public required bool Recurse { get; set; }
        public required bool Zipit { get; set; }
        public required List<string> Tags { get; set; } = [];
        public required TaggedImage[] TaggedImages { get; set; } = [];
    }

}
