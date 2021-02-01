# As a visitor, I want to see names of peaks which are yet to be climbed, sorted by height in ascending order, so that I may be the brave soul to finally scale them.

## ID: 6
## Effort Points: 1
## Owner: Alex
## Feature branch name: featureUnclimbedPeaks

## Assumptions/Preconditions
1. That there are peaks that are still unclimbed in the database

## Description
Implementing this story will allow users a quick and easy way to view all of the peaks that have yet to be climbed in order of increasing height.

## Acceptance Criteria

1. If you look at the Navbar, then you should see the link
2. If the link is clicked on, then you will be taken to the View and see the unclimbed peaks listed by height in ascending order

## Tasks
1. Create View for unclimbed peaks
2. Create Link on the navbar
3. Use LINQ to get the list of peaks and sort them by height

## Dependencies
1. Funciontal and modern homepage with navbar

## Any notes written while implementing this story