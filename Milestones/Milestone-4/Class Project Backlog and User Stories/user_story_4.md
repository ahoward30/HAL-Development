# As a visitor, I want to see extended information about specific expeditions when I click on its entry in a list, so that I can learn more about expeditions that interest me, without cluttering the screen with information for expeditions I'm not interested in.

## ID: 4
## Effort Points: 2
## Owner: Adnan
## Feature branch name: feature2

## Assumptions/Preconditions
1. All of these data tables have values that can link together when compiling information. 

## Description
Currently, expedition lists are presented with nearly all of the information associated with them, which can be overwelming. By implementing this story, we remove much of the clutter except for absolutely necessary info until the user shows that they want to see it.

## Acceptance Criteria

1. If you view the recents page, then you should see a list of expeditions that you can click on.
2. If you click on an expedition on the recents page, then you will be taken to a page with more information about the expedition. 

## Tasks
1. Create view for detailed information
2. remove excessive information from recents list
3. turn each list item into a link that takes you to a list of detailed information created dynamically

## Dependencies
Recent Expeditions list already existing

## Any notes written while implementing this story