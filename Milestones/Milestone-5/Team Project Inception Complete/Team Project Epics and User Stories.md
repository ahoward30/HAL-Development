[E] As a visitor to the site I would like to see a fantastic and modern website with an intuitive visual design that guides me to site resources such as FAQ page, sign-in/register portals, and account pages.

	[U] As a visitor to the site I would like to see a fantastic and modern homepage that
	introduces me to the site and the features currently available.

        [T] Create starter ASP dot NET Core MVC Web Application with Individual User Accounts and no unit test project
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

    [U] As a visitor, I would like to be taken to a page to sign-up for an account
        [T] Create links on the side of the navbar that defaults to sign-in/sign-up portal
        [T] Create views for sign-in and sign-up portal (Not functional yet)
    
    [U] As a registered user, I would like to be able to view the details of my account on a dedicated page. 
        [T] Implement navbar link to direct to sign-in or sign-up portal if visitor is not logged in
        [T] Implement link to change to direct to user’s account page if user IS logged in
        [T] Create view for user’s account page where user info will be dynamically displayed

[E] As a registered user, I need to be able to make an online request for IT help for my hardware, software, and networking issues, with an extended description of what my particular issue is.
    
    [U] As a user on the site, I need to be able to make a request for IT help for my issue.
        [T] If user accounts implemented by this task, check for if user is logged in
        [T] Create and display link if user logged in (if applicable) on main page to request
        [T] Create table for requests to be stored
        [T] Create view for requests to be made with forms and ability to submit to table
        [T] Implement input validation to check forms when user attempts to submit
		
    [U] As a user, I need to use tags to describe my issue so I can be matched with an expert who specializes in the same tag.
        [T] Create data table to store tag keywords and a bridge table to connect
        [T] Display checkboxes on request page for user to click that are connected to request table element, to be compared to expert’s experience.  

[E] As a visitor, I would like to be able to register for an account so that I may be able to receive and offer users help with IT issues. 
        
[E] As a registered user seeking help, I need an automated system to match me with the person best suited for helping solve my particular issue, based on my input when requesting help, the expert’s experience, and the expert’s rating. 

[E] as a registered user, I would like to be able to edit or delete my account. 

[E] As a registered expert, I need to be able to set tags on my account’s profile so that I can be accurately matched to a user’s IT issue.

[E] As a registered user, I would like to have multiple methods of communicating with the person I have been matched with, preferably text, video call, and screenshare. 

[E] As a user who received help, I would like to leave feedback on my matched expert’s ability to help me in the form of a rating that I can later edit if I change my mind. 
