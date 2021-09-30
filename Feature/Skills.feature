Feature: Skills

@Add Skills
Scenario: Add Seller's skills
	Given Seller selects the skills tab in profile page
	When Seller adds his/her skills and Skill Level
	Then The skills should be added successfully 

@Edit Skills
Scenario: Edit Seller's skills
	Given Seller selects the skills tab in profile page
	When Seller edits his/her skills and Skill Level
	Then The skills should be updated successfully 

@Delete Skills
Scenario: Delete Seller's skills
	Given Seller selects the skills tab in profile page
	When Seller deletes his/her skills and Skill Level
	Then The skills should be deleted successfully 

@Add invalid Skills data
Scenario: Adding invalid Seller's skills
	Given Seller selects the skills tab in profile page
	When Seller didn't add all data 
	Then The skills should not be added successfully  

@Invalid Skills data
Scenario: Invalid Skills
	Given Seller selects the skills tab in profile page
	When Seller adds duplicate Skills
	Then The Skills should not be added successfully 
