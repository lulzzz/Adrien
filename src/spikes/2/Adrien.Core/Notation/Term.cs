using System;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Adrien.Notation
{
    /// <summary>
    /// Abstracts a notation term
    /// </summary>
    public abstract class Term : IEquatable<Term>
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
        public bool Equals(Term other)
        {
            return this.Id == other.Id;
        }

        protected string GenerateName(int index, string indexNameBase)
        {
            indexNameBase = indexNameBase != string.Empty ? indexNameBase : (string) DefaultNameBase;
            int A = 'A';
            int a = 'a';
            int Z = 'Z';
            int z = 'z';

            if (indexNameBase.Length == 1)
            {
                char c = indexNameBase.First();
                int n = c + index;
                int lower = Char.IsLower(c) ? a : A;
                int upper = Char.IsLower(c) ? z : Z;
                if (n < lower || n > upper)
                {
                    throw new ArgumentOutOfRangeException("Auto-generated name past limit.");
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
