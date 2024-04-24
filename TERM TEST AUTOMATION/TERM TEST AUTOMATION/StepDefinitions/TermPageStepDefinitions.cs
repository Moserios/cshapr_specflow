using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;

namespace TERM_TEST_AUTOMATION.StepDefinitions
{
    [Binding]
    public class TermPageStepDefinitions
    {
        private readonly IWebDriver _driver;
        private IWebElement _keyTermCheckbox;
        private IWebElement _categorySubcategoryDropdown;
        private IWebElement _termTemplateKeyField;
        private IWebElement _termNameField;
        private IWebElement _descriptionField;
        private IWebElement _summaryField;
        private IWebElement _saveButton;
        private IWebElement _cancelButton;
        private IWebElement _searchField;
        private IWebElement _deleteButton;


        public static class TestConstants
        {
            public static readonly string ShortName = "Short Name 123 !@#$%^&*()_+-=~`{}\\|/*<>,.?'\"";
            public static readonly string ShortDescription = "Short Description 123 !@#$%^&*()_+-=~`{}\\|/*<>,.?'\"";
            public static readonly string ShortSummary = "Short Summary 123 !@#$%^&*()_+-=~`{}\\|/*<>,.?'\"";

            public static readonly string MaxLengthName = "Max Length Name ! @ # $ % ^ & * ( ) _ + - = ~ ` { } \\ | / * < > , . ? ' \" a b c d e f g h i j k l m n o p q r s t u v w x y z A B C D E F G H I J K L M N O P Q R S T U V W X Y Z 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7";
            public static readonly string MaxLengthDescription = "Max Length Description ! @ # $ % ^ & * ( ) _ + - = ~ ` { } \\ | / * < > , . ? ' \" a b c d e f g h i j k l m n o p q r s t u v w x y z A B C D E F G H I J K L M N O P Q R S T U V W X Y Z 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 34";
            public static readonly string MaxLengthSummary = "Max Length Summary ! @ # $ % ^ & * ( ) _ + - = ~ ` { } \\ | / * < > , . ? ' \" a b c d e f g h i j k l m n o p q r s t u v w x y z A B C D E F G H I J K L M N O P Q R S T U V W X Y Z 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 56";

            public static readonly string OverMaxLengthName = "Over Max Length Name ! @ # $ % ^ & * ( ) _ + - = ~ ` { } \\ | / * < > , . ? ' \" a b c d e f g h i j k l m n o p q r s t u v w x y z A B C D E F G H I J K L M N O P Q R S T U V W X Y Z 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7";
            public static readonly string OverMaxLengthDescription = "Over Max Length Description ! @ # $ % ^ & * ( ) _ + - = ~ ` { } \\ | / * < > , . ? ' \" a b c d e f g h i j k l m n o p q r s t u v w x y z A B C D E F G H I J K L M N O P Q R S T U V W X Y Z 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4";
            public static readonly string OverMaxLengthSummary = "Over Max Length Summary ! @ # $ % ^ & * ( ) _ + - = ~ ` { } \\ | / * < > , . ? ' \" a b c d e f g h i j k l m n o p q r s t u v w x y z A B C D E F G H I J K L M N O P Q R S T U V W X Y Z 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6";
        }


        public static class TestValues
        {
            public static readonly Dictionary<string, string> Constants = new Dictionary<string, string>
            {
                {"ShortName", TestConstants.ShortName},
                {"MaxLengthName", TestConstants.MaxLengthName},
                {"OverMaxLengthName", TestConstants.OverMaxLengthName},
                {"ShortDescription", TestConstants.ShortDescription},
                {"MaxLengthDescription", TestConstants.MaxLengthDescription},
                {"OverMaxLengthDescription", TestConstants.OverMaxLengthDescription},
                {"ShortSummary", TestConstants.ShortSummary},
                {"MaxLengthSummary", TestConstants.MaxLengthSummary},
                {"OverMaxLengthSummary", TestConstants.OverMaxLengthSummary}
                // Add other mappings as needed
            };
        }


