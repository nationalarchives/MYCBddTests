Feature: MappingEndTOEndForTSVFile
	

@mytag
Scenario: Mapping end to end for valid TSV file
	Given that I am at the Mapping Page with uploaded tsv file
    And mandatory fields have been added to the list of Matched fields for tsv file
	Then Enter the mapping Name for tsv file
	When I click the Submit and continue button
	Then I see an information message stating that my file has been successfully mapped
	