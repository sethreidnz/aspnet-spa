# ASPNET Core SPA

This is an example project showing you how to get up and running with ASPNET Core to serve up a single page app (SPA). It takes advantage
of the Owin pipeline to serve up the output of the client applications build process in from the wwwroot of the server application.

I have setup 

## Quick start

**Prerquisites**

- Node >=6 - I Recommend using [nvm (Mac/Linux)](https://github.com/creationix/nvm) or [nvm for Windows](https://github.com/coreybutler/nvm-windows))
- .NET Core SDK - Download and install from the [.NET Core Homepage](https://www.microsoft.com/net/core)
- Set the ASPNETCORE_ENVIRONMENT=Development on your system

### Running the server

You can do this in various ways:

**Using the command line**

From the root of the project:

``` lang-bash
cd server
dotnet restore
dotnet run
```

**From visual studio**

Open the file `server/DotnetSpa.csproj` and press F5.

**From Visual Studio Code**

Open the folder in Visual Studio Code and press F5 to launch

> **NOTE:** This is an out of the box app created using `dotnet create webapi` with some changes to the Startup.cs to include
> handling of CORS requests from our client during development and serving the client app and passing through client routing to the app
> using a simple piece of middleware and the 'Microsoft.AspNetCore.StaticFiles' Nuget package.

### Running the client

From the root of the project:

``` lang-bash
cd client
npm install 
npm start
```

> **NOTE:** During development the client is using the API at [http://localhost:3000](http://localhost:3000) because of the '.env.development' file that
> defines this and is determined in the file '/client/api/apiConfig'. For more details see [the Create React App Guide](https://github.com/facebookincubator/create-react-app/blob/master/packages/react-scripts/template/README.md#adding-development-environment-variables-in-env)

## Creating production build

This application is made up of two parts the 'client' and the 'server'. For simplicity I have made the 'postbuild' step of the client
build copy the output files into the 'wwwroot' folder of the server application. 

To test the application with the build files run the following from the root of the project:

``` lang-bash
cd client
npm run build
```

> **NOTE:** This will result in the building of the JavaScript app and placing of the 'client/build' folder contents into 'server/wwwroot'. Normally
> in a real world app I would do this step as a build step in the build process but this is easier for example's sake.

From the root of the project again run:

``` lang-bash
cd server
dotnet run
```

This will serve the build files from the client project at [localhost:5000](localhost:5000).