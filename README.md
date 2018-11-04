+ Change value "connectionStrings" on CCNLTHD2018/Web.config to connect to database
+ Get all entities by route GET"api/{controller}", get an entity by PrimaryKey: GET"api/{controller}/{id}"
+ Add an entity: POST"api/{controller}" + Entity raw json object ==> Response created object with status 201
+ Update an entity: PUT"api/{controller}/{id}" + Entity raw json object ==> Response status 204
+ Delete an entity: DELETE"api/{controller}/{id}" ==> Response status 200 with deleted entity