Feature: Certifications
	
@Add Certifications
Scenario: Add Seller's Certification
	Given Seller selects the Certification tab in profile page
	When Seller adds his/her Certification
	Then The Certification should be added successfully 

@Edit Certifications
Scenario: Edit Seller's Certification
	Given Seller selects the Certification tab in profile page
	When Seller edits his/her Certification
	Then The Certification should be updated successfully

@Delete Certifications	
Scenario: Delete Seller's Certification
	Given Seller selects the Certification tab in profile page
	When Seller delete his/her Certification
	Then The Certification should be deleted successfully 
	
@Add invalid Certification data
Scenario: Add invalid certification data
	Given Seller selects the Certification tab in profile page
	When Seller didn't add all the data
	Then The Certification should not be added successfully

@Invalid Certification data
Scenario: Invalid Certification
	Given Seller selects the Certification tab in profile page
	When Seller adds duplicate Certification
	Then The Certification should not be added successfully 