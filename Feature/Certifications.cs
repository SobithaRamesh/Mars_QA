using MarsQA_1.Helpers;
using MarsQA_1.SpecflowPages.Pages;
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
        [Given(@"Seller logged into his/her profile page")]
        public void GivenSellerLoggedIntoHisHerProfilePage()
        {
            Certifications_Tab.GoToCertificationsTab();
        }

        [When(@"Seller adds his/her Certification")]
        public void WhenSellerAddsHisHerCertification()
        {
            Certifications_Tab.AddCertifications();
        }

        [Then(@"The Certification should be added successfully")]
        public void ThenTheCertificationShouldBeAddedSuccessfully()
        {
            Certifications_Tab.ValidateAddedCertifications();
        }

        [When(@"Seller edits his/her Certification")]
        public void WhenSellerEditsHisHerCertification()
        {
            Certifications_Tab.EditCertifications();
        }

        [Then(@"The Certification should be updated successfully")]
        public void ThenTheCertificationShouldBeUpdatedSuccessfully()
        {
            Certifications_Tab.ValidateEditedCertifications();
        }

        [When(@"Seller delete his/her Certification")]
        public void WhenSellerDeleteHisHerCertification()
        {
            Certifications_Tab.DeleteCertifications();
        }

        [Then(@"The Certification should be deleted successfully")]
        public void ThenTheCertificationShouldBeDeletedSuccessfully()
        {
            Certifications_Tab.ValidateDeleteCertifications();
        }

    }
}
