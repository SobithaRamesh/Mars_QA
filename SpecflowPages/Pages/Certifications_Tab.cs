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
        private IWebElement CertificationsTab() => Driver.driver.FindElement(By.XPath(XPathHelper.CertificationsTab_XPath));
        private IWebElement AddCertificationTextBox() => Driver.driver.FindElement(By.XPath(XPathHelper.AddCertificationTextBox_XPath));
        private IWebElement CertifiedFromTextBox() => Driver.driver.FindElement(By.XPath(XPathHelper.CertifiedFromTextBox_XPath));
        private IWebElement YearofCertificationDropdown() => Driver.driver.FindElement(By.XPath(XPathHelper.YearofCertificationDropdown_XPath));
        private IWebElement CertiAddNewBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.CertiAddNewBtn_XPath));
        private IWebElement CertiAddBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.CertiAddBtn_XPath));
        private IWebElement CertiUpdateBtn() => Driver.driver.FindElement(By.XPath(XPathHelper.CertiUpdateBtn_Xpath));
        private IWebElement CertiUpdateIcon(string xpath) => Driver.driver.FindElement(By.XPath(xpath));
        private IWebElement UpdateCertiTextBox(string xpath) => Driver.driver.FindElement(By.XPath(xpath));
        private IWebElement UpdateFromTextBox(string xpath) => Driver.driver.FindElement(By.XPath(xpath));
        private IWebElement UpdateYearofCertificationDropdown(string xpath) => Driver.driver.FindElement(By.XPath(xpath));
        private IWebElement CertiDeleteIcon(string xpath) => Driver.driver.FindElement(By.XPath(xpath));

        public string AddCertifications_Excel { get; private set; }
        public string AddCertifiedFrom_Excel { get; private set; }
        public string AddCertifiedYear_Excel { get; private set; }

        public void GoToCertificationsTab()
        {
            //Click on  Certifications Tab
            CertificationsTab().Click();
        }

        public void AddCertifications()
        {
            int i = 1;

            //Excel sheet path
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.CertificationsExcelPath,ConstantHelpers.AddingCertificationSheet);

            do
            {
                if (i >= 2)
                {
                    //Adding Certification, CertifiedFrom and Year 
                    CertificationAddData();
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

        public bool ValidateAddedCertifications()
        {
           
            int i = 1;
            bool result = false;

            do
            {
                if (i >= 2)
                {
                    result = Compare(AddCertifications_Excel, AddCertifiedFrom_Excel, AddCertifiedYear_Excel);
                    return result;
                }
                i = i + 1;

                //Read Award/Certification from excel
                AddCertifications_Excel = ExcelLibHelper.ReadData(i, "Award");
                //Read Certified From from excel
                AddCertifiedFrom_Excel = ExcelLibHelper.ReadData(i, "From");
                //Read Year of Certification
                AddCertifiedYear_Excel = ExcelLibHelper.ReadData(i, "Year");

            } while (AddCertifications_Excel != null);
            return false;
        }

        public void EditCertifications()
        {
            int i = 1, row = 1;

            string EditCertifications_Excel = "";
            string EditCertifiedFrom_Excel = "";
            string EditCertifiedYear_Excel = "";

            //Excel sheet path
            ExcelLibHelper.PopulateInCollection(ConstantHelpers.CertificationsExcelPath,ConstantHelpers.EditingCertificationSheet);
            
            do
            {
                if (i >= 2)
                {
                    //Adding Certification, CertifiedFrom and Year 
                    CertificationAddData();

                    Thread.Sleep(2000);

                    row = FindDataByRow(AddCertifications_Excel, AddCertifiedFrom_Excel, AddCertifiedYear_Excel);
                    string CertiUpdateIcon_C = XPathHelper.CertiUpdateIcon_Part1 + row + XPathHelper.CertiUpdateIcon_Part2;
                    string CertiTextBox_C = XPathHelper.CertiTextBox_Part1 + row + XPathHelper.CertiTextBox_Part2;
                    string FromTextBox_C = XPathHelper.FromTextBox_Part1 + row + XPathHelper.FromTextBox_Part2;
                    string YearofCertificationDropdown_C = XPathHelper.YearofCertificationDropdown_Part1 + row + XPathHelper.YearofCertificationDropdown_Part2;

                    //Click on Update icon
                    CertiUpdateIcon(CertiUpdateIcon_C).Click();
                    
                    Thread.Sleep(2000);
                    
                    UpdateCertiTextBox(CertiTextBox_C).Clear();
                    //Enter Certification
                    UpdateCertiTextBox(CertiTextBox_C).SendKeys(EditCertifications_Excel);   
                    UpdateFromTextBox(FromTextBox_C).Clear();
                    //Enter Certified from
                    UpdateFromTextBox(FromTextBox_C).SendKeys(EditCertifiedFrom_Excel);
                    //Enter year of Certification
                    UpdateYearofCertificationDropdown(YearofCertificationDropdown_C).SendKeys(EditCertifiedYear_Excel);
                    

                    //Click Update button
                    CertiUpdateBtn().Click();
                }
                i = i + 1;
                //Read Certification from excel
                AddCertifications_Excel = ExcelLibHelper.ReadData(i, "Adding_Certi");
                //Read CertifiedFrom from excel
                AddCertifiedFrom_Excel = ExcelLibHelper.ReadData(i, "Adding_CertifiedFrom");
                //Read year of Certification
                AddCertifiedYear_Excel = ExcelLibHelper.ReadData(i, "Adding_Year");
                //Read Certification from excel
                EditCertifications_Excel = ExcelLibHelper.ReadData(i, "EditCerti");
                //Read CertifiedFrom from excel
                EditCertifiedFrom_Excel = ExcelLibHelper.ReadData(i, "EditCertifiedFrom");
                //Read year of Certification
                EditCertifiedYear_Excel = ExcelLibHelper.ReadData(i, "EditYear");


            } while (AddCertifications_Excel != null);
        }

        public bool ValidateEditedCertifications()
        {
            Thread.Sleep(2000);
            int i = 1;
            string EditCertifications_Excel = "";
            string EditCertifiedFrom_Excel = "";
            string EditCertifiedYear_Excel = "";
            bool result = false;

            do
            {
                if (i >= 2)
                {
                    result = Compare(EditCertifications_Excel, EditCertifiedFrom_Excel, EditCertifiedYear_Excel);
                    return result;
                }
                i = i + 1;

                //Read Certification from excel
                 EditCertifications_Excel = ExcelLibHelper.ReadData(i, "EditCerti");
                //Read CertifiedFrom from excel
                EditCertifiedFrom_Excel = ExcelLibHelper.ReadData(i, "EditCertifiedFrom");
                //Read year of Certification
                EditCertifiedYear_Excel = ExcelLibHelper.ReadData(i, "EditYear");

            } while (EditCertifications_Excel != null);
            return false;
        }

        public void DeleteCertifications()
        {
            int i = 1, row;

            ExcelLibHelper.PopulateInCollection(ConstantHelpers.CertificationsExcelPath,ConstantHelpers.DeletingCertificationSheet);
           
            do
            {
                if (i >= 2)
                {
                    //Adding Certification, CertifiedFrom and Year 
                    CertificationAddData();

                    Thread.Sleep(2000);
                    row = FindDataByRow(AddCertifications_Excel, AddCertifiedFrom_Excel, AddCertifiedYear_Excel);
                    string CertiDeleteIcon_S = XPathHelper.CertiDeleteIcon_Part1 + row + XPathHelper.CertiDeleteIcon_Part2;
                    CertiDeleteIcon(CertiDeleteIcon_S).Click();
                }
                i = i + 1;

                //Read Certification from excel
                AddCertifications_Excel = ExcelLibHelper.ReadData(i, "Add_Award");
                //Read CertifiedFrom from excel
                AddCertifiedFrom_Excel = ExcelLibHelper.ReadData(i, "Add_From");
                //Read year of Certification
                AddCertifiedYear_Excel = ExcelLibHelper.ReadData(i, "Add_Year");

            } while (AddCertifications_Excel != null);
        }

        public bool ValidateDeleteCertifications()
        {

            int i = 1;
            bool result = false;

            do
            {
                if (i >= 2)
                {

                    result = VerifyDeletedData(AddCertifications_Excel, AddCertifiedFrom_Excel, AddCertifiedYear_Excel);
                    return true;
                }
                i = i + 1;

                //Read Certification from excel
                AddCertifications_Excel = ExcelLibHelper.ReadData(i, "Add_Award");
                //Read CertifiedFrom from excel
                AddCertifiedFrom_Excel = ExcelLibHelper.ReadData(i, "Add_From");
                //Read year of Certification
                AddCertifiedYear_Excel = ExcelLibHelper.ReadData(i, "Add_Year");

            } while (AddCertifications_Excel != null);
            return false;
        }

        public bool Compare(String Award, String From, String Year)
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

        public int FindDataByRow(String Award, String From, String Year)
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

        public bool VerifyDeletedData(String Award, String From, String Year)
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

        private void CertificationAddData()
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
    }
}
