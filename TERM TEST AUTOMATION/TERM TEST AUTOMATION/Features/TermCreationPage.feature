Feature: Testing Creation of TERMs
	To get access to the web application User has to login with correct credentials

Background:
	Given User is at the login page
	When User enters "Admin" as a username
		And User clicks the login button
	Then User should be at the Term Page


@PositiveTests @CreateTermScenario
Scenario Outline: Positive cases for creating a TERM
	Given User on the template creation page
	When User clicks 'create new template' button
		And All fields are empty
		And User sets checkbox 'KeyTerm' to "<KeyTerm>"
		And User selects "<Category>" in 'Category/Subcategory' dropdown
		And User enters "<TermName>" in 'Term Name' field
		And User enters "<Description>" in 'Description' field (if provided)
		And User enters "<Summary>" in 'Summary' field
		And User clicks 'Save' button
	Then Alert with message 'Template has been saved' appears
		And User searches for "<TermName>" in 'Search field' and clicks
		And Template has "<KeyTerm>" state
		And Template has 'Category/Subcategory' like "<Category>"
		And Template has 'Term Name' like "<TermName>"
		And Template has 'Term Template Key' like "<TermName>"
		And Template has 'Description' like "<Description>" (if provided)
		And Template has 'Summary' like "<Summary>"
		And User clicks 'Delete' button
		And Alert with message 'Template has been removed' appears
		And User checks the Template with name "<TermName>" not found

Examples:
	| KeyTerm   | Category     | TermName      | Description          | Summary              |
	| unchecked | Basic Terms  | ShortName     | ShortDescription     | ShortSummary         |
	| checked   | Basic Terms  | ShortName     | ShortDescription     | ShortSummary         |
	| unchecked | Jurisdiction | ShortName     | ShortDescription     | ShortSummary         |
	| checked   | Jurisdiction | ShortName     | ShortDescription     | ShortSummary         |
	| unchecked | Basic Terms  | MaxLengthName | MaxLengthDescription | MaxLengthSummary     |
	| checked   | Basic Terms  | MaxLengthName | MaxLengthDescription | MaxLengthSummary     |
	| unchecked | Jurisdiction | MaxLengthName | MaxLengthDescription | MaxLengthSummary     |
	| checked   | Jurisdiction | MaxLengthName | MaxLengthDescription | MaxLengthSummary     |
	| unchecked | Basic Terms  | ShortName     |                      | ShortSummary         |
	| checked   | Basic Terms  | MaxLengthName |                      | MaxLengthSummary     |
	| checked   | Basic Terms  | MaxLengthName | MaxLengthDescription | OverMaxLengthSummary |
	| checked   | 0            | 0             | 0                    | 0                    |
	| unchecked | 0            | 0             |                      | 0                    |
# NOTE: New values could be added to the table. Predefined or custom.
# NOTE2: Add any value from Category/Subcategory dropdown to Category column. 
# NOTE3: Predefined variables are set for Name, Description and Summary columns (with special charachters). Custom values also could be used.

@PositiveTests
Scenario: Filling the form for TERM creation and cancelling not creates TERM or errors
	Given User on the template creation page
	When User clicks 'create new template' button
		And All fields are empty
		And User changes checkbox 'KeyTerm' to "checked"
		And User selects "Budgets" in 'Category/Subcategory' dropdown
		And User enters "ShortName" in 'Term Name' field
		And User enters "ShortDescription" in 'Description' field (if provided)
		And User enters "ShortSummary" in 'Summary' field
		And User clicks 'Cancel' button
	Then 'Category/Subcategory dropdown' error is 'Hidden' with message 'Error: Category must be specified.'
		And 'Term Name field empty' error is 'Hidden' with message 'Error: Term Name must be specified.'
		And 'Term Name field length' error is 'Hidden' with message 'Error: Term Name has exceeded maximum of 256 characters.'
		And 'Description field length' error is 'Hidden' with message 'Error: Description has exceeded maximum of 256 characters.'
		And 'Summary field empty' error is 'Hidden' with message 'Error: Summary must be specified.'
		And User checks the Template with name "ShortName" not found


