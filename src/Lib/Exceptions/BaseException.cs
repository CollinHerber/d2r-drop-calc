using System;

namespace D2RDropCalc.Server.Lib.Exceptions {
    public class BaseException : Exception {
        public BaseException(string message) : base(message) { }
    }
}
