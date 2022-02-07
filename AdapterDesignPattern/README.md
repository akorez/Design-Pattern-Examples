### Adapter Design Pattern

As can be seen in the Design Pattern codes; The DbError and ServiceError classes implement the IError interface with a common structure. The fax class, on the other hand, has a different structure. However, it is desired to include the IError structure in the fax class. In this case, it is the design pattern used.


A class called FaxAdapter is created and this class implements the IError interface. Also, an instance of the Fax class is used in it. Thus, the Fax class is adapted to the IError structure. In the Main part, an instance of the Fax class is sent to this class.
