using MarsQA_1.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsQA_1.SpecflowPages.Helpers
{
    public class XPathHelper
    {
        //SkillTab XPath
        public static string SkillTab_XPath = "//a[@data-tab='second']";

        //Skill AddNew Button XPath
        public static string AddNewBtn_XPath = "//div[@class='ui teal button'][text()='Add New']";

        //Skill Add Button XPath
        public static string AddBtn_XPath = "//input[@value='Add'][1]";

        //AddSkill TextBox XPath
        public static string AddSkillTextBox_Xpath = "//input[@placeholder='Add Skill']";

        //SkillLevel Dropdown XPath
        public static string SkillLevelDropdown_XPath = "//select[@name='level']";

        //Update Button XPath
        public static string UpdateBtn_Xpath = "//input[@value='Update']";

        //XPath for finding SkillTextBox dynamically
        public static String SkillTextBox_Part1 = "//div[@data-tab='second']//table//tbody[";
        public static String SkillTextBox_Part2 = "]//tr//td//div//div[1]//input";

        //XPath for finding Update Icon dynamically
        public static String UpdateIcon_Part1 = "//div[@data-tab='second']//table//tbody[";
        public static String UpdateIcon_Part2 = "]//tr//td[3]//span[1]//i";

        //XPath for finding SkillLevel dynamically
        public static String SkillLevel_Part1 = "//div[@data-tab='second']//table//tbody[";
        public static String SkillLevel_Part2 = "]//tr//td//div//div[2]//select";

        //XPath for finding Delete Icon dynamically
        public static string DeleteIcon_Part1 = "//div[@data-tab='second']//table//tbody[";
        public static string DeleteIcon_Part2 = "]//tr//td[3]//span[2]//i";


        //Certifications Tab XPath
        public static String CertificationsTab_XPath = "//a[@data-tab='fourth']";

        //Certification TextBox XPath
        public static String AddCertificationTextBox_XPath = "//input[@placeholder='Certificate or Award']";

        //CertifiedFrom TextBox XPath
        public static String CertifiedFromTextBox_XPath = "//input[@placeholder='Certified From (e.g. Adobe)']";

        //Year of Certification XPath
        public static String YearofCertificationDropdown_XPath = "//select[@name='certificationYear']";

        //Certification AddNew Button XPath
        public static String CertiAddNewBtn_XPath = "//div[@id='account-profile-section']/div/section[2]//table/thead/tr/th[4]/div";

        //Certification Add Button XPath
        public static String CertiAddBtn_XPath = "//input[@value='Add']";

        //Certification Update Button XPath
        public static string CertiUpdateBtn_Xpath = "//input[@value='Update']";

        //XPath for finding Certification Update Icon dynamically
        public static String CertiUpdateIcon_Part1 = "//div[@data-tab='fourth']//table//tbody[";
        public static String CertiUpdateIcon_Part2 = "]//tr//td[4]//span[1]";

        //XPath for finding CertificationTextBox dynamically
        public static String CertiTextBox_Part1 = "//div[@data-tab='fourth']//table//tbody[";
        public static String CertiTextBox_Part2 = "]//tr//td//div//div//div[1]//input";

        //XPath for finding CertifiedFromTextBox dynamically
        public static String FromTextBox_Part1 = "//div[@data-tab='fourth']//table//tbody[";
        public static String FromTextBox_Part2 = "]//tr//td//div//div//div[2]//input";

        //XPath for finding Year of Certification dynamically
        public static String YearofCertificationDropdown_Part1 = "//div[@data-tab='fourth']//table//tbody[";
        public static String YearofCertificationDropdown_Part2 = "]//tr//td//div//div//div[3]//select";

        //XPath for finding Certification Delete Icon dynamically
        public static string CertiDeleteIcon_Part1 = "//div[@data-tab='fourth']//table//tbody[";
        public static string CertiDeleteIcon_Part2 = "]//tr//td[4]//span[2]";

    }
}
