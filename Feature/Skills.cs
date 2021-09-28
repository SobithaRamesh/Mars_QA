using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    class Skills
    {

        [Given(@"Seller able to find skills")]
        public void GivenSellerAbleToFindSkills()
        {
            Adding_Skills.GoToSKillsTab();
        }

        [When(@"Seller adds his/her skills and Skill Level")]
        public void WhenSellerAddsHisHerSkillsAndSkillLevel()
        {
            Adding_Skills.AddSkills();
        }

        [Then(@"The skills should be added successfully")]
        public void ThenTheSkillsShouldBeAddedSuccessfully()
        {
            Adding_Skills.ValidateAddedSkills();
        }

        [Given(@"Seller is in profile page")]
        public void GivenSellerIsInProfilePage()
        {
            Updating_Skills.GoToSKillsTab();
        }

        [When(@"Seller edits his/her skills and Skill Level")]
        public void WhenSellerEditsHisHerSkillsAndSkillLevel()
        {
            Updating_Skills.EditSkills();
        }

        [Then(@"The skills should be updated successfully")]
        public void ThenTheSkillsShouldBeUpdatedSuccessfully()
        {
            Updating_Skills.ValidateEditedSkills();
        }

        [Given(@"Seller is in the profile page")]
        public void GivenSellerIsInTheProfilePage()
        {
            Deleting_Skills.GoToSKillsTab();
        }

        [When(@"Seller deletes his/her skills and Skill Level")]
        public void WhenSellerDeletesHisHerSkillsAndSkillLevel()
        {
            Deleting_Skills.DeleteSkills();
        }

        [Then(@"The skills should be deleted successfully")]
        public void ThenTheSkillsShouldBeDeletedSuccessfully()
        {
            Deleting_Skills.ValidateDeleteSkills();
        }

    }
}