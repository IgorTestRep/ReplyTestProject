Feature: Reports

@reports
Scenario: Check if Project Profitability report is working
	Given I navigate to login page 
	And I enter following for login
	When I click login button
	Then I should be able to access the dashboard view
	And I Open "Project Profitability" report
	Then Report is not empty