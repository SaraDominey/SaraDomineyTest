Feature: LogInScreenC
	
Scenario Outline: valid user logs in successfully
	Given a valid user logs in to SwagLabs with "<username>" "secret_sauce"
	When the Login button is selected
	Then the product page is launched
Examples:
| username                | 
| standard_user           |
| locked_out_user         | 
| problem_user            | 
| performance_glitch_user | 


Scenario: invalid username returns an error
	Given an unknown user logs in to SwagLabs
	When the Login button is selected
	Then a message returned not indicating valid user with incorrect password or invalid username

Scenario: correct username and invalid password returns an error
	Given a valid user logs in to SwagLabs with "standard_user" "invalid_password"
	When the Login button is selected
	Then a message returned not indicating valid user with incorrect password 

