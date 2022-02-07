### Strategy Desing Pattern

If a function has more than one way of doing it, it is a design pattern that can be used when it is desired to use this functionality with different versions.

When we have more than one concrete strategy class that does the same job in different ways, we present them to the client through a strategy class, give the strategy class the interface that is the common ancestor of these concrete types, and when a new one is added to these concrete types in the future, all we have to do is from this concrete type common interface. derivation will suffice.
