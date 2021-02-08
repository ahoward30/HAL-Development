# As someone with an IT issue, I would like to register as a client, so that I may get help with my IT issue.

## ID: 5
## Effort Points: 4
## Owner: Jimmy
## Feature branch name: Client Registration

## Assumptions/Preconditions

* An ASP.NET core application with Identity should be created.
* The created application should be deployed on Azure.
* A database with decided schema needs to be created on Azure.


## Description

After the application is created with Identity the registration functionality for clients need to be implemented.
The user table needs to be modified to be The client table in the database. The view page attached to the register button on the navbar in the top right has to be modified.
Two columns will be created and the left column can be used for the client registration. The client registration form will have the following content:
1. Username
2. First name
3. Last name
4. E-mail
5. Phone number
6. Submit button
Each of the fields will have their respective input validations. The submit button will post the entered details to ClientRegister()
in the controller. The implementation for the client register needs to be modified to store the data in the new client The data will then be stored in the database
thereby registering the client successfully. The client will get to see a successfully registered pop-up and will be redirected to the login page directly. 


## Acceptance Criteria

1. If all the inputs are not according to validations then the submit button should not be clickable.
2. If there is any type mismatch then a proper error message should be displayed instead of exception page. 
3. If registration is successful then a pop-up with success message should be displayed.
4. If registration is done then the client has to be redirected to Login page automatically.

## Tasks
1. Copy SQL schema from an existing ASP.NET Identity database and integrate it into our UP,DOWN scripts
2. Configure web app to use our db with Identity tables in it
3. Rename User table to client table, and add the needed fields to it.
4. Generate Razor Page code using Code Generator Tool
5. modify the OnPosyAsync() to ClientOnPostAsync().
6. Manually test register and login; user should easily be able to see that they are logged in


## Dependencies
Story #1.

## Any notes written while implementing this story