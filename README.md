# Project with ASP.NET Core 6 and SQLite db   
___
## How to use application
Using the application is very simple as it has a convenient and intuitive interface thanks to Swagger.
The application is quite simple to run even without debugging and you will have a new page in the browser.
Next, you will see the following commands for data manipulation:
  - __Post__ \- the command adds an address to the database (all fields are required)
  - __Get__ \- returns a list of all addresses in the database
  - __Get{id}__ \- returns the address at the specified index
  - __Put{id}__ \- provides the ability to edit the address at the specified index
  - __Delete{id}__ \- deletes the address at the specified index 
    
All changes are reflected in the database. You don`t need to have database in project folder, program will create it.    
Overloading the Get method \- you can specify the name of the field by which all addresses will be sorted, as well as the sorting direction ( 1 - ascending, 2 - descending)  
Happy using!
___
## At the moment I'm working on adding geolocation to this project:)
