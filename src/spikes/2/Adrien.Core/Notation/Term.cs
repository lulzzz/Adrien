using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Adrien.Notation
{
    /// <summary>
    /// Abstracts a notation term
    /// </summary>
    public abstract class Term
    {
        #region Constructor
        internal Term()
        {
            Id = Guid.NewGuid().ToString("N");
        }

        internal Term(string name) : this()
        {
            Name = name;
        }

        internal Term(char name) : this()
        {
            Name = new string(name, 1);
        }


        internal Term(Term t)
        
        {
            this.Id = t.Id;
        }
        #endregion

        #region Properties
        public string Id { get; protected set; }

        public Name Name { get; protected set; }

        internal abstract Name DefaultNameBase { get; }

        internal abstract Expression LinqExpression { get; }
        #endregion

        #region Methods
        protected string GetName(int index, string indexNameBase)
        {
            indexNameBase = indexNameBase != string.Empty ? indexNameBase : (string) DefaultNameBase;
            int Z = (int)Char.GetNumericValue('Z');
            int z = (int)Char.GetNumericValue('z');
            if (indexNameBase.Length == 1)
            {
                char c = indexNameBase[0];
                int n = (int)Char.GetNumericValue(c) + index;
                int upper = Char.IsUpper(c) ? Z : z;
                if (n > upper)
                {
                    throw new ArgumentOutOfRangeException("Auto-generated name past Z.");
                }
                else
                {
                    return new string(Convert.ToChar(n), 1);
                }
            }
            else
            {
                return indexNameBase + index.ToString();
            }
        }
        #endregion

        #region Operators
        public static implicit operator Expression(Term e)
        {
            return e.LinqExpression;
        }
        #endregion
    }
}
