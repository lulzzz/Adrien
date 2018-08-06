using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Adrien
{
    public interface ILog
    {
        void Info(string messageTemplate, params object[] propertyValues);

        void Debug(string messageTemplate, params object[] propertyValues);

        void Error(string messageTemplate, params object[] propertyValues);

        void Error(Exception e, string messageTemplate, params object[] propertyValues);

        void Verbose(string messageTemplate, params object[] propertyValues);

        void Warn(string messageTemplate, params object[] propertyValues);
    }
}
