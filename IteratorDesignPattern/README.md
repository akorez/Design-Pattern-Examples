### Iterator Design Pattern

<strong>Aggregate </strong> ==> It is the interface that requires the creation of an Iterator from an IIterator interface type to navigate through the dataset.
    
<strong>Iterator</strong> ==> This interface determines all terms and signatures of navigating the dataset. In other words, it acts as an enumerator. In summary, it defines the operations/controls/conditions/issues necessary to obtain the data/objects while looping through the dataset we have.

<strong>ConcreteAggregate</strong> ==> It is the object that contains the dataset. Creates the Iterator object by implementing the Aggregate interface.

<strong>ConcreteIterator</strong> ==> It is the class that implements the Iterator interface, contains iteration methods and properties, and undertakes the enumerator function that we mentioned above.
