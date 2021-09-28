using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Helpers;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MarsQA_1.SpecflowPages.Pages
{
    public static class Adding_Skills
    {
        private static IWebElement SkillTab() => Driver.driver.FindElement(By.XPath(XPathHelper.SkillTab_XPath));
        private static IWebElement AddNewBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.AddNewBtn_XPath));
        private static IWebElement AddBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.AddBtn_XPath));       
        private static IWebElement AddSkillTextBox() => Driver.driver.FindElement(By.XPath(XPathHelper.AddSkillTextBox_Xpath));
        private static IWebElement SkillLevelDropdown() => Driver.driver.FindElement(By.XPath(XPathHelper.SkillLevelDropdown_XPath));
             
        public static void GoToSKillsTab()
        {
            //Click on Skill Tab
            SkillTab().Click();
        }

        public static void AddSkills()
        {
            int i = 1;
            string AddSkills_Excel = "";
            string AddSkillLevel_Excel = "";

            //Excel sheet path
            ExcelLibHelper.PopulateInCollection(@"C:\Users\sobis\Desktop\Internship\Mars\Repo\MarsQA-1\SpecflowTests\Data\SkillsData.xlsx", "Adding Skill");
            
            do
            {
                if (i >= 2)
                {
                    //Click on AddNew button
                    AddNewBtn().Click();
                    //Enter Skill
                    AddSkillTextBox().SendKeys(AddSkills_Excel);
                    //Enter Skill Level
                    SkillLevelDropdown().SendKeys(AddSkillLevel_Excel);
                    //Click Add button
                    AddBtn().Click();
                }
                i = i + 1;

                //Read Skills from excel
                AddSkills_Excel = ExcelLibHelper.ReadData(i, "Skills");
                //Read Skill Level from excel
                AddSkillLevel_Excel = ExcelLibHelper.ReadData(i, "SkillLevel");

            } while (AddSkills_Excel != null);
        }

        public static void ValidateAddedSkills()
        {
            //Excel sheet path
            ExcelLibHelper.PopulateInCollection(@"C:\Users\sobis\Desktop\Internship\Mars\Repo\MarsQA-1\SpecflowTests\Data\SkillsData.xlsx", "Adding Skill");
            
            int i = 1;
            string AddSkills_Excel = "";
            string AddSkillLevel_Excel = "";
            bool result = false;

            do
            {
                if (i >= 2)
                {
                    result = Compare(AddSkills_Excel, AddSkillLevel_Excel);
                    Assert.AreEqual(true, result);
                }
                i = i + 1;

                //Read Skills from excel
                AddSkills_Excel = ExcelLibHelper.ReadData(i, "Skills");
                //Read Skill Level from excel
                AddSkillLevel_Excel = ExcelLibHelper.ReadData(i, "SkillLevel");

            } while (AddSkills_Excel != null);
        }

        public static bool Compare(String Skill, String SkillLevel)
        {
            int i = 1;

            //Get the table element
            IWebElement tableElement = Driver.driver.FindElement(By.XPath("//div[@data-tab='second']//table"));
            //Get table rows from table into a collection
            IList<IWebElement> trCollection = tableElement.FindElements(By.TagName("tbody"));
            //Define tabledata collection
            IList<IWebElement> tdCollection;

            //loop every row in the table and find the correct row for the input
            foreach (IWebElement element in trCollection)
            {

                tdCollection = element.FindElements(By.TagName("td"));

                //list of all the columns in the row
                if (tdCollection.Count > 0)
                {
                    //Get the table data
                    String Skill_Col = Driver.driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[" + i + "]//tr//td[1]")).Text;
                    String SkillLevel_Col = Driver.driver.FindElement(By.XPath("//div[@data-tab='second']//tbody[" + i + "]//tr//td[2]")).Text;

                    if (Skill == Skill_Col && SkillLevel == SkillLevel_Col)
                    {
                        return true;
                    }
                    i = i + 1;
                }
            }
            return false;
        }     
    }
}