        public TermPageStepDefinitions(WebDriverSupport webDriverSupport)
        {
            _driver = webDriverSupport.Driver;
        }

        public void ReinitializeTemplateElements()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            _keyTermCheckbox = wait.Until(_driver => _driver.FindElement(By.CssSelector("input[type='checkbox'][ng-model='$ctrl.selectedState.template.keyTerm']")));
            _categorySubcategoryDropdown = wait.Until(_driver => _driver.FindElement(By.CssSelector("select[ng-model='$ctrl.selectedState.template.category']")));
            _termTemplateKeyField = wait.Until(_driver => _driver.FindElement(By.CssSelector("input[type='text'][ng-model='$ctrl.selectedState.template.key'][disabled]")));
            _termNameField = wait.Until(_driver => _driver.FindElement(By.CssSelector("input[type='text'][ng-model='$ctrl.selectedState.template.name']")));
            _descriptionField = wait.Until(_driver => _driver.FindElement(By.CssSelector("textarea[ng-model='$ctrl.selectedState.template.description']")));
            _summaryField = wait.Until(_driver => _driver.FindElement(By.CssSelector("textarea[ng-model='$ctrl.selectedState.summary']")));
            _saveButton = wait.Until(_driver => _driver.FindElement(By.CssSelector("button[ng-click='$ctrl.save()']")));
            _cancelButton = wait.Until(_driver => _driver.FindElement(By.CssSelector("button[ng-click='$ctrl.cancel()']")));
            _searchField = wait.Until(_driver => _driver.FindElement(By.CssSelector("input[ng-model='$ctrl.searchText'][placeholder='Search Category or Template']")));
            // Reinitialize other elements as needed
        }

