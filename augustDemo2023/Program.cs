using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

//Open Chrome browser
IWebDriver driver = new ChromeDriver();
//maximize the browser
driver.Manage().Window.Maximize();

//Launch turnup portal and Navigate to the website login page
driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");

//Identify username textbox and enter valid username
IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");

//identify password textbox and enter valid password
IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");

//identify login button and click on the button
IWebElement loginButton = driver.FindElement(By.XPath("//*[@id='loginForm']/form/div[3]/input[1]"));
loginButton.Click();

//check if user has logged in successfully
IWebElement helloHari = driver.FindElement(By.XPath("//*[@id='logoutForm']/ul/li/a"));

if (helloHari.Text == "Hello hari!")
{
    Console.WriteLine("User has logged in successfully");
}
else
{
    Console.WriteLine("User hasn't been logged in.");
}

//======================================Create a new time record====================================================

// Navigate to time and Material module
IWebElement administrationDropdown = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a/span"));
administrationDropdown.Click();

IWebElement tmOption = driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a"));
tmOption.Click();

// Click on create new button
IWebElement createNewButton = driver.FindElement(By.XPath("//a[@class='btn btn-primary']"));
createNewButton.Click();

// Select Time from dropdown
IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]/span"));
typeCodeDropdown.Click();

IWebElement timeTypeCode = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
timeTypeCode.Click();

// Enter code
IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
codeTextbox.SendKeys("September2023");

// Enter description
IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
descriptionTextbox.SendKeys("September2023");

// Enter the price (Note:don’t worry about the file selector for now)
IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
priceTextbox.SendKeys("12");

// Click on save button
IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
saveButton.Click();
//Note:Save the code and run to check the code is working correctly
//Delete the created record manually for teaching purposes

Thread.Sleep(5000);

// Check if new time record has been created successfully
IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
goToLastPageButton.Click();

IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
if (newCode.Text == "September2023")
{
    Console.WriteLine("New Time Record has been created successfully");
}
else
{
    Console.WriteLine("Time Record has not been created");
}

//======================================Edit added record====================================================

goToLastPageButton.Click();
Thread.Sleep(3000);

//Click on Edit Button
IWebElement editButton = driver.FindElement(By.XPath("//tbody/tr[last()]/td[5]/a[1]"));
editButton.Click();
Thread.Sleep(3000);

//Edit Code in Code Textbox
IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
editCodeTextbox.Clear();
editCodeTextbox.SendKeys("IC2023Edited");

//Edit Description in Description Textbox
IWebElement editDescriptionTextBox = driver.FindElement(By.Id("Description"));
editDescriptionTextBox.Clear();
editDescriptionTextBox.SendKeys("IC2023Edited");

//Edit Price in Price Textbox
IWebElement editPriceOverlappingTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
IWebElement editPriceTextBox = driver.FindElement(By.Id("Price"));
editPriceOverlappingTag.Click();
editPriceTextBox.Clear();
editPriceOverlappingTag.Click();
editPriceTextBox.SendKeys("500");

//Click on save button
IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
editSaveButton.Click();
Thread.Sleep(7000);

// Clock on goToLastPage Button
IWebElement editGoToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
editGoToLastPageButton.Click();

IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
IWebElement EditedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

if (editedCode.Text == "IC2023Edited" && EditedDescription.Text == "IC2023Edited")
{
    Console.WriteLine("Time Record has been updated successfully");
}
else
{
    Console.WriteLine("Time Record has not been updated");
}

//======================================Delete added record====================================================

goToLastPageButton.Click();
Thread.Sleep(3000);

//Click on delete button
IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
deleteButton.Click();

IAlert simpleAlert = driver.SwitchTo().Alert();
simpleAlert.Accept();

IWebElement lastCodeInTable = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
if (lastCodeInTable.Text != "IC2023Edited")
{
    Console.WriteLine("Time Record has been deleted successfully");
}
else
{
    Console.WriteLine("Time Record has not been deleted");
}