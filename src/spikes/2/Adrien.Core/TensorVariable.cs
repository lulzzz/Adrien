using System;
using System.Buffers;
using System.Collections.Generic;
using System.Text;

using Adrien.Notation;

namespace Adrien
{
    public class TensorVariable<T> where T : unmanaged
    {
        public Tensor Term { get; set; }
        public TensorShape<T> Shape { get; protected set; }
        public Memory<T> Memory { get; protected set; }

        public string Name => Term.Name;

        
        public TensorVariable(Tensor term, TensorShape<T> shape)
        {
            Term = term;
            Shape = shape;
        }
    }
}