@PositiveTests @EditTermScenario
Scenario: Editing existing TERM with all Short Length values
	Given There is existing TERM with the following parameters:
		| Key         | Value            |
		| KeyTerm     | unchecked        |
		| Category    | Basic Terms      |
		| TermName    | ShortName        |
		| Description | ShortDescription |
		| Summary     | ShortSummary     |
	When User changes checkbox 'KeyTerm' to "checked"
		And User changes 'Category/Subcategory' dropdown to "Jurisdiction"
		And User changes 'Term Name' field to "MaxLengthName"
		And User changes 'Description' field to "MaxLengthDescription"
		And User changes 'Summary' field to "MaxLengthSummary"
		And User clicks 'Save' button
	Then Alert with message 'Template has been saved' appears
		And User searches for "MaxLengthName" in 'Search field' and clicks
		And Template has "checked" state
		And Template has 'Category/Subcategory' like "Jurisdiction"
		And Template has 'Term Name' like "MaxLengthName"
		And Template has 'Term Template Key' like "ShortName"
		And Template has 'Description' like "MaxLengthDescription" (if provided)
		And Template has 'Summary' like "MaxLengthSummary"
		And User clicks 'Delete' button
		And Alert with message 'Template has been removed' appears
		And User checks the Template with name "MaxLengthName" not found


@NegativeTests @ErrorMessage
Scenario: Editing existing TERM changin Short Length Name value to Over Max Length Name
	Given There is existing TERM with the following parameters:
		| Key         | Value            |
		| KeyTerm     | unchecked        |
		| Category    | Basic Terms      |
		| TermName    | ShortName        |
		| Description | ShortDescription |
		| Summary     | ShortSummary     |
	When User changes 'Term Name' field to "OverMaxLengthName"
		And User clicks 'Save' button
	Then 'Term Name field length' error is 'Shown' with message 'Error: Term Name has exceeded maximum of 256 characters.'
		And User clicks 'Cancel' button
		And User checks the Template with name "MaxLengthName" not found
		And User searches for "ShortName" in 'Search field' and clicks
		And Template has "unchecked" state
		And Template has 'Category/Subcategory' like "Basic Terms"
		And Template has 'Term Name' like "ShortName"
		And Template has 'Term Template Key' like "ShortName"
		And Template has 'Description' like "ShortDescription" (if provided)
		And Template has 'Summary' like "ShortSummary"
		And User clicks 'Delete' button
		And Alert with message 'Template has been removed' appears
		And User checks the Template with name "ShortName" not found


@PositiveTests @EditTermScenario
Scenario: Editing existing TERM with Max Length values and empty Description
	Given There is existing TERM with the following parameters:
		| Key         | Value            |
		| KeyTerm     | checked          |
		| Category    | Budgets          |
		| TermName    | MaxLengthName    |
		| Description |                  |
		| Summary     | MaxLengthSummary |
	When User changes checkbox 'KeyTerm' to "unchecked"
		And User changes 'Category/Subcategory' dropdown to "Conflicts"
		And User changes 'Term Name' field to "ShortName"
		And User changes 'Description' field to "ShortDescription"
		And User changes 'Summary' field to "ShortSummary"
		And User clicks 'Save' button
	Then Alert with message 'Template has been saved' appears
		And User searches for "ShortName" in 'Search field' and clicks
		And Template has "unchecked" state
		And Template has 'Category/Subcategory' like "Conflicts"
		And Template has 'Term Name' like "ShortName"
		And Template has 'Term Template Key' like "MaxLengthName"
		And Template has 'Description' like "ShortDescription" (if provided)
		And Template has 'Summary' like "ShortSummary"
		And User clicks 'Delete' button
		And Alert with message 'Template has been removed' appears
		And User checks the Template with name "ShortName" not found


