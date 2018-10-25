Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Add two numbers
	Given I have entered 50 into the calculator
	And I have also entered 80 into the calculator
	When I press add
	Then the result should be 130 on the screen



Scenario: Add two numbers again
	Given I have entered 50 into the calculator
	And I have also entered 80 into the calculator
	And Some steps
	When I press add
	Then the result should be 130 on the screen
