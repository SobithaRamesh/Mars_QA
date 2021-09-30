using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace MarsQA_1.Feature
{
    [Binding]
    class Certifications
    {
        
        [Given(@"Seller selects the Certification tab in profile page")]
        public void GivenSellerSelectsTheCertificationTabInProfilePage()
        {
            Certifications_Tab CertiObj = new Certifications_Tab();
            CertiObj.GoToCertificationsTab();
        }

        [When(@"Seller adds his/her Certification")]
        public void WhenSellerAddsHisHerCertification()
        {
            Certifications_Tab CertiAdd = new Certifications_Tab();
            CertiAdd.AddCertifications();
        }

        [Then(@"The Certification should be added successfully")]
        public void ThenTheCertificationShouldBeAddedSuccessfully()
        {
            Certifications_Tab CertiVerifyAdd = new Certifications_Tab();
            Assert.AreEqual(true, CertiVerifyAdd.ValidateAddedCertifications());
        }

        [When(@"Seller edits his/her Certification")]
        public void WhenSellerEditsHisHerCertification()
        {
            Certifications_Tab CertiEdit = new Certifications_Tab();
            CertiEdit.EditCertifications();
        }

        [Then(@"The Certification should be updated successfully")]
        public void ThenTheCertificationShouldBeUpdatedSuccessfully()
        {
            Certifications_Tab CertiVerifyEdit = new Certifications_Tab();
            Assert.AreEqual(true, CertiVerifyEdit.ValidateEditedCertifications());
        }

        [When(@"Seller delete his/her Certification")]
        public void WhenSellerDeleteHisHerCertification()
        {
            Certifications_Tab CertiDelete = new Certifications_Tab();
            CertiDelete.DeleteCertifications();
        }

        [Then(@"The Certification should be deleted successfully")]
        public void ThenTheCertificationShouldBeDeletedSuccessfully()
        {
            Certifications_Tab CertiVerifyDelete = new Certifications_Tab();
            Assert.AreEqual(true, CertiVerifyDelete.ValidateDeleteCertifications());
        }

    }
}
