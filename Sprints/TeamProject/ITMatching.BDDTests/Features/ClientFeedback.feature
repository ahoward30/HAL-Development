Feature: As a client who has finished a meeting, I would like to be prompted with a message asking me if I felt like my expert was helpful or not, so that my feedback may influence future matching.
	Simple calculator for adding two numbers

@mytag
Scenario: As a client, I want to submit feedback
Given the client is logged in
And the client is on the Feedback Page
When the client submits a response
Then the response should be reflected on the meeting object

Scenario: As a client, I want my feedback to affect future matching
Given 2 experts are offline
And they have the same tags
When they match with a client
Then the expert with a higher satisfaction percent should be displayed first 