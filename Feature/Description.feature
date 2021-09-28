Feature: Description
	
@Add description
Scenario: Add seller's information
	Given Seller is in profile page
	When seller can find the Description
	And the seller add description of himself/herself
	And the description should not exist more than 600 characters
	Then the description should be added successfully