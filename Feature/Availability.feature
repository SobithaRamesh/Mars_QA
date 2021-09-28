Feature: Availability

@Edit Availability
Scenario: Seller's available time
	Given Seller is in profile page
	And seller can find the availability
	When the seller updated his/her availability
	Then the availability should be updated