Feature: uploadPicturesIntoChat

Scenario: As a user, I want to send a photo to the other user I'm chatting with
Given the user is in a chatroom meeting page
When the user on attach a photo button
Then open up the local upload photo for the user to select a photo
And send the selected photo in a message in the chat box
