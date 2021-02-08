# As a registered user, I would like to be able to view the details of my account on a dedicated page.

## ID: 4
## Effort Points: 2
## Owner: Adnan
## Feature branch name: User Profile

## Assumptions/Preconditions

* An ASP.NET core application with Identity should be created.
* Database should be fed with the Client and Expert tables.
* Register functionality should be completed and the data stored in the respective tables successfully.
* Login functionality has to be completed along with the other modules like forgot password, user verification, etc.


## Description

After a successful login attempt, the user should be able to access his/her account profile. The link to the profile page is in form of a clickable button placed on the navbar in the top right corner of the page.
The profile page would contain the following user details:

1. Username
2. First name
3. Lastname
4. Email
5. Phone Number
6. Work schedule [if the user is an Expert].


## Acceptance Criteria

1. If the user isn't authenticated then the link to profile will not be visible on the navbar.
2. If user is an Expert then his details must include 'Work Schedule'.

## Tasks
1. Implement navbar link to direct to sign-in or sign-up portal if visitor is not logged in
2. Implement link to change to direct to user’s account page if user IS logged in
3. Create view for user’s account page where user info will be dynamically displayed


## Dependencies
Registration functionality for Client and Expert. Story #5 & #6.


## Any notes written while implementing this story