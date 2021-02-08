# As a visitor looking into using the site, I want to be able to see and use professionally styled and intuitively designed login/registration pages, so I may be able to understand them easily

## ID: 7
## Effort Points: 2
## Owner: Alex
## Feature branch name: registrationCleanup

## Assumptions/Preconditions
We assume that all registration/log-in implementation is complete and that the pages and elements as will be used in the final version exist already

## Description
The stakeholders have expressed that they want to make sure that registration, and logging back into the site is as seamless and easy as possible to encourage people to use and continue to use the site. Most important information should be big, easy to understand, and readable with the layout of the pages. Buttons should be obvious as to where they are and what they do.
In specific, they want: 

1. Registration and log-in pages to follow a similar format and style
2. Style should match the homepage and feel tonally consistent within the web app
3. Registration forms and log-in forms should be right in the middle of the webpage with text describing the fields directly above each form element
4. links to switch between log-in and registration pages should be present on the top right of the page, to allow users to quickly navigate if they clicked on the wrong page initially 
5. The Register/log-in button should be huge under the elements and clearly clickable to users

## Acceptance Criteria
[Try to write criteria that, when true or satisfied mean that it is correct and you're done. Write them in the "If ___ then ____" format, for if you do this then you should expect this result, for defining the correct behavior that shows the feature works as requested]

1. If a visitor clicks on a registration/log-in link, they should immediately know if they are in the right place for what they want to do (Register or log-in as the correct user type)
2. If a visitor attempts to click on any links/buttons on the current page, it should correctly transport them to the page that matches the link's description. 
3. If a visitor hovers above a clickable button, it should change color to reflect its clickable nature

## Tasks
1. Reposition HTML elements on the page to be visually intuitive for all login and registration pages
2. Change the color scheme for the different login and registration pages to match a consistent style 

## Dependencies
This story requires that all base functionality and structure of the log-in/registration pages is complete and that the color scheme for the site has been decided 

## Any notes written while implementing this story