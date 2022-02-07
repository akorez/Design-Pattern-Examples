### Builder Design Pattern

It is used to create objects of different shapes, so that the client can perform the creation by specifying only the object type.

#### Features
- <strong>Product</strong> ==> It is the object that we want to get as a result of construction.
- <strong>ConcreteBuilder</strong> ==> It creates the object we call Product as in the example below. It is the class that provides the basic features and hardware of the Product to be created.
- <strong>Builder</strong> ==> Provides the interface for the creation of the Product object. It is Interface or Abstract class. There is an inherited situation with the ConcreteBuilder object.
- <strong>Director</strong> ==> As a result of our design, it responds to the object production request by the Client over a Builder reference.
