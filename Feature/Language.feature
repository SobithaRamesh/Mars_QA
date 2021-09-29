Feature: Language
	
@Add Language
Scenario: Add Seller's known language
	Given Seller is in profile page
	When Seller adds language and skills
	Then The Language and level should be added successfully

@Edit Language
Scenario: Edit Seller's known language
	Given Seller is in profile page
	When Seller edit language and level
	Then The language and level should be updated successfully 

@Delete Language
Scenario: Delete Seller's known language
	Given Seller is in profile page
	When Seller deletes language and level
	Then The language and level should be deleted successfully 

@Add invalid Language data
Scenario: Invalid Language
	Given Seller is in profile page
	When Seller didn't add all the data
	Then The Language should not be added successfully 

@Add invalid Language data
Scenario: Invalid Language
	Given Seller is in profile page
	When Seller adds four Languages
	Then The Add New Button should not be shown

@Invalid Language data
Scenario: Invalid Language
	Given Seller is in profile page
	When Seller adds duplicate Languages
	Then The Language should not be added successfully 


