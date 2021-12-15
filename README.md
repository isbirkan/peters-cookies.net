# Peter's Cookies
## A very smart cookie order decision maker

<p align="left">
  <img width="250" height="152" src="https://tenor.com/view/typing-jim-carrey-fast-busy-gif-4903969.gif">
</p> 

---
### **Hello**,  
### These are just some small mentions from my side, when initially working on the project, as a classic **Web Api**:
- After restructuring and renaming the project files I had some issues with the package installation and building the project. They were fixed after a Nuget cache clear and a force reinstall
- Was thinking of migrating to **.NET Core** since most of the stuff (like Dependency Injection for example) come out of the box, but didn't want to go too far with "improving" the project since I didn't know where the fine line of improving is
- Updated the Api configuration files
- Added **Swagger** so that I (and you) can easily test out the endpoints from its UI. There is also a request example generated
- Didn't work much with the **CQRS** pattern but recognized it, since I've recently read some articles about them
- Couldn't manage to find a working input for the GetQuotes and changed it to GenerateQuotes as a POST endpoint, which to be honest, made more sense to me from a business point of view, but ultimately the service call is a get
- Placed some DataAnnotations in place so that we can validate what we receive on the request
- Introduced a **Helper (Extension)** for detecting Sunday and Public Holidays and later saw that something was done already
- Had a real challenge with finding the cheapest possible combination of orders and that is where I spent a whole lot of my time. I am sure that what I did is not the perfect and optimal solution, but that is what I came up with. I saw that there are some specialized algorithms that can do this more easily, but I didn't study them
- I rushed to make the Order endpoint work and I am sure that it isn't the cleanest code, but ultimately it correctly creates the request payload for the Order endpoint
- Although, I couldn't make the Request for Order to work and the Server Error doesn't offer too much information. Tried a correct example (at least from my point of view) in their Swagger UI and it still didn’t work
### What more could have been done
- Introduce **Dependency Injection**, but doing this for this project implied some templating, which takes time
- Have a better **HttpClient** builder with automatic disposal (using) or using the **HttpClientFactory** which is the Microsoft recommended way
- Probably have a dynamic query and command executor, which serves the corresponding Supplier. Something like **MediatR** would probably work in this scenario
- Introduce an **Application** layer with managers, for data validation and manipulation, between the **Infrastructure** and **Api** layer
---
### **Hello again**
### At this point I got two more days to work on the project. My loyal companion also wanted to help me out and I can assure you that he didn't eat my homework

<p align="left">
  <img height="400" src="https://i.imgur.com/BGjFAoA.jpg">
</p> 

### Some other mentions after continuing to work on the project:
- Migrated to **.NET Core**, since most of the improvements could be done much easier and the project loads and runs faster. We have **Dependency Injection** and **Code Analyzer** out of the box, which I've set up for this project
- Used the **Newtonsoft.Json** library by default for all of the serialization/deserialization processes. Even though the default serializer for .NET Core 3 and upwards is growing, it is still not handling some of the processes quite well (eg. Enums)
- Separated the request models for the different calls
- Introduced **AutoMapper**, in order to make the object to object mapping much easier, especially between the Api and the Application layer, where we have objects with the same properties, but left the validation only on one side
- Used an **Assertion** helper in order to verify that arguments are not null. I probably missed some places
- Migrated logic out of the controllers into the Application layer
- After introducing **asynchronous** calls throughout all of the layers, I encountered a problem where I was simultaneously writing to a list of quotes from 3 service calls and returning the list without waiting for the processes to finish and the list to be completed. Made the calls in parallel like before, but populated the list after all of the calls were actually finished
- Initially wanted to use **typed http clients**, which would also inject the corresponding service, but it didn't work for me somehow. Ended up having the same url for all three of the services, which was the one for Supplier C. Moved on to named http clients and used to factory inside each supplier to get the client
- Ultimately started abstracting/decoupling the service layer and couldn't use the named clients anymore. I've just set up the url and headers in each service constructor. This could have maybe been moved to the appsettings or in a cloud infrastructures environment settings
- Managed to make the Order Post work, which was previously getting a 500 from the endpoint. Found out that the Brand was always being set to the same value and probably some type of cookies weren't found by that brand
- Introduced a **ServiceBase** class with generic Get and Post methods in order to combat the code repetition even more
- I am sure more can be done and I probably didn't extend the CQRS by the pattern standard, but this is what I came up with and I am proud that I made the application cleaner, faster and fully working
--- 
### Continued working on the project since it flamed my interest
- Migrated to .NET 6, which again faster and cleaner
- All of the classes have **file-scoped namespaces**, which implies getting rid of one level of indentation