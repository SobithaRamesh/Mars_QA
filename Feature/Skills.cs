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
            Skill_Tab.GoToSKillsTab();
        }

        [When(@"Seller adds his/her skills and Skill Level")]
        public void WhenSellerAddsHisHerSkillsAndSkillLevel()
        {
            Skill_Tab.AddSkills();
        }

        [Then(@"The skills should be added successfully")]
        public void ThenTheSkillsShouldBeAddedSuccessfully()
        {
            Skill_Tab.ValidateAddedSkills();
        }

        [Given(@"Seller is in profile page")]
        public void GivenSellerIsInProfilePage()
        {
            Skill_Tab.GoToSKillsTab();
        }

        [When(@"Seller edits his/her skills and Skill Level")]
        public void WhenSellerEditsHisHerSkillsAndSkillLevel()
        {
            Skill_Tab.EditSkills();
        }

        [Then(@"The skills should be updated successfully")]
        public void ThenTheSkillsShouldBeUpdatedSuccessfully()
        {
            Skill_Tab.ValidateEditedSkills();
        }

        [Given(@"Seller is in the profile page")]
        public void GivenSellerIsInTheProfilePage()
        {
            Skill_Tab.GoToSKillsTab();
        }

        [When(@"Seller deletes his/her skills and Skill Level")]
        public void WhenSellerDeletesHisHerSkillsAndSkillLevel()
        {
            Skill_Tab.DeleteSkills();
        }

        [Then(@"The skills should be deleted successfully")]
        public void ThenTheSkillsShouldBeDeletedSuccessfully()
        {
            Skill_Tab.ValidateDeleteSkills();
        }

    }
}