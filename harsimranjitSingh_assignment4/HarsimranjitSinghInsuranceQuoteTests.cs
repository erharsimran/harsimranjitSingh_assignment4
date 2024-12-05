using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace harsimranjitSingh_assignment4
{
    public class HarsimranjitSinghInsuranceQuoteTests
    {
        public class BaseTest
        {
            protected IWebDriver driver;
            private WebDriverWait wait;

            [SetUp]
            public void SetUp()
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("http://localhost/prog8171_A04/getQuote.html"); // Replace with your form URL
            }
            [Test]
            public void InsuranceQuoteTest01_ValidData_Age25_Experience3_Accidents0()
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                FillForm("John", "Doe", "123 Maple St", "Toronto", "ON", "N2L 3G1", "123-456-7890", "john.doe@example.com", 25, 3, 0);
                AssertSuccessMessage("$4500");
            }

            [Test]
            public void InsuranceQuoteTest02_ValidData_Age25_Experience3_Accidents2()
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                FillForm("John", "Doe", "123 Maple St", "Toronto", "ON", "N2L 3G1", "123-456-7890", "john.doe@example.com", 25, 3, 2);
                AssertSuccessMessage("$4500");
            }

            [Test]
            public void InsuranceQuoteTest03_ValidData_Age35_Experience10_Accidents4()
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                FillForm("John", "Doe", "123 Maple St", "Toronto", "ON", "N2L 3G1", "123-456-7890", "john.doe@example.com", 35, 10, 4);
                AssertSuccessMessage("No Insurance for you!!  Too many accidents - go take a course!");
            }

            [Test]
            public void InsuranceQuoteTest04_InvalidPhoneNumber_Age27_Experience3_Accidents0()
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                FillForm("John", "Doe", "123 Maple St", "Toronto", "ON", "N2L 3G1", "invalid-phone", "john.doe@example.com", 27, 3, 0);
                Thread.Sleep(1000);
                AssertErrorMessage("Phone Number must follow the patterns 111-111-1111 or (111)111-1111", "phone-error");
            }

            [Test]
            public void InsuranceQuoteTest05_InvalidEmail_Age28_Experience3_Accidents0()
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                FillForm("John", "Doe", "123 Maple St", "Toronto", "ON", "N2L 3G1", "123-456-7890", "invalid-email", 28, 3, 0);
                AssertErrorMessage("Must be a valid email address", "email-error");
            }

            [Test]
            public void InsuranceQuoteTest06_InvalidPostalCode_Age35_Experience17_Accidents1()
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                FillForm("John", "Doe", "123 Maple St", "Toronto", "ON", "invalid-postal", "123-456-7890", "john.doe@example.com", 35, 17, 1);
                AssertErrorMessage("Postal Code must follow the pattern A1A 1A1", "postalCode-error");
            }

            [Test]
            public void InsuranceQuoteTest07_OmitAge_Experience5_Accidents0()
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                FillForm("John", "Doe", "123 Maple St", "Toronto", "ON", "N2L 3G1", "123-456-7890", "john.doe@example.com", null, 5, 0);
                AssertErrorMessage("Age (>=16) is required", "age-error");
            }

            [Test]
            public void InsuranceQuoteTest08_OmitAccidents_Age37_Experience8()
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                FillForm("John", "Doe", "123 Maple St", "Toronto", "ON", "N2L 3G1", "123-456-7890", "john.doe@example.com", 37, 8, null);
                AssertErrorMessage("Number of accidents is required", "accidents-error");
            }

            [Test]
            public void InsuranceQuoteTest09_OmitExperience_Age45_Accidents0()
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                FillForm("John", "Doe", "123 Maple St", "Toronto", "ON", "N2L 3G1", "123-456-7890", "john.doe@example.com", 45, null, 0);
                AssertErrorMessage("Years of experience is required", "experience-error");
            }

            [Test]
            public void InsuranceQuoteTest10_ValidData_Age30_Experience2_Accidents0()
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                FillForm("John", "Doe", "123 Maple St", "Toronto", "ON", "N2L 3G1", "123-456-7890", "john.doe@example.com", 30, 2, 0);
                AssertSuccessMessage("$3285");
            }

            [Test]
            public void InsuranceQuoteTest11_ValidData_Age35_Experience15_Accidents0()
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                FillForm("John", "Doe", "123 Maple St", "Toronto", "ON", "N2L 3G1", "123-456-7890", "john.doe@example.com", 35, 15, 0);
                AssertSuccessMessage("$2190");
            }

            [Test]
            public void InsuranceQuoteTest12_ValidData_Age29_Experience9_Accidents1()
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                FillForm("John", "Doe", "123 Maple St", "Toronto", "ON", "N2L 3G1", "123-456-7890", "john.doe@example.com", 29, 9, 1);
                AssertSuccessMessage("$4500");
            }

            [Test]
            public void InsuranceQuoteTest13_ValidData_Age40_Experience0_Accidents1()
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                FillForm("John", "Doe", "123 Maple St", "Toronto", "ON", "N2L 3G1", "123-456-7890", "john.doe@example.com", 40, 0, 1);
                AssertSuccessMessage("$6000");
            }

            [Test]
            public void InsuranceQuoteTest14_ValidData_Age50_Experience25_Accidents0()
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                FillForm("John", "Doe", "123 Maple St", "Toronto", "ON", "N2L 3G1", "123-456-7890", "john.doe@example.com", 50, 25, 0);
                AssertSuccessMessage("$2190");
            }

            [Test]
            public void InsuranceQuoteTest15_ValidData_Age55_Experience30_Accidents0()
            {
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                FillForm("John", "Doe", "123 Maple St", "Toronto", "ON", "N2L 3G1", "123-456-7890", "john.doe@example.com", 55, 30, 0);
                AssertSuccessMessage("$2190");
            }

            [TearDown]
            public void TearDown()
            {
                Dispose(); // Properly dispose the driver
            }

            public void Dispose()
            {
                if (driver != null)
                {
                    driver.Quit();
                    driver.Dispose();
                    driver = null;
                }
            }

            private void FillForm(string firstName, string lastName, string address, string city, string province, string postalCode, string phoneNumber, string email, int? age, int? drivingExperience, int? accidents)
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                driver.FindElement(By.Id("FirstName")).SendKeys(firstName ?? "");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                driver.FindElement(By.Id("LastName")).SendKeys(lastName ?? "");
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                driver.FindElement(By.Id("Address")).SendKeys(address);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                driver.FindElement(By.Id("City")).SendKeys(city);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                driver.FindElement(By.Id("Province")).SendKeys(province);
                driver.FindElement(By.Id("PostalCode")).SendKeys(postalCode);
                driver.FindElement(By.Id("phone")).SendKeys(phoneNumber);
                driver.FindElement(By.Id("email")).SendKeys(email);

                if (age.HasValue) driver.FindElement(By.Id("Age")).SendKeys(age.Value.ToString());
                if (drivingExperience.HasValue) driver.FindElement(By.Id("experience")).SendKeys(drivingExperience.Value.ToString());
                if (accidents.HasValue) driver.FindElement(By.Id("Accidents")).SendKeys(accidents.Value.ToString());
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                driver.FindElement(By.Id("btnSubmit")).Click();
            }

            private void AssertSuccessMessage(string expectedMessage)
            {
                // Wait for the input field to be present and visible
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement successElement = wait.Until(driver =>
                {
                    var element = driver.FindElement(By.Id("finalQuote"));
                    return element.Displayed ? element : null;
                });

                // Retrieve the value attribute of the input field
                string actualMessage = successElement.GetAttribute("value");
                Console.WriteLine(actualMessage);

                // Assert the expected message
                Assert.AreEqual(expectedMessage, actualMessage);
            }

            private void AssertErrorMessage(string expectedMessage, string id)
            {
                // Wait for the error message element to be visible
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                IWebElement errorElement = wait.Until(driver =>
                {
                    var element = driver.FindElement(By.Id(id));
                    return element.Displayed ? element : null;
                });

                // Retrieve the error message text
                string actualMessage = errorElement.Text;

                // Log the error message for debugging
                Console.WriteLine(actualMessage);

                // Assert the expected error message
                Assert.AreEqual(expectedMessage, actualMessage);
            }
        }
    }
}
