Feature: Earn Target
	
@Edit Earn Target
Scenario: Edit seller's Earn Target
	Given Seller selects the Earn Target in profile page
	When the seller updated his/her earn target
	Then the earn target should be updated

@Cancel Earn Target
Scenario: Cancel Seller's Earn Target
	Given Seller selects the Earn Target in profile page
	When the seller cancel his/her Earn Target while editing
	Then the Earn Target should not be updated