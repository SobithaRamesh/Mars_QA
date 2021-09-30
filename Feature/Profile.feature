Feature: Profile Details
	
@Profile Name 
Scenario: Add Name of the seller
	Given Seller selects the UserName in profile page
	When the seller updated his/her name
	Then the seller's name should be updated

@Invalid Profile Name 
Scenario: Invalid UserName of the seller
	Given Seller selects the UserName in profile page
	When the seller didn't add his/her first name or last name while editing
	Then the seller's name should not be updated