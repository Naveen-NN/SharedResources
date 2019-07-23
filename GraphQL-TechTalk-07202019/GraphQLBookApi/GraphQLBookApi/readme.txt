Step 1: Below are the nuget packages which needs to be installed 
----------------------------------------------------------------
a. GraphQL
b. GraphQL.Server.Transports.AspNetCore
c. GraphQL.Server.Ui.Playground



Step 2: GrapQL service to be configured in order has been listed in order in startup.cs
----------------------------------------------------------------------------------------


Step 3: Build and run the applicaiton  
---------------------------------------------------------------------------------------- 
To access the ui playgroud place this link  in browser address bar  
http://localhost:61148/ui/playground


Step 4: Running queries in playground 
----------------------------------------------------------------------------------------

a. Get all books  

{
  books{
    id
    name
    price
    author{
      name
    }
  }
}

b. Get book by id  

{
	book(id:1){
    name
    price
    author{
      name
    }
  }
}

c. Create book 

mutation{
  createBook(book:{bookname: "book 6", price: 22, authorid: 1}){
          id
          name
      }
  }


d. Delete book by id

mutation{
  deleteBook(id:1){
    name
  }
}