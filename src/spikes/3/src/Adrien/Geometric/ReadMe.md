# Geometic Inference

The geometic inference is the process that finds a unique
solution expressed as shapes (for variables) and ranges
(for indices) for a compute graph.

The solver intended externally used is `GeometricSolver`.

This namespace is introduced to isolate the complexity of
the geometric inference from the rest of the library. Except
for the solver itself, the elements of this namespace are
not intended to be used externally.