@NegativeTests @ErrorMessage
Scenario: Editing existing TERM changing Short Length Description value to Over Max Length Description
	Given There is existing TERM with the following parameters:
		| Key         | Value            |
		| KeyTerm     | unchecked        |
		| Category    | Basic Terms      |
		| TermName    | ShortName        |
		| Description | ShortDescription |
		| Summary     | ShortSummary     |
	When User changes 'Description' field to "OverMaxLengthDescription"
		And User clicks 'Save' button
	Then 'Description field length' error is 'Shown' with message 'Error: Description has exceeded maximum of 256 characters.'
		And User clicks 'Cancel' button
		And User searches for "ShortName" in 'Search field' and clicks
		And Template has "unchecked" state
		And Template has 'Category/Subcategory' like "Basic Terms"
		And Template has 'Term Name' like "ShortName"
		And Template has 'Term Template Key' like "ShortName"
		And Template has 'Description' like "ShortDescription" (if provided)
		And Template has 'Summary' like "ShortSummary"
		And User clicks 'Delete' button
		And Alert with message 'Template has been removed' appears
		And User checks the Template with name "ShortName" not found


@NegativeTests @ErrorMessage
Scenario: Editing existing TERM changing Short Length values to empty values
	Given There is existing TERM with the following parameters:
		| Key         | Value            |
		| KeyTerm     | unchecked        |
		| Category    | Basic Terms      |
		| TermName    | ShortName        |
		| Description | ShortDescription |
		| Summary     | ShortSummary     |
	When User changes 'Category/Subcategory' dropdown to "-- Select Category --"
		And User changes 'Term Name' field to ""
		And User changes 'Description' field to ""
		And User changes 'Summary' field to ""
		And User clicks 'Save' button
	Then 'Category/Subcategory dropdown' error is 'Shown' with message 'Error: Category must be specified.'
		And 'Term Name field empty' error is 'Shown' with message 'Error: Term Name must be specified.'
		And 'Term Name field length' error is 'Hidden' with message 'Error: Term Name has exceeded maximum of 256 characters.'
		And 'Description field length' error is 'Hidden' with message 'Error: Description has exceeded maximum of 256 characters.'
		And 'Summary field empty' error is 'Shown' with message 'Error: Summary must be specified.'
		And User clicks 'Cancel' button
		And User searches for "ShortName" in 'Search field' and clicks
		And Template has "unchecked" state
		And Template has 'Category/Subcategory' like "Basic Terms"
		And Template has 'Term Name' like "ShortName"
		And Template has 'Term Template Key' like "ShortName"
		And Template has 'Description' like "ShortDescription" (if provided)
		And Template has 'Summary' like "ShortSummary"
		And User clicks 'Delete' button
		And Alert with message 'Template has been removed' appears
		And User checks the Template with name "ShortName" not found


@NegativeTest @ErrorMessage
Scenario: Creating a TERM with Category, TermName and Summary fields empty and validation after clicking Save button
	Given User on the template creation page
		And User clicked 'create new template' button
		And All fields are empty
		And 'Category/Subcategory dropdown' error is 'Hidden' with message 'Error: Category must be specified.'
		And 'Term Name field empty' error is 'Hidden' with message 'Error: Term Name must be specified.'
		And 'Term Name field length' error is 'Hidden' with message 'Error: Term Name has exceeded maximum of 256 characters.'
		And 'Description field length' error is 'Hidden' with message 'Error: Description has exceeded maximum of 256 characters.'
		And 'Summary field empty' error is 'Hidden' with message 'Error: Summary must be specified.'
	When User clicks 'Save' button
	Then 'Category/Subcategory dropdown' error is 'Shown' with message 'Error: Category must be specified.'
		And 'Term Name field empty' error is 'Shown' with message 'Error: Term Name must be specified.'
		And 'Term Name field length' error is 'Hidden' with message 'Error: Term Name has exceeded maximum of 256 characters.'
		And 'Description field length' error is 'Hidden' with message 'Error: Description has exceeded maximum of 256 characters.'
		And 'Summary field empty' error is 'Shown' with message 'Error: Summary must be specified.'


