Feature: Create a user

Scenario: Create a new user
	Given user with name "Peter"
	And user with job "QA"
	When request is sent to create user
	Then verify user was created

Scenario: some other one 
    Given user
	And job
	When send
	Then verify 
