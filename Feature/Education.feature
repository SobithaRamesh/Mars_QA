Feature: Education
	
@Add Education
Scenario: Add Seller's Education
	Given Seller is in profile page
	When Seller adds his/her Education
	Then The Education should be added successfully 

@Edit Education
Scenario: Edit Seller's Education
	Given Seller is in profile page
	When Seller edits his/her Education
	Then The Education should be updated successfully 

@Delete Education
Scenario: Delete Seller's Education
	Given Seller is in profile page
	When Seller deletes his/her Education
	Then The Education should be deleted successfully 

@Add invalid Education data
Scenario: Add invalid Education data
	Given Seller is in profile page
	When Seller didn't add all the data
	Then The Education should not be added successfully 

@Invalid Education data
Scenario: Invalid Education
	Given Seller is in profile page
	When Seller adds duplicate Education
	Then The Education should not be added successfully 