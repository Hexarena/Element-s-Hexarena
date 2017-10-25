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
        RedBlock = 4,
        GreenBlock = 8,
        StatusCount = 6
    }
}
