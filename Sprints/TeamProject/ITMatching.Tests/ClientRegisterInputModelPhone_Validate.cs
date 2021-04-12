using NUnit.Framework;
using ITMatching.Models.InputModels;
using System;

namespace ITMatching.Tests
{
    [TestFixture]
    public class ClientRegisterInputModelPhone_Validate
    {
        private const string STRING_WITH_MORETHAN_100_CHARS = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABB";
        private const string STRING_WITH_EXACT_100_CHARS = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        public static ClientRegisterInputModel GenerateValidClientRegisterInputModel()
        {
            return new ClientRegisterInputModel
            {
                FirstName = "Tony",
                LastName = "Hawk",
                Email = "thawk@skate.com",
                PhoneNumber = "3432345623",
                Password = "$k8rb0y",
                ConfirmPassword = "$k8rb0y"
            };
        }

        [SetUp]
        public void Setup()
        {
             
        }

        // ************* Check Property > Phone ************* //


        [TestCase(null)]
        [TestCase("")]
        public void ClientRegisterInputModel_PhoneNumberIsNullOrEmptyAndIs_Invalid(string invalidPhoneNumber)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.PhoneNumber = invalidPhoneNumber;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("PhoneNumber"), Is.True);

            Assert.That(modelValidator.Valid, Is.False);
        }

        [TestCase("Apple")]
        [TestCase("44A")]
        [TestCase("111111111I")]
        public void ClientRegisterInputModel_PhoneNumberHasLettersAndIs_Invalid(string invalidPhoneNumber)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.PhoneNumber = invalidPhoneNumber;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("PhoneNumber"), Is.True);

            Assert.That(modelValidator.Valid, Is.False);
        }

        [TestCase("11223344556677889900")]
        [TestCase("11111111111111111111111111")]
        public void ClientRegisterInputModel_PhoneNumberIsMoreThan20CharactersLongAndIs_InValid(string invalidPhoneNumber)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.PhoneNumber = invalidPhoneNumber;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("PhoneNumber"), Is.True);

            Assert.That(modelValidator.Valid, Is.False);
        }

        [TestCase("11")]
        [TestCase("123456789")]
        public void ClientRegisterInputModel_PhoneNumberIsLessThan10CharactersLongAndIs_InValid(string invalidPhoneNumber)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.PhoneNumber = invalidPhoneNumber;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("PhoneNumber"), Is.True);

            Assert.That(modelValidator.Valid, Is.False);
        }

        [TestCase("503503503%")]
        [TestCase("@")]
        [TestCase("#4444444444")]
        [TestCase("@$#@#$^^$#")]
        public void ClientRegisterInputModel_PhoneNumberContainsSymbolsAndIs_InValid(string invalidPhoneNumber)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.PhoneNumber = invalidPhoneNumber;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("PhoneNumber"), Is.True);

            Assert.That(modelValidator.Valid, Is.False);
        }

        [TestCase("1234567809")]
        [TestCase("5555555555")]
        [TestCase("8005882300")]
        [TestCase("1112223333")]
        public void ClientRegisterInputModel_PhoneNumberIs_Valid(string validPhoneNumber)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.PhoneNumber = validPhoneNumber;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("PhoneNumber"), Is.False);

            Assert.That(modelValidator.Valid, Is.True);
        }

    }
}