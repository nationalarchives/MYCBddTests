Feature: AddaCollection
	Upload a tsv/xlsx file, which is not in TNA’s template format from the Add a collection page. 

	
Scenario: Adding a collection
	Given I am on MYC page and I sign in to add a collection
	When I upload a valid file
	And check for the message The file has been added to the queue for upload. Please go to View history for more details.
	Then go to view history and click on Map fields to Discovery
	