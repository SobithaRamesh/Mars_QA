Feature: Profile Details
	
@Profile Name 
Scenario: Add Name of the seller
	Given Seller is in profile page
	When the seller updated his/her name
	Then the seller's name should be updated