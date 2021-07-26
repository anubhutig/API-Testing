Feature: BillingOrder
	Create Billing Order

@mytag
Scenario: Create Billing Order by filling form and submit
	Given Open Billing Order Page
	When Enter User Details
	When Submit User Details
	Then Form should be submitted successfully

	