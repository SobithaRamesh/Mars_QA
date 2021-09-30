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

        [Given(@"Seller selects the skills tab in profile page")]
        public void GivenSellerSelectsTheSkillsTabInProfilePage()
        {
            Skill_Tab SkillObj = new Skill_Tab();
            SkillObj.GoToSKillsTab();
        }

        [When(@"Seller adds his/her skills and Skill Level")]
        public void WhenSellerAddsHisHerSkillsAndSkillLevel()
        {
            Skill_Tab SkillAdd = new Skill_Tab();
            SkillAdd.AddSkills();
        }

        [Then(@"The skills should be added successfully")]
        public void ThenTheSkillsShouldBeAddedSuccessfully()
        {
            Skill_Tab SkillVerifyAdd = new Skill_Tab();
            Assert.AreEqual(true, SkillVerifyAdd.ValidateAddedSkills());
        }


        [When(@"Seller edits his/her skills and Skill Level")]
        public void WhenSellerEditsHisHerSkillsAndSkillLevel()
        {
            Skill_Tab SkillEdit = new Skill_Tab();
            SkillEdit.EditSkills();
        }

        [Then(@"The skills should be updated successfully")]
        public void ThenTheSkillsShouldBeUpdatedSuccessfully()
        {
            Skill_Tab SkillVerifyEdit = new Skill_Tab();
            Assert.AreEqual(true, SkillVerifyEdit.ValidateEditedSkills());
        }

        [When(@"Seller deletes his/her skills and Skill Level")]
        public void WhenSellerDeletesHisHerSkillsAndSkillLevel()
        {
            Skill_Tab SkillDelete = new Skill_Tab();
            SkillDelete.DeleteSkills();
        }

        [Then(@"The skills should be deleted successfully")]
        public void ThenTheSkillsShouldBeDeletedSuccessfully()
        {
            Skill_Tab SkillVerifyDelete = new Skill_Tab();
            Assert.AreEqual(true, SkillVerifyDelete.ValidateDeleteSkills());
        }

    }
}