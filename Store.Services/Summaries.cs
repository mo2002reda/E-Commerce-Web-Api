/*
1)Create Entities + Base Entity
2)Create DbContext 
3)add Migrations + Update DataBase
------------------------------------
&&&&&& Repository &&&&&&&
-----------------------
1)Add DataFiles and Read it in Healper Folder ==>ApplySeeding Class
2)Create interfaces ==> IGeneric + Iunite : has all interfaces
3)Create Repositories ==> Generic :implement IGeneric Interface + Unite : has Function to (find||Create)
Generic Repository
4)Add AutoMapper Library at Repository
5)Mapped All entities which Required
6)Add Services in program File 
    builder.Services.AddScoped<IProductService, ProductService>();      (Register all interfaces)
    builder.Services.AddAutoMapper(typeof(ProductProfile));             (Regester AutoMapper Profile)



------------------------------------------------------------------------------------------------------------
1)Spacification Pattern : used to git rid of lizzy loading by put all Requirements in class to can use it in generice repository such as : include(),Criteria of delegate,ordring 

1.1)create ISpacification Interface that have properities: (List Of includes ,Criterias)  
Criteria : where الحاجات اللي بتتبعت جوه ال
Criteria => Expression<func<T,bool>> //func is adelegate used in where expression and take
T => input /bool => return type
Includes => Take input and return Objects
  
1.2)Create BaseSpacification Class : implement ISpacification Interface

1.3)Entity Spacification(Product Spacification): have properities which enter at experission

1.4)ProductWithSpecifications ==> inherit from BaseSpacification and execute Expressions 

1.5)SpacificationEvaluator : is acollection of all Queries

------------------------------------------------------------------------------------------------------
&&&&&&&&&&&&&  Cashing &&&&&&&&
---------------------------------
1)Distributed Cashing : store date in Clustered Servers
2)Data Cashing :  Data caching allows you to store data in memory for quick access ,In this approach, cached data is stored directly in RAM
3)flash cache : also called solid-state drive caching, employs NAND flash memory chips (a non-volatile storage
4)Web browser Cashing





 
*/
