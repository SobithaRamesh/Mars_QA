Feature: Hours
	
@Edit Hours
Scenario: Edit seller's hours
	Given Seller selects the hours in profile page
	When the seller updated his/her hours
	Then the hours should be updated

@Cancel Hours
Scenario: Cancel Seller's available hours
	Given Seller selects the hours in profile page
	When the seller cancel his/her hours while editing
	Then the hours should not be updated