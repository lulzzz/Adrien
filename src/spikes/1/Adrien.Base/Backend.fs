module Adrien.Backend

type Backend<'ScalarT, 'VectorT, 'MatrixT, 'TensorT when 'ScalarT: struct> = { Scalar  : ScalarBackend<'ScalarT> }

and ScalarBackend<'T when 'T: struct> = 
    abstract member Multiply : 'T * 'T -> 'T
    (*
    abstract member AddScalar : 'T * 'T -> 'T
    abstract member SubtractScalar : 'T * 'T -> 'T
    abstract member DivideScalar : 'T * 'T -> 'T
    *)