Feature: Description
	
@Add description
Scenario: Add seller's information
	Given Seller selects the Description in profile page
	When the seller add description of himself/herself
	Then the description should be saved successfully

@Add Invalid description
Scenario: Add Invalid seller's information
	Given Seller selects the Description in profile page
	When the seller add description of himself/herself for more than 600 characters
	Then the description textbox should not allow seller to type further