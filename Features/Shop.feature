Feature: Sign in

@regression
Scenario: Login valid users
	Given I am on Home Page
	When I login with "<login>" and "<password>"
	Then Account page is opened
	Examples:
    | login  | password |
    | email123@gmail.com | Password123|
