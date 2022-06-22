# PowerDiaryAPI
Chat room interface in which the user can view chat history at varying levels of time-based aggregation
=======================================================================================================

## CI

![](https://github.com/UcheIgbokwe/PowerDiaryAPI/workflows/Build%20Pipeline/badge.svg)

AUTHOR - Uche Igbokwe

Application was built using clean architecture, CQRS and SOLID principles.

## DEPENDENCIES/PREREQUISITIES

* .NET 6.0
* Mediator
* Repository Pattern
* XUnit
* Ensure port 8000, 5122 are available

## SETUP

> **Note**: Begin by cloning the project and navigate into the PowerDiaryAPI folder. Ensure to have .NET 6 or above running on your device.

# START PROJECT VIA DOCKER:
Navigate to the root folder and run the command.
```
docker compose up 
```
The page comes up on
```
http://localhost:8000/swagger/index.html
```
  * To begin, authenticate with email and password.
  * Register the token gotten from the result in the Authorize button at the top.
  * Go ahead and run the GetChatByMin and GetChatByHour.

# START PROJECT MANUALLY:
To startup the API project, follow these steps:

* Navigate to the [API](src/API) project folder
```
cd src/API
```
```
dotnet build
```
* Run the command below and listen on https://localhost:8000/swagger:
```
dotnet run
```

To run the test, follow these steps:

* Navigate to the [Tests](src/Tests) project folder
```
cd src/Tests
```
```
dotnet build
```
```
dotnet run
```


Incase of blockers, kindly contact me via: uchehenryigbokwe@gmail.com.
