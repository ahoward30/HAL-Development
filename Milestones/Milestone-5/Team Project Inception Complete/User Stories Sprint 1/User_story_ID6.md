# As someone with IT experience, I would like to register as a expert, so that I may help others with IT issue in my field.

## ID: 6
## Effort Points: 4
## Owner: Adnan
## Feature branch name: Expert Registration

## Assumptions/Preconditions

* An ASP.NET core application with Identity should be created.
* The created application should be deployed on Azure.
* A database with decided schema needs to be created on Azure.
* The register button should have a register view attached

## Description

After the application is created with Identity the registration functionality for expert need to be implemented. The Expert table needs to be created in the database.
The view page attached to the register button on the navbar in the top right has to be modified. Two columns will be created and the left column can be used for the expert
registration. The expert registration form will have the following content:
1. Username
2. First name
3. Last name
4. E-mail
5. Phone number
6. Work Schedule
    1. Start time
    2. End time
    3. check boxes for selection of days
7. Submit button
Each of the fields will have their respective input validations. The submit button will post the entered details to ExpertRegister() in the controller.
The data will then be stored in the database thereby registering the expert successfully. The expert will get to see a successfully registered pop-up and will be redirected to the
login page directly. 

## Acceptance Criteria

1. If all the inputs are not according to validations then the submit button should not be clickable.
2. If there is any type mismatch then a proper error message should be displayed instead of exception page. 
3. If registration is successful then a pop-up with success message should be displayed.
4. If registration is done then the expert has to be redirected to Login page automatically.

## Tasks

1. Copy SQL schema from an existing ASP.NET Identity database and integrate it into our UP,DOWN scripts
2. Configure web app to use our db with Identity tables in it
3. Create an expert table
4. Generate Razor Page code using Code Generator Tool
5. Add expert model.
6. Create seperate login/registration views hyperlinked from the home page's navbar for experts to use
7. Add ExpertPostAsync() for storing the data in the expert's table.
8. Manually test register and login; user should easily be able to see that they are logged in

## Dependencies
Creation of the Identity project. Story #1 & #5

## Any notes written while implementing this story