@NegativeTest @ErrorMessage
Scenario: Creating a TERM with Category field populated and TermName and Summary fields filled with spaces
	Given User clicked 'create new template' button
		And All fields are empty
	When User selects "Budgets" in 'Category/Subcategory' dropdown
		And User enters "      " in 'Term Name' field
		And User enters "      " in 'Summary' field
		And User clicks 'Save' button
	Then 'Category/Subcategory dropdown' error is 'Hidden' with message 'Error: Category must be specified.'
		And 'Term Name field empty' error is 'Shown' with message 'Error: Term Name must be specified.'
		And 'Term Name field length' error is 'Hidden' with message 'Error: Term Name has exceeded maximum of 256 characters.'
		And 'Description field length' error is 'Hidden' with message 'Error: Description has exceeded maximum of 256 characters.'
		And 'Summary field empty' error is 'Shown' with message 'Error: Summary must be specified.'
		And User checks the Template with name "      " not found


@NegativeTest @ErrorMessage
Scenario: Creating a TERM with Category field populated and TermName and Summary fields empty
	Given User clicked 'create new template' button
		And All fields are empty
	When User selects "Budgets" in 'Category/Subcategory' dropdown
		And User clicks 'Save' button
	Then 'Category/Subcategory dropdown' error is 'Hidden' with message 'Error: Category must be specified.'
		And 'Term Name field empty' error is 'Shown' with message 'Error: Term Name must be specified.'
		And 'Term Name field length' error is 'Hidden' with message 'Error: Term Name has exceeded maximum of 256 characters.'
		And 'Description field length' error is 'Hidden' with message 'Error: Description has exceeded maximum of 256 characters.'
		And 'Summary field empty' error is 'Shown' with message 'Error: Summary must be specified.'


@NegativeTest @ErrorMessage
Scenario: Creating a TERM with Category and TermName fields populated and Summary field empty
	Given User clicked 'create new template' button
		And All fields are empty
	When User selects "Budgets" in 'Category/Subcategory' dropdown
		And User enters "ShortName" in 'Term Name' field
		And User clicks 'Save' button
	Then 'Category/Subcategory dropdown' error is 'Hidden' with message 'Error: Category must be specified.'
		And 'Term Name field empty' error is 'Hidden' with message 'Error: Term Name must be specified.'
		And 'Term Name field length' error is 'Hidden' with message 'Error: Term Name has exceeded maximum of 256 characters.'
		And 'Description field length' error is 'Hidden' with message 'Error: Description has exceeded maximum of 256 characters.'
		And 'Summary field empty' error is 'Shown' with message 'Error: Summary must be specified.'
		And User checks the Template with name "ShortName" not found


@NegativeTest @ErrorMessage
Scenario: Creating a TERM with Category and Summary fields populated and TermName field empty
	Given User clicked 'create new template' button
		And All fields are empty
	When User selects "Budgets" in 'Category/Subcategory' dropdown
		And User enters "ShortSummary" in 'Summary' field
		And User clicks 'Save' button
	Then 'Category/Subcategory dropdown' error is 'Hidden' with message 'Error: Category must be specified.'
		And 'Term Name field empty' error is 'Shown' with message 'Error: Term Name must be specified.'
		And 'Term Name field length' error is 'Hidden' with message 'Error: Term Name has exceeded maximum of 256 characters.'
		And 'Description field length' error is 'Hidden' with message 'Error: Description has exceeded maximum of 256 characters.'
		And 'Summary field empty' error is 'Hidden' with message 'Error: Summary must be specified.'


