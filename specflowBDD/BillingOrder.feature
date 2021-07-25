Feature: BillingOrder
	Simple calculator for adding two numbers

@mytag
Scenario: Add two numbers
	Given the first number is 50
	And the second number is 70
	When the two numbers are added
	Then the result should be 120

	Scenario Outline: Add two numbers (Data Driven)
	Given the first number is <number1>
	And the second number is <number2>
	When the two numbers are added
	Then the result should be <sum>
	Examples: 
	| number1 | number2 | sum |
	| 1 | 2 | 3 |
	| 32 | 3 | 35 |
	| 32 | 4 | 36 |