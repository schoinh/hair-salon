# Eau Claire's Salon

#### _An MVC Web application using a local database for managing hair salon employees, clients, and appointments - August 9, 2019_

#### _By **Na Hyung Choi**_

## Description

This Web site helps a hair salon owner manage employees. The user can:
1. See a list of all stylists
2. Add, edit, and delete stylists
3. Add and view clients for a specific stylist
4. Add and view appointments for a specific stylist

## Setup/Installation Requirements

* This application requires MySQL.

1. Clone this repository:
    ```
    $ git clone https://github.com/schoinh/hair-salon.git
    ```
2. Open the App Settings file (HairSalon.Solution/HairSalon/appsettings.json) and ensure that the MySQL username and password match your MySQL credentials.

3. Log onto MySQL:
    ```
    $ mysql -u USERNAME -p PASSWORD
    ```

4. Set up a local database through MySQL:
    ```
    > CREATE DATABASE nahyung_choi;
    > USE nahyung_choi;
    > CREATE TABLE clients (ClientId serial PRIMARY KEY, StylistId INT, Name VARCHAR(45), Phone VARCHAR(45), Notes TINYTEXT);
    > CREATE TABLE stylists (StylistId serial PRIMARY KEY, Name VARCHAR(45), Phone VARCHAR(45), Specialties VARCHAR(255));
    > CREATE TABLE appointments (AppointmentId serial PRIMARY KEY, StylistId INT, ClientId INT, Date DATE, Notes TINYTEXT);
    ```

5. Navigate to the production folder (HairSalon.Solution/HairSalon)
6. Restore dependencies and run the application
    ```
    $ dotnet restore
    $ dotnet run
    ```
7. On a Web browser (Chrome recommended), navigate to http://localhost:5000

## Known Bugs
* The list of appointments for a stylist shows the client ID for each appointment instead of the client's name.

## Technologies Used
* C#
* ASP.NET Core MVC
* Entity Framework Core
* LINQ
* MySQL

## Support and contact details

_Please contact Na Hyung with questions and comments._

### License

*GNU GPLv3*

Copyright (c) 2019 **_Na Hyung Choi_**