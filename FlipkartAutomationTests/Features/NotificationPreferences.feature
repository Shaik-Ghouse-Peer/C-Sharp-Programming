Feature: NotificationPreferences


Scenario Outline: Altering In-App Notifications
	Given User Is On Flipkart Application
	And Logged In With Credentials '<username>' and '<password>'
	When User Selected Notification Preferences
	And User Selected In-App Notifications Settings
	And User Checked Remider Checkbox
	Then the Reminder Checkbox State Should be Altered
	Examples: 
		|	username   |	password   |
		|	validUserId |	validPassword |