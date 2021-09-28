Feature: Hours
	
@Edit Hours
Scenario: Edit seller's hours
	Given Seller is in profile page
	And seller can find the hours
	When the seller updated his/her hours
	Then the hours should be updated