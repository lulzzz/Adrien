using System;
using System.Linq;
using System.Linq.Expressions;

namespace Adrien.Notation
{
    /// <summary>
    /// Abstracts a notation term
    /// </summary>
    public abstract class Term : ITerm, IEquatable<Term>
    {
        public string Id { get; protected set; }

        public Name Name { get; protected set; }

        internal abstract Name DefaultNameBase { get; }

        internal abstract Expression LinqExpression { get; }

        private static readonly int A = 'A';
        private static readonly int a = 'a';
        private static readonly int Z = 'Z';
        private static readonly int z = 'z';

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
        
        public bool Equals(Term other)
        {
            return this.Id == other.Id;
        }

        protected string GenerateName(int index, string indexNameBase)
        {
            indexNameBase = indexNameBase != string.Empty ? indexNameBase : (string) DefaultNameBase;

            if (indexNameBase.Length == 1)
            {
                char c = indexNameBase.First();
                int n = c + index;
                int lower = Char.IsLower(c) ? a : A;
                int upper = Char.IsLower(c) ? z : Z;
                if (n < lower || n > upper)
                {
                    throw new Exception("Auto-generated name past last letter of alphabet. Consider using a numeric name base like a0.");
                }
                else
                {
                    return new string(Convert.ToChar(n), 1);
                }
            }
            else if (indexNameBase.Length == 2 && Char.IsLetter(indexNameBase[0]) && Char.IsNumber(indexNameBase[1]))
            {
                ++index;
                return new string(indexNameBase[0], 1) + index.ToString();
            }
            else throw new ArgumentException($"Unknown name base {indexNameBase}");
        }
        

        public static implicit operator Expression(Term e)
        {
            return e.LinqExpression;
        }
   
    }
}
