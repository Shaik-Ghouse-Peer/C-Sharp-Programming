Feature: Login
	Customer Login to Flipkart

@mytag
Scenario Outline: Login To Flipkart With Valid Credentials
	Given User Is On Flipkart Apllication
	When The User Enter <username> and <password>
	And Click on Login
	Then The User Should Navigate To '<User>' Account
	Examples: 
		| username   | password   | User   |
		| validUserId | validPassword | userName |