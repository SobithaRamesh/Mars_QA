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
     class Skill_Tab
    {   
        private IWebElement SkillTab() => Driver.driver.FindElement(By.XPath(XPathHelper.SkillTab_XPath));
        private IWebElement AddNewBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.AddNewBtn_XPath));
        private IWebElement AddBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.AddBtn_XPath));       
        private IWebElement AddSkillTextBox() => Driver.driver.FindElement(By.XPath(XPathHelper.AddSkillTextBox_Xpath));
        private IWebElement SkillLevelDropdown() => Driver.driver.FindElement(By.XPath(XPathHelper.SkillLevelDropdown_XPath));
        private IWebElement UpdateBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.UpdateBtn_Xpath));
        private IWebElement UpdateIcon(String xpath) => Driver.driver.FindElement(By.XPath(xpath));
        private IWebElement UpdateSkillTextBox(String xpath) => Driver.driver.FindElement(By.XPath(xpath));
        private IWebElement UpdateSkillLevel(String xpath) => Driver.driver.FindElement(By.XPath(xpath));
        private IWebElement DeleteIcon(String xpath) => Driver.driver.FindElement(By.XPath(xpath));

        public string AddSkills_Excel { get; private set; }
        public string AddSkillLevel_Excel { get; private set; }

        public void GoToSKillsTab()
        {
            //Click on Skill Tab
            SkillTab().Click();
        }

        public void AddSkills()
        {
            int i = 1;

            //Excel sheet path
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.SkillsExcelPath,ConstantHelpers.AddingSkillsSheet);
            
            do
            {
                if (i >= 2)
                {
                    //Adding Skills and SkillLevel data
                    AddSkillData();
                }
                i = i + 1;

                //Read Skills from excel
                AddSkills_Excel = ExcelLibHelper.ReadData(i, "Skills");
                //Read Skill Level from excel
                AddSkillLevel_Excel = ExcelLibHelper.ReadData(i, "SkillLevel");

            } while (AddSkills_Excel != null);
        }

        public bool ValidateAddedSkills()
        {   
            int i = 1;
            bool result = false;

            do
            {
                if (i >= 2)
                {
                    result = Compare(AddSkills_Excel, AddSkillLevel_Excel);
                    return true;
                }
                i = i + 1;

                //Read Skills from excel
                AddSkills_Excel = ExcelLibHelper.ReadData(i, "Skills");
                //Read Skill Level from excel
                AddSkillLevel_Excel = ExcelLibHelper.ReadData(i, "SkillLevel");

            } while (AddSkills_Excel != null);
            return false;
        }

        public void EditSkills()
        {
            int i = 1, row = 1;
            string EditSkills_Excel = "";
            string EditSkillLevel_Excel = "";

            //Excel sheet path
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.SkillsExcelPath,ConstantHelpers.EditingSkillsSheet);
            //Adding
            do
            {
                if (i >= 2)
                {
                    //Adding Skills and SkillLevel data
                    AddSkillData();

                    Thread.Sleep(2000);
                    row = FindDataByRow(AddSkills_Excel, AddSkillLevel_Excel);
                    string UpdateIcon_S = XPathHelper.UpdateIcon_Part1 + row + XPathHelper.UpdateIcon_Part2;
                    string SkillTextBox_S = XPathHelper.SkillTextBox_Part1 + row + XPathHelper.SkillTextBox_Part2;
                    string SkillLevel_S = XPathHelper.SkillLevel_Part1 + row + XPathHelper.SkillLevel_Part2;
                    
                    //Click on Update icon
                    UpdateIcon(UpdateIcon_S).Click();
                    //Enter Skill
                    UpdateSkillTextBox(SkillTextBox_S).Clear();
                    UpdateSkillTextBox(SkillTextBox_S).SendKeys(EditSkills_Excel);
                    //Enter Skill Level
                    UpdateSkillLevel(SkillLevel_S).SendKeys(EditSkillLevel_Excel);
                    //Click Update button
                    UpdateBtn().Click();
                }
                i = i + 1;

                //Read Skills from excel
                AddSkills_Excel = ExcelLibHelper.ReadData(i, "Adding_Skills");
                //Read Skill Level from excel
                AddSkillLevel_Excel = ExcelLibHelper.ReadData(i, "Adding_SkillLevel");
                //Read Skills from excel
                EditSkills_Excel = ExcelLibHelper.ReadData(i, "EditSkills");
                //Read Skill Level from excel
                EditSkillLevel_Excel = ExcelLibHelper.ReadData(i, "EditSkillLevel");

            } while (AddSkills_Excel != null);
        }

        public bool ValidateEditedSkills()
        {
            int i = 1;
            string EditSkills_Excel = "";
            string EditSkillLevel_Excel = "";
            bool result = false;

            do
            {
                if (i >= 2)
                {
                    result = Compare(EditSkills_Excel, EditSkillLevel_Excel);
                    return true;
                }
                i = i + 1;

                //Read Skills from excel
                EditSkills_Excel = ExcelLibHelper.ReadData(i, "EditSkills");
                //Read Skill Level from excel
                EditSkillLevel_Excel = ExcelLibHelper.ReadData(i, "EditSkillLevel");

            } while (EditSkills_Excel != null);
            return false;
        }

        public void DeleteSkills()
        {
            int i = 1, row;

            ExcelLibHelper.PopulateInCollection(ConstantHelpers.SkillsExcelPath,ConstantHelpers.DeletingSkillsSheet);
            do
            {
                if (i >= 2)
                {
                    //Adding Skills and SkillLevel data
                    AddSkillData();

                    Thread.Sleep(2000);
                    row = FindDataByRow(AddSkills_Excel, AddSkillLevel_Excel);
                    string DeleteIcon_S = XPathHelper.DeleteIcon_Part1 + row + XPathHelper.DeleteIcon_Part2;
                    DeleteIcon(DeleteIcon_S).Click();
                }
                i = i + 1;

                //Read Skill from excel
                AddSkills_Excel = ExcelLibHelper.ReadData(i, "Add_Skill");
                //Read Skill Level from excel
                AddSkillLevel_Excel = ExcelLibHelper.ReadData(i, "Add_SkillLevel");

            } while (AddSkills_Excel != null);
        }

        public bool ValidateDeleteSkills()
        {

            int i = 1;
            bool result = false;

            do
            {
                if (i >= 2)
                {

                    result = VerifyDeletedData(AddSkills_Excel, AddSkillLevel_Excel);
                    return true;
                }
                i = i + 1;
                //Read Skills from excel
                AddSkills_Excel = ExcelLibHelper.ReadData(i, "Add_Skill");
                //Read Skill Level from excel
                AddSkillLevel_Excel = ExcelLibHelper.ReadData(i, "Add_SkillLevel");

            } while (AddSkills_Excel != null);
            return false;
        }


        public bool Compare(String Skill, String SkillLevel)
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

        public int FindDataByRow(String Skill, String SkillLevel)
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

        public bool VerifyDeletedData(String Skill, String SkillLevel)
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

        public void AddSkillData()
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

       
    }
}
