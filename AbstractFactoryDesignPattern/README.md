### Abstract Factory Design Pattern
It provides the production of more than one relational object, not by a single interface, but by defining a different interface for each product family. In cases where we have to work with more than one product family, the Abstract Factory Design Pattern would be the right approach to abstract the client from these structures.

#### Features
- <strong>Abstract Product</strong> ==> It is the abstract class of the products to be produced. It carries all member structures in certain products as signature and implements it into Concrete product structures.
- <strong>Concrete Product</strong> ==> The actual concrete classes of the product family that the client wants to produce.
- <strong>Abstract Factory</strong> ==> It is the structure that provides interface to the factory classes that will create the product family
- <strong>Concrete Factory</strong> ==> Factories that make up the main product family.
