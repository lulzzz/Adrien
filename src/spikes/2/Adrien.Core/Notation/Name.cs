using System;
using System.Collections.Generic;
using System.Text;

namespace Adrien.Notation
{
    public class Name
    {
        #region Constructors
        public Name(string label, int index = 0)
        {
            Label = label;
            BaseIndex = index;
        }
        #endregion
        public Name(int baseIndex) : this(new string(Convert.ToChar(baseIndex), 1)) {}

        public string Label { get; protected set; }

        public int BaseIndex { get; protected set; }
        
        public static Name Base(int b) => new Name(b);

        #region Operators
        public static implicit operator string (Name n) => n.Label;

        public static implicit operator Name (string s) => new Name(s);
        #endregion
    }
}
