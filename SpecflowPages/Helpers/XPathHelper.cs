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

        //AddNew Button XPath
        public static string AddNewBtn_XPath = "//div[@class='ui teal button'][text()='Add New']";

        //Add Button XPath
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

    }
}