@NegativeTest @ErrorMessage
Scenario: Creating a TERM with TermName field populated and Category and Summary fields empty
	Given User clicked 'create new template' button
		And All fields are empty
	When User enters "ShortName" in 'Term Name' field
		And User clicks 'Save' button
	Then 'Category/Subcategory dropdown' error is 'Shown' with message 'Error: Category must be specified.'
		And 'Term Name field empty' error is 'Hidden' with message 'Error: Term Name must be specified.'
		And 'Term Name field length' error is 'Hidden' with message 'Error: Term Name has exceeded maximum of 256 characters.'
		And 'Description field length' error is 'Hidden' with message 'Error: Description has exceeded maximum of 256 characters.'
		And 'Summary field empty' error is 'Shown' with message 'Error: Summary must be specified.'
		And User checks the Template with name "ShortName" not found


@NegativeTest @ErrorMessage
Scenario: Creating a TERM with Summary field populated and Category and TermName fields empty
	Given User clicked 'create new template' button
		And All fields are empty
	When User enters "ShortSummary" in 'Summary' field
		And User clicks 'Save' button
	Then 'Category/Subcategory dropdown' error is 'Shown' with message 'Error: Category must be specified.'
		And 'Term Name field empty' error is 'Shown' with message 'Error: Term Name must be specified.'
		And 'Term Name field length' error is 'Hidden' with message 'Error: Term Name has exceeded maximum of 256 characters.'
		And 'Description field length' error is 'Hidden' with message 'Error: Description has exceeded maximum of 256 characters.'
		And 'Summary field empty' error is 'Hidden' with message 'Error: Summary must be specified.'


@NegativeTest @ErrorMessage
Scenario: Creating a TERM with TermName and Summary fields populated and Category field empty
	Given User clicked 'create new template' button
		And All fields are empty
	When User enters "ShortName" in 'Term Name' field
		And User enters "ShortSummary" in 'Summary' field
		And User clicks 'Save' button
	Then 'Category/Subcategory dropdown' error is 'Shown' with message 'Error: Category must be specified.'
		And 'Term Name field empty' error is 'Hidden' with message 'Error: Term Name must be specified.'
		And 'Term Name field length' error is 'Hidden' with message 'Error: Term Name has exceeded maximum of 256 characters.'
		And 'Description field length' error is 'Hidden' with message 'Error: Description has exceeded maximum of 256 characters.'
		And 'Summary field empty' error is 'Hidden' with message 'Error: Summary must be specified.'
		And User checks the Template with name "ShortName" not found


@NegativeTest @ErrorMessage
Scenario: Creating a TERM with TermName field length more than 256 chars
	Given User clicked 'create new template' button
		And All fields are empty
	When User selects "Budgets" in 'Category/Subcategory' dropdown
		And User enters "OverMaxLengthName" in 'Term Name' field
		And User enters "ShortDescription" in 'Description' field (if provided)
		And User enters "ShortSummary" in 'Summary' field
		And User clicks 'Save' button
	Then 'Category/Subcategory dropdown' error is 'Hidden' with message 'Error: Category must be specified.'
		And 'Term Name field empty' error is 'Hidden' with message 'Error: Term Name must be specified.'
		And 'Term Name field length' error is 'Shown' with message 'Error: Term Name has exceeded maximum of 256 characters.'
		And 'Description field length' error is 'Hidden' with message 'Error: Description has exceeded maximum of 256 characters.'
		And 'Summary field empty' error is 'Hidden' with message 'Error: Summary must be specified.'
		And User checks the Template with name "OverMaxLengthName" not found


@NegativeTest @ErrorMessage
Scenario: Creating a TERM with Description field length more than 256 chars
	Given User clicked 'create new template' button
		And All fields are empty
	When User selects "Budgets" in 'Category/Subcategory' dropdown
		And User enters "ShortName" in 'Term Name' field
		And User enters "OverMaxLengthDescription" in 'Description' field (if provided)
		And User enters "ShortSummary" in 'Summary' field
		And User clicks 'Save' button
	Then 'Category/Subcategory dropdown' error is 'Hidden' with message 'Error: Category must be specified.'
		And 'Term Name field empty' error is 'Hidden' with message 'Error: Term Name must be specified.'
		And 'Term Name field length' error is 'Hidden' with message 'Error: Term Name has exceeded maximum of 256 characters.'
		And 'Description field length' error is 'Shown' with message 'Error: Description has exceeded maximum of 256 characters.'
		And 'Summary field empty' error is 'Hidden' with message 'Error: Summary must be specified.'
		And User checks the Template with name "ShortName" not found

