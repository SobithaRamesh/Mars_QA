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
    public static class Skill_Tab
    {
        private static IWebElement SkillTab() => Driver.driver.FindElement(By.XPath(XPathHelper.SkillTab_XPath));
        private static IWebElement AddNewBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.AddNewBtn_XPath));
        private static IWebElement AddBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.AddBtn_XPath));       
        private static IWebElement AddSkillTextBox() => Driver.driver.FindElement(By.XPath(XPathHelper.AddSkillTextBox_Xpath));
        private static IWebElement SkillLevelDropdown() => Driver.driver.FindElement(By.XPath(XPathHelper.SkillLevelDropdown_XPath));
        private static IWebElement UpdateBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.UpdateBtn_Xpath));
        private static IWebElement UpdateIcon(String xpath) => Driver.driver.FindElement(By.XPath(xpath));
        private static IWebElement UpdateSkillTextBox(String xpath) => Driver.driver.FindElement(By.XPath(xpath));
        private static IWebElement UpdateSkillLevel(String xpath) => Driver.driver.FindElement(By.XPath(xpath));
        private static IWebElement DeleteIcon(String xpath) => Driver.driver.FindElement(By.XPath(xpath));

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

        public static void EditSkills()
        {
            int i = 1, row = 1;

            string Adding_Skills_Excel = "";
            string Adding_Level_Excel = "";
            string EditSkills_Excel = "";
            string EditSkillLevel_Excel = "";

            //Excel sheet path
            ExcelLibHelper.PopulateInCollection(@"C:\Users\sobis\Desktop\Internship\Mars\Repo\MarsQA-1\SpecflowTests\Data\SkillsData.xlsx", "Editing Skill");
            //Adding
            do
            {
                if (i >= 2)
                {
                    //Click on AddNew button
                    AddNewBtn().Click();
                    //Enter Skill
                    AddSkillTextBox().SendKeys(Adding_Skills_Excel);
                    //Enter Skill Level
                    SkillLevelDropdown().SendKeys(Adding_Level_Excel);
                    //Click Add button
                    AddBtn().Click();

                    Thread.Sleep(2000);
                    row = FindDataByRow(Adding_Skills_Excel, Adding_Level_Excel);
                    string UpdateIcon_S = XPathHelper.UpdateIcon_Part1 + row + XPathHelper.UpdateIcon_Part2;
                    string SkillTextBox_S = XPathHelper.SkillTextBox_Part1 + row + XPathHelper.SkillTextBox_Part2;
                    string SkillLevel_S = XPathHelper.SkillLevel_Part1 + row + XPathHelper.SkillLevel_Part2;
                    //Click on Update icon
                    UpdateIcon(UpdateIcon_S).Click();
                    //Enter Skill
                    //Thread.Sleep(2000);
                    UpdateSkillTextBox(SkillTextBox_S).Clear();
                    UpdateSkillTextBox(SkillTextBox_S).SendKeys(EditSkills_Excel);
                    //Enter Skill Level
                    UpdateSkillLevel(SkillLevel_S).SendKeys(EditSkillLevel_Excel);
                    //Click Update button
                    UpdateBtn().Click();
                }
                i = i + 1;

                //Read Skills from excel
                Adding_Skills_Excel = ExcelLibHelper.ReadData(i, "Adding_Skills");
                //Read Skill Level from excel
                Adding_Level_Excel = ExcelLibHelper.ReadData(i, "Adding_SkillLevel");
                //Read Skills from excel
                EditSkills_Excel = ExcelLibHelper.ReadData(i, "EditSkills");
                //Read Skill Level from excel
                EditSkillLevel_Excel = ExcelLibHelper.ReadData(i, "EditSkillLevel");

            } while (Adding_Skills_Excel != null);
        }

        public static void ValidateEditedSkills()
        {
            int i = 1;
            string EditSkills_Excel = "";
            string EditSkillLevel_Excel = "";
            bool result = false;

            //Excel sheet path
            ExcelLibHelper.PopulateInCollection(@"C:\Users\sobis\Desktop\Internship\Mars\Repo\MarsQA-1\SpecflowTests\Data\SkillsData.xlsx", "Editing Skill");

            do
            {
                if (i >= 2)
                {
                    result = Compare(EditSkills_Excel, EditSkillLevel_Excel);
                    Assert.AreEqual(true, result);
                }
                i = i + 1;

                //Read Skills from excel
                EditSkills_Excel = ExcelLibHelper.ReadData(i, "EditSkills");
                //Read Skill Level from excel
                EditSkillLevel_Excel = ExcelLibHelper.ReadData(i, "EditSkillLevel");

            } while (EditSkills_Excel != null);
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

    }
}
