using Microsoft.Playwright;
using System.Threading.Tasks;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;

namespace CalculatorEndToEndTests
{
    public class PlaywrightTests : PageTest
    {
        //preq-E2E-TEST-5
        [Test]
        public async Task CalculatorWebUi_PageTitle_IsCalculator()
        {
            await Page.GotoAsync("http://localhost:5098");
            var title = await Page.TitleAsync();
            Assert.AreEqual("Calculator", title);
        }
        //preq-E2E-TEST-6
        [Test]
        public async Task CalculatorWebUi_SampleStandardDeviation_ValidInput_ReturnsCorrectResult()
        {
            // Navigate to the application
            await Page.GotoAsync("http://localhost:5098");
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            // Debug: Check if the button exists, is visible, and enabled
            var buttonExists = await Page.Locator("#sample-std-dev-btn").CountAsync();
            Assert.IsTrue(buttonExists > 0, "Button does not exist in the DOM.");

            var isButtonVisible = await Page.Locator("#sample-std-dev-btn").IsVisibleAsync();
            Assert.IsTrue(isButtonVisible, "Button is not visible on the page.");

            var isButtonEnabled = await Page.Locator("#sample-std-dev-btn").IsEnabledAsync();
            Assert.IsTrue(isButtonEnabled, "Button is not enabled.");

            // Wait for the button to become interactable
            await Page.WaitForSelectorAsync("#sample-std-dev-btn", new PageWaitForSelectorOptions
            {
                State = WaitForSelectorState.Visible
            });

            // Fill the textarea with values
            await Page.FillAsync("textarea#values", 
                "9\n2\n5\n4\n12\n7\n8\n11\n9\n3\n7\n4\n12\n5\n4\n10\n9\n6\n9\n4");
            
            // Click the button
            await Page.ClickAsync("#sample-std-dev-btn");

            // Wait for the result to appear
            await Page.WaitForSelectorAsync("#result", new PageWaitForSelectorOptions
            {
                State = WaitForSelectorState.Visible
            });

            // Retrieve and assert the result
            var result = await Page.TextContentAsync("#result");
            Assert.AreEqual("Sample Standard Deviation: 3.0607876523260447", result?.Trim());
        }
        //preq-E2E-TEST-7
        [Test]
        public async Task CalculatorWebUi_PopulationStandardDeviationWithEmptyList_EmptyInput_ReturnsErrorMessage()
        {
            // Navigate to the application
            await Page.GotoAsync("http://localhost:5098");

            // Wait for the page to load and network to be idle
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            // Wait for the population standard deviation button to be visible
            var buttonLocator = Page.Locator("#population-std-dev-btn");

            // Ensure the button exists in the DOM and is visible
            var buttonCount = await buttonLocator.CountAsync();
            Assert.IsTrue(buttonCount > 0, "Button does not exist in the DOM.");
            Assert.IsTrue(await buttonLocator.IsVisibleAsync(), "Button is not visible.");
            Assert.IsTrue(await buttonLocator.IsEnabledAsync(), "Button is not enabled.");

            // Fill the textarea with empty values (to trigger the error for empty input)
            await Page.FillAsync("textarea#values", ""); // Empty input

            // Click the button to compute population standard deviation
            await buttonLocator.ClickAsync();

            // Wait for the error message to appear in the DOM
            var resultLocator = Page.Locator("#result");

            // Wait for the result text to be updated
            await resultLocator.WaitForAsync();

            // Retrieve the result text
            var resultText = await resultLocator.TextContentAsync();

            // Assert that the error message is the expected one
            Assert.AreEqual("Error: Input cannot be empty.", resultText?.Trim());
        }
        //preq-E2E-TEST-8
        [Test]
        public async Task CalculatorWebUi_SampleStandardDeviation_SingleValueInput_ReturnsErrorMessage()
        {
            // Navigate to the application
            await Page.GotoAsync("http://localhost:5098");

            // Wait for the page to load and network to be idle
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);

            // Locate the textarea and fill in the single value
            var textareaLocator = Page.Locator("textarea#values");
            await textareaLocator.FillAsync("5");

            // Locate the button to compute the sample standard deviation
            var buttonLocator = Page.Locator("#sample-std-dev-btn");

