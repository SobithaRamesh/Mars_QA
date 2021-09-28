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
    public class Deleting_Skills
    {
        private static IWebElement SkillTab() => Driver.driver.FindElement(By.XPath(XPathHelper.SkillTab_XPath));
        private static IWebElement AddNewBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.AddNewBtn_XPath));
        private static IWebElement AddBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.AddBtn_XPath));
        private static IWebElement AddSkillTextBox() => Driver.driver.FindElement(By.XPath(XPathHelper.AddSkillTextBox_Xpath));
        private static IWebElement SkillLevelDropdown() => Driver.driver.FindElement(By.XPath(XPathHelper.SkillLevelDropdown_XPath));
        private static IWebElement DeleteIcon(String xpath) => Driver.driver.FindElement(By.XPath(xpath));

       
        public static void GoToSKillsTab()
        {
            //Click on Skill Tab
            SkillTab().Click();
        }

        public static void DeleteSkills()
        {
            int i = 1, row;
            string Adding_Skill_Excel = "";
            string Adding_SkillLevel_Excel = "";

            ExcelLibHelper.PopulateInCollection(@"C:\Users\sobis\Desktop\Internship\Mars\Repo\MarsQA-1\SpecflowTests\Data\SkillsData.xlsx", "Deleting Skill");
            do
            {
                if (i >= 2)
                {
                    //Click on AddNew button
                    AddNewBtn().Click();
                    //Enter Skill
                    AddSkillTextBox().SendKeys(Adding_Skill_Excel);
                    //Enter Skill Level
                    SkillLevelDropdown().SendKeys(Adding_SkillLevel_Excel);
                    //Click Add button
                    AddBtn().Click();

                    Thread.Sleep(2000);
                    row = FindDataByRow(Adding_Skill_Excel, Adding_SkillLevel_Excel);
                    string DeleteIcon_S = XPathHelper.DeleteIcon_Part1 + row + XPathHelper.DeleteIcon_Part2;
                    DeleteIcon(DeleteIcon_S).Click();
                }
                i = i + 1; 
                
                //Read Skill from excel
                Adding_Skill_Excel = ExcelLibHelper.ReadData(i, "Add_Skill");
                //Read Skill Level from excel
                Adding_SkillLevel_Excel = ExcelLibHelper.ReadData(i, "Add_SkillLevel");

            } while (Adding_Skill_Excel != null);
        }

        public static void ValidateDeleteSkills()
        {

            ExcelLibHelper.PopulateInCollection(@"C:\Users\sobis\Desktop\Internship\Mars\Repo\MarsQA-1\SpecflowTests\Data\SkillsData.xlsx", "Deleting Skill");

            int i = 1;
            string Adding_Skill_Excel = "";
            string Adding_SkillLevel_Excel = "";
            bool result = false;

            do
            {
                if (i >= 2)
                {

                    result = VerifyDeletedData(Adding_Skill_Excel, Adding_SkillLevel_Excel);
                    Assert.AreEqual(true, result);
                }
                i = i + 1;
                //Read Skills from excel
                Adding_Skill_Excel = ExcelLibHelper.ReadData(i, "Add_Skill");
                //Read Skill Level from excel
                Adding_SkillLevel_Excel = ExcelLibHelper.ReadData(i, "Add_SkillLevel");

            } while (Adding_Skill_Excel != null);
        }

        public static bool VerifyDeletedData(String Skill, String SkillLevel)
        {
            Thread.Sleep(3000);
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
                        return false;
                    }
                    i = i + 1;
                }
            }
            return true;
        }

        public static int FindDataByRow(String Skill, String SkillLevel)
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
                        return i;
                    }
                    i = i + 1;
                }
            }
            return 0;
        }
    }
}