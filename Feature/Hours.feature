Feature: Hours
	
@Edit Hours
Scenario: Edit seller's hours
	Given Seller is in profile page
	And seller can find the hours
	When the seller updated his/her hours
	Then the hours should be updated

@Cancel Hours
Scenario: Cancel Seller's available hours
	Given Seller is in profile page
	And seller can find the hours
	When the seller cancel his/her hours while editing
	Then the hours should not be updated