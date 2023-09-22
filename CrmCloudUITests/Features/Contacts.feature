Feature: Contacts

@contacts
Scenario: Create new contact
	Given I navigate to login page 
	And I enter following for login
	When I click login button
	Then I should be able to access the dashboard view
	And I Open Contacts view
	And I Create new contact
	Then Contact is created