[E] As a visitor to the site I would like to see a fantastic and modern website with an intuitive visual design that guides me to site resources such as FAQ page, and account pages.

	[U] As a visitor to the site I would like to see a fantastic and modern homepage that
	introduces me to the site and the features currently available.

        [T] Create starter ASP dot NET Core MVC Web Application with Individual User Accounts using Identity and no unit test project
		[T] Choose CSS library (Bootstrap 4, or ?) and use it for all pages
		[T] Create nice bare homepage: write initial welcome content, customize navbar, hide links to login/register
        [T] Create SQL Server database on Azure and configure a web app to use it. Hide credentials.
        [T] Deploy it on Azure2.

	[U] As a visitor, I would like to be able to view an About page so that I can learn more
	about the site and understand its purpose.

		[T] Create new view for About page, hyperlinked from home page
		[T] Include information about company history, page development as well as pictures
        [T] provide contact info (phone, email)
        [T] Provide a link to return to the home page

	[U] As a visitor, I would like to be able to view an FAQ page so that I may have some of my questions answered without having to contact user support.
        [T] Create new view for FAQ page, hyperlinked from home page
        [T] Fill page with frequently asked questions and their answers
        [T] provide contact info (phone, email) for user support for unanswered questions
        [T] Provide a link to return to the home page
    
    [U] As a registered user, I would like to be able to view the details of my account on a dedicated page. 
        [T] Implement navbar link to direct to sign-in or sign-up portal if visitor is not logged in
        [T] Implement link to change to direct to user’s account page if user IS logged in
        [T] Create view for user’s account page where user info will be dynamically displayed

[E] As a visitor, I would like to be able to register for an account so that I may be able to receive and offer users help with IT issues. 

	[U] As someone with an IT issue, I would like to register as a client, so that I may get help with my IT issue.
		[T] Copy SQL schema from an existing ASP.NET Identity database and integrate it into our UP,DOWN scripts
		[T] Configure web app to use our db with Identity tables in it
		[T] Create a client table
		[T] Generate Razor Page code using Code Generator Tool
		[T] Manually test register and login; user should easily be able to see that they are logged in
		
	[U] As someone with IT experience, I would like to register as a expert, so that I may help others with IT issue in my field.
		[T] Copy SQL schema from an existing ASP.NET Identity database and integrate it into our UP,DOWN scripts
		[T] Configure web app to use our db with Identity tables in it
		[T] Create an expert table
		[T] Generate Razor Page code using Code Generator Tool
		[T] Create seperate login/registration views hyperlinked from the home page's navbar for experts to use
		[T] Manually test register and login; user should easily be able to see that they are logged in
		
	[U] As a visitor looking into using the site, I want to be able to see and use professionally styled and intuitively designed login/registration pages, so I may 
		[T] Reposition HTML elements on the page to be visually intuitive for all login and registration pages
		[T] Change the color scheme for the different login and registration pages to match a consistent style 
		
[E] As a registered user, I need a tagging system to exist within the web application in order to help the matching system find a suitable match for my needs. 

[E] as a registered user, I would like to be able to view or edit my account information on my account page or delete my account altogether in order to stay in control of my information. 

[E] As a client, I need to be able to make an online request for IT help for my hardware, software, and networking issues, with an extended description of what my particular issue is.

[E] As a client, I need an automated system to match me with the person best suited for helping solve my particular issue, based on my input when requesting help, the expert’s experience, and the expert’s rating so that my issue may be solved. 

[E] As an Expert, I need an online waiting room to await being connected to a client who requires my assistance, with the option to view and decline a request if I feel that I cannot help the client. 

[E] As a registered user, I would like to have multiple methods of communicating with the person I have been matched with, preferably text, video call, and screenshare. 

[E] As a client who received help, I would like to leave feedback on my matched expert’s ability to help me in the form of a rating that I can later edit if I change my mind. 

[E] As a registered user, I need to see a list of past meetings I have participated in, in order to follow up with the person I met.