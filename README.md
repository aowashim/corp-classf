# 🛒 Corporate Classifieds 👨🏻‍💻

An organization has to create an Classifieds App for its employees to allow posting 
of ads on a particular product that the employees can buy and sell within the 
employee community. The employee who posts an offer in Classifieds Application 
is a seller and an employee who shows interest is a consumer. Though the real 
selling doesn’t happen over the app, an engagement between the seller and the 
consumer is created, by liking/commenting to the offer. 

Created By,
Owashim Akram (2143321) - Team Lead
Anuj Bhagat (2143994)
Ashish Sahu (2141041)
Raktim Das (2144021)

**************************************************************************************************

In this Corporate Classifieds project, there are four microservices and a client web-app 
made by React to call all the microservices and retrieve and post data to the Corporate classifieds database.

The four microservices with their operations are as follows:

1. Authorization Microservice (Auth API) - Created by Owasim Akram
SignUp - Users/Employees can register their details into the project database and use these details to proceed to login into the app.
LogIn - Users/Employees can login into the app using the registered credientials and use all the services offered by the app.

2. Employee Microservice (Employee API) - Created by Anuj Bhagat
ViewProfile - Users/Employees can view their profile and api provides data based on the given Employee Id.
ViewEmployeeOffers - Users/Employees can see the offers posted by them and api provides data for all the offers based on the given Employee Id.
ViewMostLikedOffers - Users/Employees can filter the top 3 offers based on the number of likes.

3. Offers Microservices (Offers API)  - Created by Ashish Sahu and Raktim Das
GetOffer - After logging into the app, the method of this api returns all offer posts available in the app.
GetOfferDetails - Using this method, Users/Employees can view the particular offer details and api returns offer details based on the given offer Id.
GetOfferByCategory - Users/Employees can filter the offer by category and api return offer based on the offer-category Id.
GetOfferByTopLikes - Users/Employees can filter all offers by number of likes.
GetOfferByPostedDate - Users/Employees can get all the offers with its deatils based on the start date of the offer.
EngageOffer - Whenever User/Employee likes or comments on any offer of the app, the engagement date is updated on the database.
EditOffer - Users/Employees can edit offer details if the offer is posted by them only.
AddOffer - Users/Emloyees can add their own offer into the app database using this method of api.

4. Points Microservice (Points API) - Created by Raktim Das
FetchPoints - Using this method of API, the points allocated to the particular User/Employee can be fetched from the app-database.
PointsCalculations - Using this method Points are calculated based on the logic mentioned in the requirements document
and also posted on the app-database.

Testing of all four microservices are done using xUnit and Moq frameworks and almost more than 95% code coverage is performed.
Logging of all four microservices are done using Log4net framework.
The above two operations are performed in all the microservices by Raktim Das and Anuj Bhagat.
Exception handeling is also performed pretty well in all microservices by their respective creators.

The Front-end client in react is created by Owasim Akram and Ashish Sahu
- the react client is used to fetch all apis and display data in a most suitable way
- the UI of the app is also made by considering user-experience, user-interaction with the features off app, etc.

Here, Azure Sql Database is created by Anuj Bhagat on Microsoft Azure Cloud.
All Azure App services and service plans for all for microservices are created by Anuj Bhagat on Microsoft Azure Cloud.

********************************************************************************************************************

HOW TO RUN THIS APP:

1. Extract the zip file.
2. Open client folder in Visual Studio code of your local machine
3. run "npm install" command on terminal window of Visual Studio code to install all the node modules
4. run "npm start" command on terminal window of Visual Studio code to run this app
5. User can see home page of the app and can click on the "Log In" button to log in into the app.
