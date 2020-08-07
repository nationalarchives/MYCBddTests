Feature: validationTests

Background:
	Given I am on MYC page and I sign in
	When Go to Add a collection

@mytag
Scenario Outline: Data Validation
	When upload "<invalidFilePath>" type
	And check for the upload message The file has been added to the queue for upload. Please go to View history for more details.
	Then go to View history and see error report "<errorMsg>"

	Examples:
		| invalidFilePath               | errorMsg                                                                                                              |
		| EmptyFilePath                 | Your template is empty - it does not contain any catalogue information.                                               |
		| DateValidationFilePath        | Your collection must have either 'covering dates', or a 'start date' and an 'end date'.                               |
		| FondsWithNoNameOfCreatorsPath | 'Creator name' is a required field at fonds level for this collection.                                                |
		| FondsWithNoReferencePath      | 'Reference code' is a required field at fonds level for this collection.                                              |
		| InvalidFilePath               | types of error(s)/0 types of warning(s)                                                                               |
		| ItemLevelPath                 | We require a valid level hierarchy in this field. It is not possible to have item directly under fonds                |
		| ModifyLevelNamePath           | We expect to see 'fonds' in this field; it currently contains 'fond'                                                  |
		| SubFondsPath                  | We expect to see 'fonds' in this field; it currently contains 'sub-fonds'                                             |
		| SubItemPath                   | We require a valid level hierarchy in this field. It is not possible to have sub-item directly under file             |
		| SubSeriesPath                 | We require a valid level hierarchy in this field. It is not possible to have sub-series directly under fonds          |
		| SubSubFondsPath               | We require a valid level hierarchy in this field. It is not possible to have sub-sub-fonds directly under fonds       |
		| SubSubSeriesPath              | We require a valid level hierarchy in this field. It is not possible to have sub-sub-series directly under series     |
		| SubSubSubFondsPath            | We require a valid level hierarchy in this field. It is not possible to have sub-sub-sub-fonds directly under fonds   |
		| SubSubSubSeriesPath           | We require a valid level hierarchy in this field. It is not possible to have sub-sub-sub-series directly under series |
		#| DiscoveryFormsXlsFormat       | There was a problem with our system; please try again later.(If you are seeing this error repeatedly, contact us)             |

Scenario Outline: ChangeColumNamePath
	When upload "<invalidFilePath>" type
	And check for the upload message The file has been added to the queue for upload. Please go to View history for more details.
	Then go to View history and see the "<errorMsg>"

	Examples:
		| invalidFilePath     | errorMsg                                                                                                          |
		| ChangeColumNamePath | There was a problem with our system; please try again later.(If you are seeing this error repeatedly, contact us) |

Scenario Outline: FondsWithNoLegalStatus
	When upload "<invalidFilePath>" type
	And check for the upload message The file has been added to the queue for upload. Please go to View history for more details.
	Then go to View history and click on preview and approve
	And see the "<errorMsg>"

	Examples:
		| invalidFilePath            | errorMsg                                                                     |
		| FondsWithNoLegalStatusPath | 'Legal status' is a required field at fonds level for this collection. |