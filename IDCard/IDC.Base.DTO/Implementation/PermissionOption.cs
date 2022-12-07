using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IDC.Base.DTO.Implementations
{
    public class PermissionOption
    {
        public FeatureStatus Status { get; set; }

        public bool IsVisible { get; set; }

        public string Message { get; set; }

    }
}