            // Click the button
            await buttonLocator.ClickAsync();
            // Wait for the error message to appear in the DOM
            var resultLocator = Page.Locator("#result");
            // Retrieve the result text
            var resultText = await resultLocator.TextContentAsync();
            // Assert that the error message is the expected one
            Assert.AreEqual("Error: numValues is too low (sample size must be >= 2, population size must be >= 1)", resultText?.Trim());
        }
        //preq-E2E-TEST-9
        [Test]
        public async Task CalculatorWebUi_Mean_ValidInput_ReturnsCorrectResult()
        {
            await Page.GotoAsync("http://localhost:5098");
            // Wait for the page to load and network to be idle
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            // Locate the textarea and fill in the single value
            var textareaLocator = Page.Locator("textarea#values");
            await textareaLocator.FillAsync("9\n2\n5\n4\n12\n7\n8\n11\n9\n3\n7\n4\n12\n5\n4\n10\n9\n6\n9\n4");
            // Locate the button to compute the sample standard deviation
            var buttonLocator = Page.Locator("#mean-btn");
            // Click the button
            await buttonLocator.ClickAsync();
            // Wait for the error message to appear in the DOM
            var resultLocator = Page.Locator("#result");
            // Retrieve the result text
            var resultText = await resultLocator.TextContentAsync();
            // Assert that the error message is the expected one
            Assert.AreEqual("Mean: 7", resultText?.Trim());
            
        }
        //preq-E2E-TEST-10
        [Test]
        public async Task CalculatorWebUi_ZScore_ValidInput_ReturnsCorrectResult()
        {
            await Page.GotoAsync("http://localhost:5098");
            // Wait for the page to load and network to be idle
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            // Locate the textarea and fill in the single value
            var textareaLocator = Page.Locator("textarea#values");
            await textareaLocator.FillAsync("5.5,7,3.060787652326");
            // Locate the button to compute the sample standard deviation
            var buttonLocator = Page.Locator("#zscore-btn");
            // Click the button
            await buttonLocator.ClickAsync();
            // Wait for the error message to appear in the DOM
            var resultLocator = Page.Locator("#result");
            // Retrieve the result text
            var resultText = await resultLocator.TextContentAsync();
            // Assert that the error message is the expected one
            Assert.AreEqual("Z-Score: -0.49007", resultText?.Trim());
        }
        //preq-E2E-TEST-11
        [Test]
        public async Task CalculatorWebUi_SingleLinearRegression_ValidInput_ReturnsCorrectEquation()
        {
            await Page.GotoAsync("http://localhost:5098");
            // Wait for the page to load and network to be idle
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            
            var textareaLocator = Page.Locator("textarea#values");
            await textareaLocator.FillAsync("5,3\n 3,2\n 2,15\n 1,12.3\n 7.5,-3\n 4,5\n 3,17\n 4,3\n 6.42,4\n 34,5\n 12,17\n 3,-1");
            // Locate the button to compute the sample standard deviation
            var buttonLocator = Page.Locator("#slr-btn");
            // Click the button
            await buttonLocator.ClickAsync();
            // Wait for the error message to appear in the DOM
            var resultLocator = Page.Locator("#result");
            // Retrieve the result text
            var resultText = await resultLocator.TextContentAsync();
            // Assert that the error message is the expected one
            Assert.AreEqual("Single Linear Regression Formula: y = -0.04596X + 6.9336", resultText?.Trim());
        }
        //preq-E2E-TEST-12
        [Test]
        public async Task CalculatorWebUi_LinearRegressionPrediction_ValidInput_ReturnsCorrectPrediction()
        {
            await Page.GotoAsync("http://localhost:5098");
            // Wait for the page to load and network to be idle
            await Page.WaitForLoadStateAsync(LoadState.NetworkIdle);
            var textareaLocator = Page.Locator("textarea#values");
            await textareaLocator.FillAsync("6,-0.04596,6.9336");
            // Locate the button to compute the sample standard deviation
            var buttonLocator = Page.Locator("#predictY-btn");
            // Click the button
            await buttonLocator.ClickAsync();
            // Wait for the error message to appear in the DOM
            var resultLocator = Page.Locator("#result");
            // Retrieve the result text
            var resultText = await resultLocator.TextContentAsync();
            // Assert that the error message is the expected one
            Assert.AreEqual("Single Linear Regression Prediction y = 6.65784", resultText?.Trim());
        }
    }
}