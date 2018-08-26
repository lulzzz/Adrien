# Automatic Differentiation

The automatic differentiation (AD) of interest is the reverse AD. 
In Adrien, the reverse AD is seen as a tile-to-tile transformation.

The class `AutomaticDifferentiation` is intended to perform such a
transformation.

This namespace is introduced to isolate the complexity of the reverse 
AD from the rest of the library. Except for `AutomaticDifferentiation`, 
the elements of this namespace are not intended to be used externally.
