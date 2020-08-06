Feature: UndoMapping
Background: 
Given I am on MYC page, sign in and go to mapping page

@mytag
Scenario: Undo mapping
	When I undo mapping

Scenario: Undo all mapping
Given I am at the Mapping Page
	And Pairs of items have been added to the list of Matched fields
	When I click the undo all button
	Then all mapped pairs of fields are removed from the list of matched fields
    And  all previously matched items are returned to the list of Discovery fields and your fields.

	