1. [E]
	1. [U] As a visitor to the site I would like to see a fantastic and modern homepage that introduces me to the site and the features currently available.
		1. [T] Create starter ASP dot NET Core MVC Web Application with Individual User Accounts and no unit test project
		2. [T] Choose CSS library (Bootstrap 4, or ?) and use it for all pages
		3. [T] Create nice bare homepage: write initial welcome content, customize navbar, hide links to login/register
		4. [T] Create SQL Server database on Azure and configure a web app to use it. Hide credentials.
		5. [T] Deploy it on Azure2. 

	2. [U] As someone who wishes to submit new information on an expedition I would like to be able to register an account so I will be able to use your services (once they're built)
		1. [T] Copy SQL schema from an existing ASP.NET Identity database and integrate it into our UP,DOWN scripts
		2. [T] Configure web app to use our db with Identity tables in it
		3. [T] Create a user table and customize user pages to display additional data
		4. [T] Re-enable login/register links
		5. [T] Manually test register and login; user should easily be able to see that they are logged in

2. [E]
	3. [U] As a visitor, I want to see no. of times a particular peak has been climbed, names of peaks which are yet to be climbed, sorted by height.
		1. [T] Add an extra option in the homepage navbar named “Research”
		2. [T] Create a new view with forms for the following options:
			* Number of times a peak is climbed
			* List of unclimbed peaks
			* Sorted by height
		3. [T] Add submit action for each form and display the results on the same page.
		4. [T] Provide a link to go back to the initial research forms
		5. [T] Provide a link to get back to the homepage.

	4. [U] As a visitor, I would like to see a list of the most recent expeditions that have been registered on the site.
		1. [T] Add a ‘Recents’ link in the frontpage.
		2. [T] Display the recently added expeditions in the view.
		3. [T] Add links in the list for more details about the expedition.

	5. [U] As a visitor, I would like to see a picture of a particular peak listed in the database so that I can know what it looks like before visiting it. 
		1. [T] Compile a collection of pictures for every listed peak
		2. [T] Include hyperlink on peak name in list view that links to the image of the peak.

	6. [U] As a registered user I want to be able to view and correct mistakes on my previous expedition entries.
		1. [T] Add a link to the user profile in the homepage.
		2. [T] Create a space for displaying the list of entries made by that particular user.
		3. [T] Give option for editing the entry.
		4. [T] Add edit form and store the edited data back to the database
		5. [T] Add links to go back to the list of entries or go back to home.

	7. [U] As an admin I need rights to add/remove the mountain peaks as well as remove any member from the member table.
		1. [T] Add a new column to the member table named IsAdmin(Boolean).
		2. [T] Profile for the admin will contain certain options like Add a peak, Remove a peak, Modify members
		3. [T] Create views for each option and make changes in the database accordingly.


	8. [U] As someone new to mountain-climbing, I would like to see a list of the best peaks for beginners to scale. 
		1. [T] Create new view accessible from the main page for beginner climbers to click on.
		2. [T] In this new view, display a list of peaks hand-picked from experts as the best beginner peaks.
		3. [T] Provide a link to get back to the homepage.

	9. [U] As a visitor, I would like to be able to view an FAQ page so that I may have some of my questions answered without having to contact user support. 
		1.[T] Create new view for FAQ page, hyperlinked from home page
		2.[T] Fill page with frequently asked questions and their answers
		3.[T] provide contact info (phone, email) for user support for unanswered questions
		4.[T] Provide a link to return to the home page

	10. [U] As an expedition enthusiast, I would like to be able to follow news and read articles about expeditions, written by professionals and fellow enthusiasts 
		1.[T] Add a page dedicated to news articles linked from home page
		2.[T] Add functionality to search for articles by keywords and sort by dateand display them as a list of links to pages with the full article
		3.[T] Create an admin-only accessible page for publishing professional articles


