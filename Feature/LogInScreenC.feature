Feature: LogInScreenC
	
Scenario Outline: valid user logs in successfully to the product page
	Given browser is launched
	And a valid user logs in to SwagLabs with "<username>" "secret_sauce"
	When the Login button is selected
	Then the product page is launched
	And close browser
	
Examples:
| username                | 
| standard_user           |
| problem_user            | 
| performance_glitch_user | 


Scenario: confirm can add an item to the basket and the item is present on the carts content page 
	Given browser is launched
	And a valid user logs in to SwagLabs with "standard_user" "secret_sauce"
	When the Login button is selected
	Then the product page is launched
	And add to cart
	And view basket content
	And close browser

Scenario: invalid username returns an error
	Given browser is launched
	And an unknown user logs in to SwagLabs
	When the Login button is selected
	Then confirm displayed error message does not indicate a valid user with incorrect password or invalid username
	And close browser

Scenario: correct username and incorrect password returns an error
	Given browser is launched
	And a valid user logs in to SwagLabs with "standard_user" "invalid password"
	When the Login button is selected
	Then confirm displayed error message does not indicate a valid user with incorrect password or invalid username
	And close browser

