### Composite Design Pattern

The composite design pattern ensures that the single component and the group of different components act similarly in a hierarchical structure, that is, the use of a group of objects that are different from each other as if they are a single whole object.

#### When should we use the Composite design pattern?
- When we have an irregular object structure and a combination of these objects.
- When the client wants to operate without seeing the differences between individual objects and object groups.
- If the user has to use a collection of objects of the same type or different types, he can use a compound pattern to get rid of confusion and confusion.
 
 #### Features
 - <strong>Component</strong> ==> It is an abstract class that describes simple and complex objects in the tree structure and the common areas of these objects.
 - <strong>Composite</strong> ==> Class that corresponds to complex objects in the tree structure. If we need to give a more technical explanation, it represents complex objects where Components come together and form sub-breaks in the tree structure.
 - <strong>Leaf</strong> ==> It is a single Component object, which is the most basic element in the tree structure and does not contain sub-breaks. That is, it refers to the simple object.
