Land Selling Website
The developed web system has a server part written in C # 9.0 in the environment of MS Visual Studio 2022. To save data on the server part, the MS SQL Server database is used.
The client part is written using the React library in the TypeScript programming language in the MS Visual Studio Code programming environment.
Successful operation of the web system requires the appropriate hardware characteristics, which are given in the specifications and you need to download the appropriate files

1. Software components

The developed web system has a server part written on C # 9.0 in the environment of MS Visual Studio 2022.
 The MS SQL Server database is used to store data on the server part.
The client part is written using the React library in the TypeScript programming language in the MS Visual Studio Code programming environment.
Successful operation of the web system requires the appropriate hardware characteristics, which are given in the specifications and you need to download the project files.

2. Files required for the correct operation of the software:
The project contains two solutions in two folders.
The first folder with the server part of the project "LandSellingApi".
It contains a set of projects in one solution. It is a system module for working with the client part and provides communication with the database.
Contains the logic of the web system at the level of working with data. And provides access to the database.
The second folder with the client part of the project "LandSellingWebsiteClientApp".
Contains a set of files with react components to implement the visual part of the UI. Contains sets of queries to the server part to provide web system data.
It makes sense to do the client part.
The project also has a database backup.

3. Software installation
  To start the web system, you must first start the server part. To do this, you need to open the server part of the project in MS Visual Studio 2022.
Next, you need to deploy the database. To do this, open the PM Console and enter the command "update-database". The database for the server part will then be deployed.
Next in the project you need to click "Run".
To start the client part, you need to open the project folder and enter the command "npm install" and "npm start" in the command window.
The main client page will then open in the browser.

4. Analysis of possible errors
In case of malfunction of the web system or part of the web system, it is necessary to check the correctness of the installed packages in the client and server parts.
You also need to check all files.