@NegativeTest @ErrorMessage
Scenario: Creating a TERM with TermName that already exists
	Given There is existing TERM with the following parameters:
		| Key         | Value            |
		| KeyTerm     | checked          |
		| Category    | Basic Terms      |
		| TermName    | ShortName        |
		| Description | ShortDescription |
		| Summary     | ShortSummary     |
		And User clicked 'create new template' button
		And All fields are empty
	When User selects "Jurisdiction" in 'Category/Subcategory' dropdown
		And User enters "ShortName" in 'Term Name' field
		And User enters "ShortDescription" in 'Description' field (if provided)
		And User enters "ShortSummary" in 'Summary' field
		And User clicks 'Save' button
	Then 'Name already exists' error is 'Shown' with message 'Error. Term Template with the same name already exists.'
		And User closes 'Name already exists' error message
		And User enters "MaxLengthName" in 'Term Name' field
		And User clicks 'Save' button
		And Alert with message 'Template has been saved' appears
		And User searches for "ShortName" in 'Search field' and clicks
		And User clicks 'Delete' button
		And User searches for "MaxLengthName" in 'Search field' and clicks
		And User clicks 'Delete' button
		And Alert with message 'Template has been removed' appears
		And User checks the Template with name "ShortName" not found
		And User checks the Template with name "MaxLengthName" not found


@NegativeTest @ErrorMessage
Scenario: Deleting not existing TERM errors
	Given There is existing TERM with the following parameters:
		| Key         | Value            |
		| KeyTerm     | unchecked        |
		| Category    | Basic Terms      |
		| TermName    | ShortName        |
		| Description | ShortDescription |
		| Summary     | ShortSummary     |
	When User searches for "ShortName" in 'Search field' and clicks
		And User double-clicks 'Delete button' to delete the term
	Then 'Term not found (ID)' error is 'Shown' with message 'Error. The term definition is not found'
		And 'Requested Resource is not found' error is 'Shown' with message 'The requested resource is not found'
		And User checks the Template with name "ShortName" not found


@PositiveTest
Scenario: Check if predinstalled TERM has Category/Subcategory dropdown and Delete button hidden
	Given User on the template creation page
	When User searches for "Client Waiver Requirement" in 'Search field' and clicks
	Then 'Delete button' is hidden
		And 'Category/Subcategory' dropdown is hidden


# IMPORTANT: TermTemplateDefinition.ixt containing term with name "Name import" and other fields "%FieldName% import" required
# IMPORTANT: Term with name "Name import" should not be present in the TERM's list
# IMPORTANT: File for test is located in "Templates" folder. Place in in the root of drive D:\ or update the absolute path in the test
@PositiveTest
Scenario: Import Templates
	Given User checks the Template with name "Name import" not found
		And User on the template creation page
		And User clicked 'action arrow' of the 'create new template' button
	When User clicks 'Import Templates' button
		And User selects file "D:\TermTemplateDefinition.ixt" to upload
		And 'Choose file to import' element contains "TermTemplateDefinition.ixt" text
		And User clicks 'Import' button
	Then Alert with message 'All templates have been imported successfully! Please ensure new templates work with existing Terms Rules.' appears
		And User searches for "Name import" in 'Search field' and clicks
		And Template has "checked" state
		And Template has 'Category/Subcategory' like "Invoices"
		And Template has 'Term Name' like "Name import"
		And Template has 'Term Template Key' like "Name import"
		And Template has 'Description' like "Description import" (if provided)
		And Template has 'Summary' like "Summary import"
		And User clicks 'Delete' button
		And Alert with message 'Template has been removed' appears
		And User checks the Template with name "Name import" not found