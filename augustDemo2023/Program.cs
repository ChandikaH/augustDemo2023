﻿using OpenQA.Selenium;
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

// Create a new time record

// Navigate to time and Material module
IWebElement administrationDropdown = driver.FindElement(By.XPath(""));
administrationDropdown.Click();

IWebElement tmOption = driver.FindElement(By.XPath(""));
tmOption.Click();

// Click on create new button
IWebElement createNewButton = driver.FindElement(By.XPath(""));
createNewButton.Click();

// Select Time from dropdown

// Enter code

// Enter description

// Enter the price (don’t worry about the file selector for now)

// Click on save button

// Check if new time record has been created successfully
