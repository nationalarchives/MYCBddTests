Feature: validFilesUpload

Background: 
Given I am on MYC page, sign in 

Scenario Outline: ValidationCheckFonds
When I upload the "<validFiles>"
Then check for the message upload completed
Examples: 
| validFiles           |
| FondsPath            |
| FondsAndSubFondsPath |
| SeriesPath           |
| AllLevelsPath        |




	 
	