        [Given(@"User on the template creation page")]
        public void GivenUserSeesTheFormToCreateANewTemplate()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement termCreateButton = wait.Until(driver => driver.FindElement(By.CssSelector("div.btn.btn-primary")));
            Assert.NotNull(termCreateButton, "Term create button should be present");
        }

        [Given(@"User clicks 'create new template' button")]
        [Given(@"User clicked 'create new template' button")]
        [When(@"User clicks 'create new template' button")]
        public void GivenUserClicksCreateNewTemplateButton()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement termCreateButton = wait.Until(_driver => _driver.FindElement(By.CssSelector("div.btn.btn-primary")));
            termCreateButton.Click();
            ReinitializeTemplateElements();
        }


        [Given(@"All fields are empty")]
        [When(@"All fields are empty")]
        public void GivenAllFieldsAreEmpty()
        {
            // Check if Key Term checkbox is unchecked
            if (_keyTermCheckbox.Selected)
            {
                Assert.Fail("Key Term checkbox is not in the unchecked state.");
            }

            // Check if Category/Subcategory dropdown has the default option
            SelectElement categoryDropdown = new SelectElement(_categorySubcategoryDropdown);
            string defaultOption = "-- Select Category --";
            if (categoryDropdown.SelectedOption.Text != defaultOption)
            {
                Assert.Fail("Category/Subcategory dropdown does not have the default option selected.");
            }

            // Assert that Term Template Key field is empty
            Assert.AreEqual("", _termTemplateKeyField.GetAttribute("value"), "Term Template Key field is not empty.");

            // Check if the Term Template Key field is disabled
            bool isFieldDisabled = _termTemplateKeyField.GetAttribute("disabled") != null;
            Assert.IsTrue(isFieldDisabled, "Term Template Key field is not disabled (read-only).");

            // Assert that Term Name field is empty
            Assert.AreEqual("", _termNameField.GetAttribute("value"), "Term Name field is not empty.");

            // Assert that Description field is empty
            Assert.AreEqual("", _descriptionField.GetAttribute("value"), "Description field is not empty.");

            // Assert that Summary field is empty
            Assert.AreEqual("", _summaryField.GetAttribute("value"), "Summary field is not empty.");

            // Check if the Delete button is present and assert it's not visible if found
            var deleteButtons = _driver.FindElements(By.CssSelector("button.btn.btn-cancel.btn-delete"));
            if (deleteButtons.Any())
            {
                Assert.IsFalse(deleteButtons.First().Displayed, "Delete button should not be visible.");
            }
        }


        [Given(@"User sets checkbox 'KeyTerm' to ""([^""]*)""")]
        [When(@"User sets checkbox 'KeyTerm' to ""([^""]*)""")]
        [When(@"User changes checkbox 'KeyTerm' to ""(.*)""")]
        public void WhenCheckboxIs(string keyTerm)
        {
            if (keyTerm.ToLower() == "checked")
            {
                if (!_keyTermCheckbox.Selected)
                    _keyTermCheckbox.Click();
            }
            else if (keyTerm.ToLower() == "unchecked")
            {
                if (_keyTermCheckbox.Selected)
                    _keyTermCheckbox.Click();
            }
            else
            {
                throw new ArgumentException("Invalid value for KeyTerm: " + keyTerm);
            }
        }


        [When(@"User selects ""([^""]*)"" in 'Category/Subcategory' dropdown")]
        [When(@"User changes 'Category/Subcategory' dropdown to ""(.*)""")]
        public void WhenUserSelectsInDropdown(string category)
        {
            // Normalize the category text by trimming whitespace
            string normalizedCategory = category.Trim();

            // JavaScript to select an option based on its text content
            string jsScript = $@"
            var select = arguments[0];
            for (var i = 0; i < select.options.length; i++) {{
                if (select.options[i].text.trim() === '{normalizedCategory}') {{
                    select.selectedIndex = i;
                    break;
                }}
            }}
            select.dispatchEvent(new Event('change'));";

            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)_driver;
            jsExecutor.ExecuteScript(jsScript, _categorySubcategoryDropdown);
        }


        [When(@"User enters ""([^""]*)"" in 'Term Name' field")]
        [When(@"User changes 'Term Name' field to ""(.*)""")]
        public void WhenUserEntersInField(string termNameKey)
        {
            _termNameField.Clear();

            if (TestValues.Constants.TryGetValue(termNameKey, out var termNameValue))
            {
                _termNameField.SendKeys(termNameValue);
            }
            else
            {
                _termNameField.SendKeys(termNameKey); // Fallback to using the key directly
            }

        }


        [When(@"User enters ""(.*)"" in 'Description' field \(if provided\)")]
        [When(@"User changes 'Description' field to ""(.*)""")]
        public void WhenUserEntersInDescriptionFieldIfProvided(string descriptionKey)
        {
            if (!string.IsNullOrEmpty(descriptionKey))
            {
                _descriptionField.Clear();

                if (TestValues.Constants.TryGetValue(descriptionKey, out var descriptionValue))
                {
                    _descriptionField.SendKeys(descriptionValue);
                }
                else
                {
                    _descriptionField.SendKeys(descriptionKey); // Fallback to using the key directly
                }

            }
        }


        [When(@"User enters ""(.*)"" in 'Summary' field")]
        [When(@"User changes 'Summary' field to ""(.*)""")]
        public void WhenUserEntersInSummaryField(string summaryKey)
        {
            _summaryField.Clear();

            if (TestValues.Constants.TryGetValue(summaryKey, out var summaryValue))
            {
                _summaryField.SendKeys(summaryValue);
            }
            else
            {
                _summaryField.SendKeys(summaryKey); // Fallback to using the key directly
            }
        }


        [When(@"User clicks 'Save' button")]
        [Then(@"User clicks 'Save' button")]
        public void ThenUserClicksSaveButton()
        {
            _saveButton.Click();
        }

        [Then(@"Alert with message '(.*)' appears")]
        public void ThenAlertWithMessageAppears(string message)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            var alertMessages = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("div.alert-success span")));

            string alertText = alertMessages.FirstOrDefault()?.Text.Trim();
            Assert.AreEqual(message, alertText, "The alert message text does not match the expected value.");

            var closeButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("button.glyphicon-remove.alert-success-close")));
            closeButton.Click();

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("div.alert-success")));
        }


        [When(@"User searches for ""(.*)"" in 'Search field' and clicks")]
        [Then(@"User searches for ""(.*)"" in 'Search field' and clicks")]
        public void ThenUserSearchesForInSearchFieldAndClicks(string termNameKey)
        {
            //ReinitializeTemplateElements();

            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            _searchField = wait.Until(_driver => _driver.FindElement(By.CssSelector("input[ng-model='$ctrl.searchText'][placeholder='Search Category or Template']")));

            string termName;
            _searchField.Clear();

            if (TestValues.Constants.TryGetValue(termNameKey, out var termNameValue))
            {
                termName = termNameValue;
                _searchField.SendKeys(termNameValue);
            }
            else
            {
                termName = termNameKey;
                _searchField.SendKeys(termNameKey); // Fallback to using the key directly
            }

            string cssForTermContainers = ".categories .template span.ng-binding";
            var searchResults = _driver.FindElements(By.CssSelector(cssForTermContainers));

            IWebElement searchResult = null;
            foreach (var result in searchResults)
            {
                if (result.Text.Equals(termName, StringComparison.OrdinalIgnoreCase))
                {
                    searchResult = result;
                    break;
                }
            }

            if (searchResult != null)
            {
                // Scroll into view if element is found
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", searchResult);
            }
            else
            {
                // Handle case where the term is not found
                Console.WriteLine($"TERM Template with name {termName} not found!");
            }


            // Try clicking the search result normally first
            try
            {
                searchResult.Click();
                //ReinitializeTemplateElements();
            }
            catch (Exception)
            {
                // If normal click fails, use JavaScript to click as a fallback
                ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", searchResult);
            }

        }


        [Then(@"User enters ""([^""]*)"" in 'Term Name' field")]
        public void ThenUserEntersInField(string termNameKey)
        {
            _termNameField.Clear();

            if (TestValues.Constants.TryGetValue(termNameKey, out var termNameValue))
            {
                _termNameField.SendKeys(termNameValue);
            }
            else
            {
                _termNameField.SendKeys(termNameKey); // Fallback to using the key directly
            }

        }


        [Then(@"Template has ""(.*)"" state")]
        public void ThenTemplateHasState(string keyTerm)
        {
            ReinitializeTemplateElements();
            bool expectedState = keyTerm.ToLower() == "checked";
            Assert.AreEqual(expectedState, _keyTermCheckbox.Selected);
        }


        [Then(@"Template has 'Category/Subcategory' like ""(.*)""")]
        public void ThenTemplateHasCategorySubcategoryFrom(string category)
        {
            SelectElement categoryDropdown = new SelectElement(_categorySubcategoryDropdown);
            string selectedCategory = categoryDropdown.SelectedOption.Text.Trim();
            Assert.AreEqual(category, selectedCategory);
        }


        [Then(@"Template has 'Term Name' like ""(.*)""")]
        public void ThenTemplateHasTermNameFrom(string termNameKey)
        {
            string termName;

            if (TestValues.Constants.TryGetValue(termNameKey, out var termNameValue))
            {
                termName = termNameValue;
            }
            else
            {
                termName = termNameKey; // Fallback to using the key directly
            }

            Assert.AreEqual(termName, _termNameField.GetAttribute("value"));
        }


        [Then(@"Template has 'Term Template Key' like ""(.*)""")]
        public void ThenTemplateHasTermTemplateKeyFrom(string termNameKey)
        {

            string termName;

            if (TestValues.Constants.TryGetValue(termNameKey, out var termNameValue))
            {
                termName = termNameValue;
            }
            else
            {
                termName = termNameKey; // Fallback to using the key directly
            }

            Assert.AreEqual(termName, _termTemplateKeyField.GetAttribute("value"));
        }


        [Then(@"Template has 'Description' like ""(.*)"" \(if provided\)")]
        public void ThenTemplateHasDescriptionFromIfProvided(string descriptionKey)
        {
            if (!string.IsNullOrEmpty(descriptionKey))
            {

                string description;

                if (TestValues.Constants.TryGetValue(descriptionKey, out var descriptionValue))
                {
                    description = descriptionValue;
                }
                else
                {
                    description = descriptionKey; // Fallback to using the key directly
                }

                Assert.AreEqual(description, _descriptionField.GetAttribute("value"));
            }
        }


        [Then(@"Template has 'Summary' like ""(.*)""")]
        public void ThenTemplateHasSummaryFrom(string summaryKey)
        {

            string summary;

            if (TestValues.Constants.TryGetValue(summaryKey, out var summaryValue))
            {
                summary = summaryValue;
            }
            else
            {
                summary = summaryKey; // Fallback to using the key directly
            }

            Assert.AreEqual(summary, _summaryField.GetAttribute("value"));
        }

        [Then(@"'Delete button' is hidden")]
        public void ThenDeleteButtonIsHidden()
        {
            // Check if the Delete button is present and assert it's not visible if found
            var deleteButtons = _driver.FindElements(By.CssSelector("button.btn.btn-cancel.btn-delete"));
            if (deleteButtons.Any())
            {
                Assert.IsFalse(deleteButtons.First().Displayed, "Delete button should not be visible.");
            }

            else
            {
                // Explicitly note the button is not present, which could be considered "hidden"
                Assert.True(true, "Delete button is not present, which is considered hidden.");
            }
        }


        [Then(@"'Category/Subcategory' dropdown is hidden")]
        public void ThenCatalogDropdownIsHidden()
        {
            // Check if the Category/Subcategory dropdown is present and assert it's not visible if found
            var categorySubcategoryDropdown = _driver.FindElements(By.CssSelector("select[ng-model='$ctrl.selectedState.template.category']"));
            if (categorySubcategoryDropdown.Any())
            {
                Assert.IsFalse(categorySubcategoryDropdown.First().Displayed, "'Category/Subcategory' dropdown should not be visible.");
            }

            else
            {
                // Explicitly note the button is not present, which could be considered "hidden"
                Assert.True(true, "Category/Subcategory is not present, which is considered hidden.");
            }
        }


        [When(@"User clicks 'Delete' button")]
        [Then(@"User clicks 'Delete' button")]
        public void ThenUserClicksDeleteButtonToDeleteTheCreatedTerm()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            _deleteButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("button.btn.btn-cancel.btn-delete")));
            _deleteButton.Click();
        }


        [When(@"User double-clicks 'Delete button' to delete the term")]
        public void WhenUserDoubleClicksDeleteButtonToDeleteTheCreatedTerm()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            _deleteButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("button.btn.btn-cancel.btn-delete")));

            var actions = new Actions(_driver);
            actions.Click(_deleteButton).Perform();
            Thread.Sleep(350); // It required here, Don't remove!!!!
            actions.Click(_deleteButton).Perform();
        }

        [Given(@"User checks the Template with name ""(.*)"" not found")]
        [Then(@"User checks the Template with name ""(.*)"" not found")]
        public void ThenChecksTheTemplateWithNameNotFound(string termNameKey)
        {
            string termName;
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            _searchField = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("input[ng-model='$ctrl.searchText'][placeholder='Search Category or Template']")));
            _searchField.Clear();

            if (TestValues.Constants.TryGetValue(termNameKey, out var termNameValue))
            {
                termName = termNameValue;
            }
            else
            {
                termName = termNameKey; // Fallback to using the key directly
            }

            Console.WriteLine($"Looking for TERM: {termName}");
            _searchField.SendKeys(termName);

            string cssForTermContainers = ".categories .template span.ng-binding";
            var searchResults = _driver.FindElements(By.CssSelector(cssForTermContainers));
            IWebElement searchResult = null;

            foreach (var result in searchResults)
            {
                if (result.Text.Equals(termName, StringComparison.OrdinalIgnoreCase))
                {
                    searchResult = result;
                    break;
                }
            }

            if (searchResult != null)
            {
                Console.WriteLine("TERM found when it should not be.");
                Assert.Fail("Template should not be found, but it was found.");
            }
            else
            {
                Console.WriteLine("No TERM was found, as expected.");
            }
        }


        public void VerifyInitialTermState(string keyTerm, string category, string termName, string description, string summary)
        {
            // Verifying the initial state of the TERM
            ThenTemplateHasState(keyTerm);
            ThenTemplateHasCategorySubcategoryFrom(category);
            ThenTemplateHasTermNameFrom(termName);
            // Assuming 'TermTemplateKey' follows the same value as 'termName'
            ThenTemplateHasTermTemplateKeyFrom(termName);
            if (!string.IsNullOrEmpty(description))
            {
                ThenTemplateHasDescriptionFromIfProvided(description);
            }
            ThenTemplateHasSummaryFrom(summary);
        }


        [Given(@"There is existing TERM with the following parameters:")]
        public void GivenThereIsExistingTERMWithTheFollowingParameters(Table table)
        {
            var parameters = table.Rows.ToDictionary(row => row["Key"], row => row["Value"]);

            GivenUserClicksCreateNewTemplateButton();
            GivenAllFieldsAreEmpty();

            WhenCheckboxIs(parameters["KeyTerm"]);
            WhenUserSelectsInDropdown(parameters["Category"]);
            WhenUserEntersInField(parameters["TermName"]);
            WhenUserEntersInDescriptionFieldIfProvided(parameters.ContainsKey("Description") ? parameters["Description"] : "");
            WhenUserEntersInSummaryField(parameters["Summary"]);

            // Save the TERM to ensure it's created before making edits
            ThenUserClicksSaveButton();

            // Optionally verify the TERM creation was successful
            ThenAlertWithMessageAppears("Template has been saved");

            //Find created TERM
            //ThenUserSearchesForInSearchField(parameters["TermName"]);
            ThenUserSearchesForInSearchFieldAndClicks(parameters["TermName"]);
            //ThenClicksOnTheFoundTemplate();

            VerifyInitialTermState(parameters["KeyTerm"], parameters["Category"], parameters["TermName"], parameters.ContainsKey("Description") ? parameters["Description"] : "", parameters["Summary"]);
            _searchField.Clear();
        }


        private By BuildErrorSelector(string fieldName)
        {
            switch (fieldName)
            {
                case "Category/Subcategory dropdown":
                    return By.CssSelector("div.validation-error[ng-show*='missingCategory']");
                case "Term Name field empty":
                    return By.CssSelector("div.validation-error[ng-show*='missingName']");
                case "Term Name field length":
                    return By.CssSelector("div.validation-error[ng-show*='longName']");
                case "Description field length":
                    return By.CssSelector("div.validation-error[ng-show*='longDescription']");
                case "Summary field empty":
                    return By.CssSelector("div.validation-error[ng-show*='missingSummary']");
                case "Name already exists":
                    return By.CssSelector("div.dynamic-system-message div.alert-danger span");
                case "Term not found (ID)":
                    return By.XPath("//div[contains(@class, 'alert-danger')]//span[contains(text(), 'Error. The term definition is not found')]");
                case "Requested Resource is not found":
                    return By.XPath("//div[contains(@class, 'alert-danger')]//span[contains(text(), 'The requested resource is not found:')]");
                // Add additional cases for other error messages here
                default:
                    throw new NotImplementedException($"No selector implemented for field name: {fieldName}");
            }
        }


        [Given(@"'(.*?)' error is '(Shown|Hidden)' with message '(.*)'")]
        [Then(@"'(.*?)' error is '(Shown|Hidden)' with message '(.*)'")]
        public void ThenErrorVisibilityIsWithMessage(string fieldName, string visibility, string expectedMessagePart)
        {
            By errorSelector = BuildErrorSelector(fieldName);

            if (visibility.Equals("Shown", StringComparison.OrdinalIgnoreCase))
            {
                var element = WaitForElementWithRetry(errorSelector, 15); // Adjust wait time as necessary
                Assert.IsTrue(element.Displayed, $"Error message for '{fieldName}' is not displayed as expected.");
            }
            else
            {
                var isNotVisible = WaitForElementToBeInvisible(errorSelector, 15);
                Assert.IsTrue(isNotVisible, $"Error message for '{fieldName}' should be hidden.");
            }
        }

        private bool WaitForElementToBeInvisible(By by, int totalWaitTimeInSeconds)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(totalWaitTimeInSeconds));
            return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
        }

        private IWebElement WaitForElementWithRetry(By by, int totalWaitTimeInSeconds, int intervalBetweenRetriesInSeconds = 2)
        {
            var endTime = DateTime.Now.AddSeconds(totalWaitTimeInSeconds);
            while (DateTime.Now < endTime)
            {
                try
                {
                    var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(intervalBetweenRetriesInSeconds));
                    return wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                }
                catch (NoSuchElementException Ex)
                {
                    Console.WriteLine($"Element not found: {Ex.Message}");
                    // Element not found yet, retry until timeout
                }
                catch (WebDriverTimeoutException Ex)
                {
                    // Element not visible within the wait time, retry
                    Console.WriteLine($"Element not visible: {Ex.Message}");
                }
            }
            throw new NoSuchElementException($"Element not found after {totalWaitTimeInSeconds} seconds using selector: {by}");
        }


        [Then(@"User closes 'Name already exists' error message")]
        public void UserClosesNameAlreadyExistsErrorMessage()
        {
            var closeButtonSelector = By.CssSelector("div.dynamic-system-message div.alert-danger button.alert-danger-close");
            var closeButton = _driver.FindElement(closeButtonSelector);
            closeButton.Click();
        }

        [When(@"User clicks 'Cancel' button")]
        [Then(@"User clicks 'Cancel' button")]
        public void WhenUserClicksCancelButton()
        {
            _cancelButton.Click();
        }


        [Then(@"User reloads the TERM management page")]
        public void WhenUserReloadsTheTERMManagementPage()
        {
            _driver.Navigate().Refresh();
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            _searchField = wait.Until(_driver => _driver.FindElement(By.CssSelector("input[ng-model='$ctrl.searchText'][placeholder='Search Category or Template']")));
            ReinitializeTemplateElements();
        }


        [Given(@"User clicked 'action arrow' of the 'create new template' button")]
        public void GivenUserClickedActionArrowOfTheCreateNewTemplateButton()
        {
            var actionArrow = _driver.FindElement(By.CssSelector("a.arrow-actions"));
            actionArrow.Click();
        }


        [When(@"User clicks 'Import Templates' button")]
        public void WhenUserClicksImportTemplatesButton()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            var importTemplatesButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.XPath("//div[@class='arrow-actions-popup']/a[text()='Import Templates']")));
            importTemplatesButton.Click();
        }


        [When(@"User selects file ""(.*)"" to upload")]
        public void WhenUserSelectsFileToUpload(string filePath)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            var fileInput = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("input[type='file'][name='TermStructureUploader']")));
            fileInput.SendKeys(filePath);
        }


        [When(@"'Choose file to import' element contains ""(.*)"" text")]
        public void WhenChooseFileToImportElementContainsText(string expectedFileName)
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            var chosenFileNameElement = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("span.file-name")));
            Assert.IsTrue(chosenFileNameElement.Text.Contains(expectedFileName), $"The file name {expectedFileName} is not present in the 'Choose file to import' element.");
        }

        [When(@"User clicks 'Import' button")]
        public void WhenUserClicksImportButton()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            var importButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.CssSelector("button[ng-click='ok()']")));
            importButton.Click();
        }

    }
}
