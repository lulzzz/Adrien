# Numerics backend

This namespace defines the key interfaces that must be implemented
in order to perform actual calculations.

The numerical backend is provided by an implementation of `ITileCompiler`,
which - in practice - require `ITensor` and `IKernel` implementations as
well.

Binding data-wise the external world the tensors is done through `IDataBinder`
although, this logic is expected to be left to the client implementation as
the binding is typically data specific.

