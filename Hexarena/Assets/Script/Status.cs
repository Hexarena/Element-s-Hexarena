using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Script
{
    public enum BlockObjStatus
    {
        NONE = 0,
        HasFigure = 1,
        CanMove = 2,
        RedBlock = 8,
        GreenBlock = 4,
        StatusCount = 6
    }
}
