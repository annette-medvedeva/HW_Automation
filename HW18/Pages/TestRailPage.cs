using HW18.Element;
using HW18.Waits;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW18.Pages
{
    public class TestRailPage : BasePage
    {
        WaitsHelper waitsHelper { get; set; }
        public TestRailPage(IWebDriver driver, bool openPageByUrl = false) : base(driver)
        {
            waitsHelper = new WaitsHelper(driver);
        }
        private static readonly By TitleBy = By.XPath("//div[@class='top-section text-ppp']");
        private static readonly By AddProjectButton = By.XPath("//a[@data-testid='sidebarProjectsAddButton']");
        private static readonly By NameProjectInput = By.XPath("//input[@data-testid='addProjectNameInput']");
        private static readonly By AnnouncementProjectInput = By.XPath("//textarea[contains(@class,'form-control form-control-full')]");
        private static readonly By IsShowAnnouncementCheckbox = By.XPath("//input[@data-testid='addEditProjectShowAnnouncement']");
        private static readonly By ProjectTypeRadioButton = By.XPath("//input[@data-testid='addEditProjectSuiteModeSingle']");
        private static readonly By IsEnableTestCaseCheckbox = By.XPath("//input[@data-testid='addEditProjectCaseStatusesEnabled']");
        private static readonly By successfullyAddedProject = By.XPath("//div[@data-testid='messageSuccessDivBox']");
        private static readonly By AddPrButton = By.XPath("//button[@data-testid='addEditProjectAddButton']");
        private static readonly By messageDeleteProject = By.XPath("//div[@data-testid='contentInnerTestId']//div");

        public override string GetEndpoint()
        {
            throw new NotImplementedException();
        }

        protected override bool EvaluateLoadedStatus()
        {
            return TestRailTitle().Displayed;
        }
        public IWebElement TestRailTitle()
        {
            return Driver.FindElement(TitleBy);
        }

        public IWebElement SucceessfulyAddProjectTitle()
        {
            return Driver.FindElement(successfullyAddedProject);
        }

        protected override void ExecuteLoad()
        {
            throw new NotImplementedException();
        }

        public IWebElement AddProject()
        {
            return Driver.FindElement(AddProjectButton); 
        }

        public IWebElement NameProject()
        {
            return Driver.FindElement(NameProjectInput);
        }

        public IWebElement AnnouncementProject()
        {
            return Driver.FindElement(AnnouncementProjectInput);
        }

        public IWebElement IsShowAnnouncement()
        {
            return Driver.FindElement(IsShowAnnouncementCheckbox);
        }

        public IWebElement ProjectTypeRadio()
        {
            return Driver.FindElement(ProjectTypeRadioButton);
        }
        public IWebElement IsEnableTestCase()
        {
            return Driver.FindElement(IsEnableTestCaseCheckbox);
        }
        public IWebElement AddButton()
        {
            return Driver.FindElement(AddPrButton);
        }

        public IWebElement DeleteButton(string projectName)
        {
            var projectRow = Driver.FindElement(By.XPath($"//tr[contains(td/a/text(), '{projectName}')]"));
            var deleteButton = projectRow.FindElement(By.CssSelector("td.action a[href^='javascript:void(0)']"));
            return deleteButton;
        }

        public void ConfirmDeleteProject()
        {
            var deleteCheckbox = Driver.FindElement(By.XPath("(//input[@data-testid='deleteCheckBoxTestId'])[3]"));
            if (!deleteCheckbox.Selected)
            {
                deleteCheckbox.Click();
            }
            var okButton = Driver.FindElement(By.CssSelector("a[data-testid='caseFieldsTabDeleteDialogButtonOk']"));
            okButton.Click();
            
            waitsHelper.WaitForVisibility(By.CssSelector("td.action a[href^='javascript:void(0)']"));
        }

        public IWebElement MessageDelete()
        {
            return Driver.FindElement(messageDeleteProject);
        }
    }
}
