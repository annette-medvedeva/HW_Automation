using HW18.Utils;
using HW18.Waits;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace HW18.Test;

public class ActionsTests : BaseTest
{
    [Test]
    public void HoverTest()
    {
        Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().HerokuappUrl + "hovers");
        var firstUserHover = Driver.FindElement(By.XPath("(//*[@class='figure'])[1]"));
        
        Actions
            .MoveToElement(firstUserHover, 5, 5)
            .Build()
            .Perform();
        WaitsHelper waitsHelper = new WaitsHelper(Driver, TimeSpan.FromSeconds(10));
        var viewFirstUser = waitsHelper.WaitForVisibility(By.LinkText("View profile"));
        viewFirstUser.Click();

        Assert.That(waitsHelper.WaitForVisibility(By.TagName("h1")).Text, Is.EqualTo("Not Found"));
    }


    [Test]
    public void DragAndDropTest()
    {
        Driver.Navigate().GoToUrl(Configurator.ReadConfiguration().HerokuappUrl + "drag_and_drop");
        var elementA = Driver.FindElement(By.Id("column-a"));
        var elementB = Driver.FindElement(By.Id("column-b"));

        Actions
            .MoveToElement(elementA)
            .DragAndDrop(elementA, elementB)
            .Build()
            .Perform();

        Assert.That(Driver.FindElement(By.XPath("//*[@id='column-a']//header")).Text, Is.EqualTo("B"));
    }

    [Test]
    public void ClickWithActions()
    {
        Driver.Navigate().GoToUrl("https://formy-project.herokuapp.com/scroll");

        var nameField = Driver.FindElement(By.Id("name"));

        Actions
            .MoveToElement(nameField)
            .Click()
            .SendKeys("Test Name")
            .Build()
            .Perform();
    }

}

