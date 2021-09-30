Feature: Availability

@Edit Availability
Scenario: Seller's available time
	Given Seller selects the Availabilty in profile page
    When the seller updated his/her availability
	Then the availability should be updated

@Cancel Availability
Scenario:Cancel Seller's available time
	Given Seller selects the Availabilty in profile page
	When the seller cancel his/her availability while editing
	Then the availability should not be updated