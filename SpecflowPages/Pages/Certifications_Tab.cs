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
    class Certifications_Tab
    {
        private static IWebElement CertificationsTab() => Driver.driver.FindElement(By.XPath(XPathHelper.CertificationsTab_XPath));
        private static IWebElement AddCertificationTextBox() => Driver.driver.FindElement(By.XPath(XPathHelper.AddCertificationTextBox_XPath));
        private static IWebElement CertifiedFromTextBox() => Driver.driver.FindElement(By.XPath(XPathHelper.CertifiedFromTextBox_XPath));
        private static IWebElement YearofCertificationDropdown() => Driver.driver.FindElement(By.XPath(XPathHelper.YearofCertificationDropdown_XPath));
        private static IWebElement CertiAddNewBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.CertiAddNewBtn_XPath));
        private static IWebElement CertiAddBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.CertiAddBtn_XPath));
        private static IWebElement CertiUpdateBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.CertiUpdateBtn_Xpath));
        private static IWebElement CertiUpdateIcon(string xpath) => Driver.driver.FindElement(By.XPath(xpath));
        private static IWebElement UpdateCertiTextBox(string xpath) => Driver.driver.FindElement(By.XPath(xpath));
        private static IWebElement UpdateFromTextBox(string xpath) => Driver.driver.FindElement(By.XPath(xpath));
        private static IWebElement UpdateYearofCertificationDropdown(string xpath) => Driver.driver.FindElement(By.XPath(xpath));
        private static IWebElement CertiDeleteIcon(string xpath) => Driver.driver.FindElement(By.XPath(xpath));


        public static void GoToCertificationsTab()
        {
            //Click on  Certifications Tab
            CertificationsTab().Click();
        }

        public static void AddCertifications()
        {
            int i = 1;
            string AddCertifications_Excel = "";
            string AddCertifiedFrom_Excel = "";
            string AddCertifiedYear_Excel = "";

            //Excel sheet path
            ExcelLibHelper.PopulateInCollection(@"C:\Users\sobis\Desktop\Internship\Mars\Repo\MarsQA-1\SpecflowTests\Data\Certifications_Data.xlsx", "Add Certification");

            do
            {
                if (i >= 2)
                {
                    //Click on AddNew button
                    CertiAddNewBtn().Click();
                    //Enter Certification
                    AddCertificationTextBox().SendKeys(AddCertifications_Excel);
                    //Enter Certified From
                    CertifiedFromTextBox().SendKeys(AddCertifiedFrom_Excel);
                    //Enter Year of Certification
                    YearofCertificationDropdown().SendKeys(AddCertifiedYear_Excel);
                    //Click Add button
                    CertiAddBtn().Click();
                }
                i = i + 1;

                //Read Award/Certification from excel
                AddCertifications_Excel = ExcelLibHelper.ReadData(i, "Award");
                //Read Certified From from excel
                AddCertifiedFrom_Excel = ExcelLibHelper.ReadData(i, "From");
                //Read Year of Certification
                AddCertifiedYear_Excel = ExcelLibHelper.ReadData(i, "Year");

            } while (AddCertifications_Excel != null);
        }

        public static void ValidateAddedCertifications()
        {
            //Excel sheet path
            ExcelLibHelper.PopulateInCollection(@"C:\Users\sobis\Desktop\Internship\Mars\Repo\MarsQA-1\SpecflowTests\Data\Certifications_Data.xlsx", "Add Certification");

            int i = 1;
            string AddCertifications_Excel = "";
            string AddCertifiedFrom_Excel = "";
            string AddCertifiedYear_Excel = "";
            bool result = false;

            do
            {
                if (i >= 2)
                {
                    result = Compare(AddCertifications_Excel, AddCertifiedFrom_Excel, AddCertifiedYear_Excel);
                    Assert.AreEqual(true, result);
                }
                i = i + 1;

                //Read Award/Certification from excel
                AddCertifications_Excel = ExcelLibHelper.ReadData(i, "Award");
                //Read Certified From from excel
                AddCertifiedFrom_Excel = ExcelLibHelper.ReadData(i, "From");
                //Read Year of Certification
                AddCertifiedYear_Excel = ExcelLibHelper.ReadData(i, "Year");

            } while (AddCertifications_Excel != null);
        }

        public static void EditCertifications()
        {
            int i = 1, row = 1;

            string AddCertifications_Excel = "";
            string AddCertifiedFrom_Excel = "";
            string AddCertifiedYear_Excel = "";
            string EditCertifications_Excel = "";
            string EditCertifiedFrom_Excel = "";
            string EditCertifiedYear_Excel = "";

            //Excel sheet path
            ExcelLibHelper.PopulateInCollection(@"C:\Users\sobis\Desktop\Internship\Mars\Repo\MarsQA-1\SpecflowTests\Data\Certifications_Data.xlsx", "Edit Certification");
            //Adding
            do
            {
                if (i >= 2)
                {
                    //Click on AddNew button
                    CertiAddNewBtn().Click();
                    //Enter Certification
                    AddCertificationTextBox().SendKeys(AddCertifications_Excel);
                    //Enter Certified From
                    CertifiedFromTextBox().SendKeys(AddCertifiedFrom_Excel);
                    //Enter Year of Certification
                    YearofCertificationDropdown().SendKeys(AddCertifiedYear_Excel);
                    //Click Add button
                    CertiAddBtn().Click();

                    Thread.Sleep(2000);

                    row = FindDataByRow(AddCertifications_Excel, AddCertifiedFrom_Excel, AddCertifiedYear_Excel);
                    string CertiUpdateIcon_C = XPathHelper.CertiUpdateIcon_Part1 + row + XPathHelper.CertiUpdateIcon_Part2;
                    string CertiTextBox_C = XPathHelper.CertiTextBox_Part1 + row + XPathHelper.CertiTextBox_Part2;
                    string FromTextBox_C = XPathHelper.FromTextBox_Part1 + row + XPathHelper.FromTextBox_Part2;
                    string YearofCertificationDropdown_C = XPathHelper.YearofCertificationDropdown_Part1 + row + XPathHelper.YearofCertificationDropdown_Part2;

                    //Click on Update icon
                    CertiUpdateIcon(CertiUpdateIcon_C).Click();
                    //Enter Skill
                    Thread.Sleep(2000);
                    UpdateCertiTextBox(CertiTextBox_C).Clear();
                    UpdateCertiTextBox(CertiTextBox_C).SendKeys(EditCertifications_Excel);
                    UpdateFromTextBox(FromTextBox_C).Clear();
                    UpdateFromTextBox(FromTextBox_C).SendKeys(EditCertifiedFrom_Excel);
                    //Enter Skill Level
                    UpdateYearofCertificationDropdown(YearofCertificationDropdown_C).SendKeys(EditCertifiedYear_Excel);
                    

                    //Click Update button
                    CertiUpdateBtn().Click();
                }
                i = i + 1;
                //Read Skills from excel
                AddCertifications_Excel = ExcelLibHelper.ReadData(i, "Adding_Certi");
                //Read Skill Level from excel
                AddCertifiedFrom_Excel = ExcelLibHelper.ReadData(i, "Adding_CertifiedFrom");
                AddCertifiedYear_Excel= ExcelLibHelper.ReadData(i, "Adding_Year");
                //Read Skills from excel
                EditCertifications_Excel = ExcelLibHelper.ReadData(i, "EditCerti");
                //Read Skill Level from excel
                EditCertifiedFrom_Excel = ExcelLibHelper.ReadData(i, "EditCertifiedFrom");
                EditCertifiedYear_Excel = ExcelLibHelper.ReadData(i, "EditYear");


            } while (AddCertifications_Excel != null);
        }

        public static void ValidateEditedCertifications()
        {
            Thread.Sleep(2000);
            int i = 1;
            string EditCertifications_Excel = "";
            string EditCertifiedFrom_Excel = "";
            string EditCertifiedYear_Excel = "";
            bool result = false;

            //Excel sheet path
            ExcelLibHelper.PopulateInCollection(@"C:\Users\sobis\Desktop\Internship\Mars\Repo\MarsQA-1\SpecflowTests\Data\Certifications_Data.xlsx", "Edit Certification");

            do
            {
                if (i >= 2)
                {
                    result = Compare(EditCertifications_Excel, EditCertifiedFrom_Excel, EditCertifiedYear_Excel);
                    Assert.AreEqual(true, result);
                }
                i = i + 1;

                //Read Skills from excel
                EditCertifications_Excel = ExcelLibHelper.ReadData(i, "EditCerti");
                //Read Skill Level from excel
                EditCertifiedFrom_Excel = ExcelLibHelper.ReadData(i, "EditCertifiedFrom");
                EditCertifiedYear_Excel = ExcelLibHelper.ReadData(i, "EditYear");

            } while (EditCertifications_Excel != null);
        }

        public static void DeleteCertifications()
        {
            int i = 1, row;
            string AddCertifications_Excel = "";
            string AddCertifiedFrom_Excel = "";
            string AddCertifiedYear_Excel = "";

            ExcelLibHelper.PopulateInCollection(@"C:\Users\sobis\Desktop\Internship\Mars\Repo\MarsQA-1\SpecflowTests\Data\Certifications_Data.xlsx", "Delete Certification");
            do
            {
                if (i >= 2)
                {
                    //Click on AddNew button
                    CertiAddNewBtn().Click();
                    //Enter Certification
                    AddCertificationTextBox().SendKeys(AddCertifications_Excel);
                    //Enter Certified From
                    CertifiedFromTextBox().SendKeys(AddCertifiedFrom_Excel);
                    //Enter Year of Certification
                    YearofCertificationDropdown().SendKeys(AddCertifiedYear_Excel);
                    //Click Add button
                    CertiAddBtn().Click();

                    Thread.Sleep(2000);
                    row = FindDataByRow(AddCertifications_Excel, AddCertifiedFrom_Excel, AddCertifiedYear_Excel);
                    string CertiDeleteIcon_S = XPathHelper.CertiDeleteIcon_Part1 + row + XPathHelper.CertiDeleteIcon_Part2;
                    CertiDeleteIcon(CertiDeleteIcon_S).Click();
                }
                i = i + 1;

                //Read Skill from excel
                AddCertifications_Excel = ExcelLibHelper.ReadData(i, "Add_Award");
                //Read Skill Level from excel
                AddCertifiedFrom_Excel = ExcelLibHelper.ReadData(i, "Add_From");
                AddCertifiedYear_Excel = ExcelLibHelper.ReadData(i, "Add_Year");

            } while (AddCertifications_Excel != null);
        }

        public static void ValidateDeleteCertifications()
        {

            ExcelLibHelper.PopulateInCollection(@"C:\Users\sobis\Desktop\Internship\Mars\Repo\MarsQA-1\SpecflowTests\Data\Certifications_Data.xlsx", "Delete Certification");

            int i = 1;
            string AddCertifications_Excel = "";
            string AddCertifiedFrom_Excel = "";
            string AddCertifiedYear_Excel = "";
            bool result = false;

            do
            {
                if (i >= 2)
                {

                    result = VerifyDeletedData(AddCertifications_Excel, AddCertifiedFrom_Excel, AddCertifiedYear_Excel);
                    Assert.AreEqual(true, result);
                }
                i = i + 1;
                //Read Skill from excel
                AddCertifications_Excel = ExcelLibHelper.ReadData(i, "Add_Award");
                //Read Skill Level from excel
                AddCertifiedFrom_Excel = ExcelLibHelper.ReadData(i, "Add_From");
                AddCertifiedYear_Excel = ExcelLibHelper.ReadData(i, "Add_Year");

            } while (AddCertifications_Excel != null);
        }

        public static bool Compare(String Award, String From, String Year)
        {
            int i = 1;

            //Get the table element
            IWebElement tableElement = Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//table"));
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
                    String Award_Col = Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[" + i + "]//tr//td[1]")).Text;
                    String From_Col = Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[" + i + "]//tr//td[2]")).Text;
                    String Year_Col = Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[" + i + "]//tr//td[3]")).Text;


                    if (Award == Award_Col && From == From_Col && Year== Year_Col)
                    {
                        return true;
                    }
                    i = i + 1;
                }
            }
            return false;
        }

        public static int FindDataByRow(String Award, String From, String Year)
        {
            int i = 1;

            //Get the table element
            IWebElement tableElement = Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//table"));
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
                    String Award_Col = Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[" + i + "]//tr//td[1]")).Text;
                    String From_Col = Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[" + i + "]//tr//td[2]")).Text;
                    String Year_Col = Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[" + i + "]//tr//td[3]")).Text;


                    if (Award == Award_Col && From == From_Col && Year == Year_Col)
                    {
                        return i;
                    }
                    i = i + 1;
                }
            }
            return 0;
        }

        public static bool VerifyDeletedData(String Award, String From, String Year)
        {
            Thread.Sleep(3000);
            int i = 1;
            //Get the table element
            IWebElement tableElement = Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//table"));
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
                    String Award_Col = Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[" + i + "]//tr//td[1]")).Text;
                    String From_Col = Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[" + i + "]//tr//td[2]")).Text;
                    String Year_Col = Driver.driver.FindElement(By.XPath("//div[@data-tab='fourth']//tbody[" + i + "]//tr//td[3]")).Text;

                    if ((Award == Award_Col && From == From_Col && Year == Year_Col))
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
