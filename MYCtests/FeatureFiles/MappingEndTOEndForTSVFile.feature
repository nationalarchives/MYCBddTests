Feature: MappingEndTOEndForTSVFile
	

@mytag
Scenario: Mapping end to end for valid TSV file
	Given that I am at the Mapping Page with uploaded tsv file
    And mandatory fields have been added to the list of Matched fields for tsv file
	Then Enter the mapping Name for tsv file
	When I click the Submit and continue button
	Then I arrive at the view history page
	And I see an information message stating that my file has been successfully mapped
	And the file moves on to validation
	And click Preview and Approve
	And click Approve
	Then click refresh to see collection upload compted 
	Then click view in discovery to see the detail page of this collection