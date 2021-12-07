using System;
using System.Collections.Generic;
using System.Text;

namespace D2RDropCalc.Server.Models.DTOs.Error {
    public enum ErrorReason {
        Unauthorized,
        ServerError,
        ValidationError,
        InvalidData
    }
}
