Feature: Activity Log

@activityLog
Scenario: Delete records from activity log
	Given I navigate to login page 
	And I enter following for login
	When I click login button
	Then I should be able to access the dashboard view
	And Delete 3 rows from Activity Log
	Then Rows in Activity Log are deleted