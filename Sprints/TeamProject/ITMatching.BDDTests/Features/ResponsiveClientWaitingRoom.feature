Feature: As a client, I want the meeting room to be fully responsive while matching and to be periodically updated with relevant info while I am waiting to be matched with an expert.
	Responsive Client Waiting Room

Background: 
	Given the following ITMUsers exist
		| ID | ASPNetUserID | UserName | FirstName | LastName | Email  | PhoneNumber |
		| 1  | 12b          | aa@a.a   | Al        | Adams    | aa@a.a | 1112223333  |
		| 2  | 32c          | bb@b.b   | Ben       | Burger   | bb@b.b | 3232231111  |
	And the following Experts exist
		| ID | ITMUserID | WorkSchedule | IsAvailable |
		| 1  | 4         | NULL         | True        |
		| 2  | 5         | NULL         | True        |
		| 3  | 6         | NULL         | True        |
		| 4  | 7         | NULL         | False       |
	And the following HelpRequests exist
		| ID | ClientID | RequestTitle   | RequestDescription | IsOpen |
		| 1  | 1        | "Broken Mouse" | "Mouse is broken." | True   |
		| 2  | 2        | "Dead Pixel"   | "Bad Screen."      | True   |
	And the following RequestServices exist
		| ID | ServiceId | RequestId |
		| 1  | 1         | 1         |
		| 2  | 1         | 2         | 
	And the following ExpertServices exist
		| ID | ServiceId | ExpertId |
		| 1  | 1         | 1        |
		| 2  | 1         | 2        |

Scenario: As a client, I need to page to update periodically, so that I can have up to date information on the matching process.
	Given I am an ITMUser with userName of '<UserName>'
	And I have an open Help Request
	And I am on the ClientWaitingRoom page
	When 5 seconds has elapsed since the timer started
	Then the page should refresh

Scenario:  As a client, I want to know how many experts are online while I am searching for a match, so I may know how likely a match is.
	Given I am an ITMUser with userName of '<UserName>'
	And I have an open Help Request
	And I am on the ClientWaitingRoom page
	When the page loads
	Then the onlineExpertCounter should display 3

Scenario:  As a client, I want to know how many online experts are appropriate matches while I am searching for a match, so I may know how likely a match is.
	Given I am an ITMUser with userName of '<UserName>'
	And I have an open Help Request
	And I am on the ClientWaitingRoom page
	When the page loads
	Then the potentialMatchingExpertCounter should display 3