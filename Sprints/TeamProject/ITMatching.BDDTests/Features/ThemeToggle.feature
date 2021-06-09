Feature: ThemeToggle
	Slider on the top of the page for switching between light and dark themes

Scenario: Toggle the site theme
	Given I am on the home page
	And the current theme is dark
	When I click on the theme slider
	Then the theme should change to be light