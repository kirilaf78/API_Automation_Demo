Feature: CreateUser

Creating a new user

Scenario: Create a new user
	Given user with name "Peter"
	And user with job "QA"
	When request is sent to create user
	Then verify user was created