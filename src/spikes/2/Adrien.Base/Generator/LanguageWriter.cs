using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Adrien.Notation;
using Adrien.Trees;

namespace Adrien.Generator
{
    public abstract class LanguageWriter<TOp>
    {
        protected Dictionary<string, object> Options { get; }

        protected abstract Dictionary<TOp, string> OperatorMap { get; }

        
        protected LanguageWriter(Dictionary<string, object> options = null)
        {
            if (options != null)
            {
                this.Options = options;
            }
        }


        public virtual string WriteValueText(ITreeValueNode vn)
        {
            switch (vn.NodeType)
            {
                case ValueNodeType.TENSOR:
                    return vn.Label;
                case ValueNodeType.INDEXSET:
                    IEnumerable<ITerm> indices = vn.ValueAs<IEnumerable<ITerm>>();
                    return indices.Select(i => i.Label).Aggregate((a, b) => a + ", " + b);
                default: throw new Exception($"Unknown value type: {vn.NodeType.ToString()}.");
            }
        }

        public virtual string WriteOperator(TOp op, params string[] operands) => string.Format(OperatorMap[op], operands);

        public virtual string GetOperatorText(ITreeOperatorNode<TOp> on) => OperatorMap[on.Op];

    }
}
