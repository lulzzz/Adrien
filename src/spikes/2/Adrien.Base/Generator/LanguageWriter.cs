using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Generator
{
    public abstract class LanguageWriter<TOp>
    {
        public int Length => Writer.Length;

        protected Dictionary<string, object> Options { get; }

        protected readonly StringBuilder Writer = new StringBuilder();

        protected LanguageWriter(Dictionary<string, object> options = null)
        {
            if (options != null)
            {
                this.Options = options;
            }
        }


        
        public void Write(string text)
        {
            this.Writer.Append(text);
        }

        public void WriteFormatted(string format, params object[] values)
        {
            Writer.AppendFormat(format, values);
        }

        public void WriteOperator(TOp op)
        {
            Writer.Append(op.ToString());
        }
    }
}
