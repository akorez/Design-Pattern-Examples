### Facade Design Pattern
It is a design pattern designed to make it easier to use by abstracting the classes that make up the parts of a subsystem from the client. It is aimed to make the complex and detailed sub-system available to users by providing a simple interface.

As can be seen from the code section; Bank, Credit and Central Bank subclasses of the complex system. By abstracting them into the Facade class, a single and simple class, the Facade class, is presented to the user.

 #### IMPORTANT:
- Classes in the subsystem must be independent of each other and the Facade class.
- Facade must contain our classes and use their functionalities while performing the operation.
