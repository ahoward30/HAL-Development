# As a visitor to the site I would like to see a fantastic and modern homepage that introduces me to the site and the features currently available.

## ID: 1
## Effort Points: 4
## Owner: Alex
## Feature branch name: projectSetup

## Assumptions/Preconditions
We assume that all team members are fully updated to ASP.NET 5.0.2, which is the version the web app will be configured for. 

## Description
Our stakeholders have expressed that they want the IT Matching web app to be modern-looking, and easily understandable to new visitors to the site. The homepage in particular should feel like the clear hub to the site and allow easy access to the major features (log-in, IT Help Request Form, etc.). Links to most important features should exist to give structure to the site, even if their implementation does not yet. 
In particular, this story should adhear to the following guidelines: 

1. The web app should be deployed with Identity and online on Azure from the get-go
2. The homepage should act as an informational landing page, with just enough info to be directed, but not so much that it feels overwelming 
	* navbar at the top
	* IT Matching name right beneath
	* Informative paragraph(s) and example images beneath that
3. The entire homepage should follow a consistent color scheme. Product Owner suggests following HAL logo colors, but is open to other options. Regardless, it should look good.
4. All links to important site features exist, even if just as placeholders until they are actually implemented. Should look like buttons to read as a clickable object to a visitor.
	* log-in/register buttons on the top right
	* User account page on the top left
	* FAQ, and About pages in the navbar
5. Images, Diagrams and other decorative elements should be used where appropriate, but not be overly abundant so as to detract from the modern, sleek design

## Acceptance Criteria
[Try to write criteria that, when true or satisfied mean that it is correct and you're done. Write them in the "If ___ then ____" format, for if you do this then you should expect this result, for defining the correct behavior that shows the feature works as requested]

1. If a visitor attempts to access the site via our link, then they should land directly on the homepage hosted on Azure
2. If a visitor attempts to click on any links/buttons on the homepage, then they will be taken to the appropriate page, regardless of if it is implemented yet
3. If a visitor hovers above a clickable button, it should change color to reflect its clickable nature

## Tasks
1. Create starter ASP dot NET Core MVC Web Application with Individual User Accounts using Identity and no unit test project
2. Choose CSS library (Bootstrap 4, or ?) and use it for all pages
3. Create nice homepage: write initial welcome content, position page elements, customize navbar, set color scheme
4. Create SQL Server database on Azure and configure a web app to use it. 
5. Deploy it on Azure2.

## Dependencies
Many of the links on the homepage depend upon future stories, but they will exist as placeholders until those stories are implemented

## Any notes written while implementing this story