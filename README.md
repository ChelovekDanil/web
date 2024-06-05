# Streaming service

This project is a streaming service that was inspired by Netflix.

## The service has
  - A displayed welcome page for visitors who are not registered
  - The ability for users to register and log in
  - The display of movies by category (popular/all, films, series) for registered users
  - A page provided for each specific movie
  - A profile page for user
  - CRUD (Create, Read, Update, Delete) operations for user

## Technology stack
  - Back-end: ASP.NET CORE WEB API
  - Front-end: React + js
  - Database: postgreSQL
  - Authentication: JWT

## How to start
  Clone this repository
  
  `git clone https://github.com/ChelovekDanil/web.git`

  ### For ASP.NET CORE WEB API
  Install the necessary NuGet packages
  
  `dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 8.0.1`
  
  `dotnet add package Microsoft.EntityFrameworkCore --version 8.0.1`
  
  `dotnet add package Microsoft.EntityFrameworkCore.Tools --version 8.0.1`
  
  `dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 8.0.0`
  
  `dotnet add package Swashbuckle.AspNetCore --version 6.5.0`
  

  Write your string connection in WebContext to connect postreQSL

  ### For React + js
  Install the necessary packages
  
  `npm i axios`

## How to run
  ### For back-end
  
  `cd server`
  
  `dotnet run`
  
  * you also need to specify port 7261 for localhost

  ### For Front-end
  
  `cd client`


  src
├── Interface
│   ├── Controllers
│   └── Models
├── Domain
│   ├── Entities
│   ├── Interfaces
│   └── Services
├── Application
│   ├── UseCases
│   └── Interfaces
└── Infrastructure
    ├── Configurations
    ├── Data
    ├── Services
    └── Security
  
  `npm start`
  
  * you also need to specify port 3000 for localhost
