Feature: ArrayChallenge
	In order to get a job at ECS
	As an applicant
	I want to automate the arrays challenge

@Imperative
Scenario: 01 - Calculate and submit the array challenge
	Given I am on the Home Page
	When I render the challenge
	And I calculate the array centres
	And I submit the array centres
	Then a message is shown
	| Message                                      |
	| It looks like your answer wasn't quite right |