@tagFeature
Feature: Login
	Helps to test the functionality of login

@tag1
Scenario Outline: Login with valid credentials
	Given I am on login page
	When I provide username <username>
	When I provide password <password>
	When I select login
	And I calculate 100 as value
	Then Appears a dashboard
	Then user adds fisrtName and lastName
	Then display user information
	#And Appears user details

Examples:
| username      | password     |
| standard_user | secret_sauce |
| problem_user  | secret_sauce |



@tag1
Scenario Outline: Login with valid credentials second
	Given Display employee full name

Examples:
| username      | password     |
| standard_user | secret_sauce |