Feature: DeleteSavedMapping
	
Scenario: delete a previously saved mapping
	Given I am on MYC page and I sign in to delete saved mapping
	When I upload a file and go to view history
	And Click on map fields to Discovery 
	And I am at the Mapping Page and map the fields and save the mapping
	 And I select a mapping from the list of saved mappings
	And select Delete this mapping
	Then the deletion overlay screen should appear to approve and reject
	And I can click yet to delete saved mapping
	
