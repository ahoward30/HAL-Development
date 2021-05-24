Feature: AboutPage

Scenario: As a user, I want to view the account page of the website
Given the user is on the about page
And the user is not on the final slide
When the user clicks the next arrow
Then  swap the the photo and the description with the next of the list 

Scenario: As a user, I want to view the account page of the website 
Given the user is on the about page
And the user is on the first or final slide
When the user clicks the next/previous arrow 
But being on the last/first slide
Then the list will restart from the other end of the list