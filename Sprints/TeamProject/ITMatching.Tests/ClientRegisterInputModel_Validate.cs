using NUnit.Framework;
using ITMatching.Models.InputModels;
using System;

namespace ITMatching.Tests
{
    [TestFixture]
    public class ClientRegisterInputModel_Validate
    {
        private const string STRING_WITH_MORETHAN_100_CHARS = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAABB";
        private const string STRING_WITH_EXACT_100_CHARS = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAA";
        public static ClientRegisterInputModel GenerateValidClientRegisterInputModel()
        {
            return new ClientRegisterInputModel
            {
                FirstName = "Cristina",
                LastName = "Clark",
                Email = "cristinaclark@limage.com",
                PhoneNumber = "8434263655",
                Password = "$tr@wb3rRy",
                ConfirmPassword = "$tr@wb3rRy"
            };
        }

        [SetUp]
        public void Setup()
        {
             
        }


        // ************* Check All Properties ************* //


        [Test]
        public void ClientRegisterInputModel_CheckAllPropertiesWithDefaultValuesAndModelIs_Invalid()
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = new ClientRegisterInputModel();

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.Valid, Is.False);
        }

        [Test]
        public void ClientRegisterInputModel_CheckAllPropertiesWithValidValuesAndModelIs_Valid()
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.Valid, Is.True);
        }


        // ************* Check Property > FirstName ************* //


        [Test]
        public void ClientRegisterInputModel_FirstNameIsNullAndIs_Invalid()
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.FirstName = null;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("FirstName"), Is.True);

            Assert.That(modelValidator.Valid, Is.False);
        }

        [Test]
        public void ClientRegisterInputModel_FirstNameIsEmptyAndIs_Invalid()
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.FirstName = "";

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("FirstName"), Is.True);

            Assert.That(modelValidator.Valid, Is.False);
        }

        [TestCase("J@me")]
        [TestCase("J me")]
        [TestCase("Jame1")]
        [TestCase("2George")]
        [TestCase("D@ni3L")]
        public void ClientRegisterInputModel_FirstNameContainsSymbolsOrNumbersAndIs_Invalid(string invalidFirstName)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.FirstName = invalidFirstName;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("FirstName"), Is.True);

            Assert.That(modelValidator.Valid, Is.False);
        }

        [TestCase("Daniel")]
        [TestCase("Jim")]
        [TestCase("John")]
        [TestCase("George")]
        public void ClientRegisterInputModel_FirstNameIsNotNullOrEmptyAndIs_Valid(string validFirstName)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.FirstName = validFirstName;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("FirstName"), Is.False);

            Assert.That(modelValidator.Valid, Is.True);
        }

        [TestCase("A")]
        [TestCase("j")]
        [TestCase(STRING_WITH_MORETHAN_100_CHARS)]
        [TestCase("@")]
        [TestCase("1")]
        public void ClientRegisterInputModel_FirstNameNotHavingAtlease2AndAtMax100CharsAndIs_Invalid(string invalidFirstName)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.FirstName = invalidFirstName;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("FirstName"), Is.True);

            Assert.That(modelValidator.Valid, Is.False);
        }

        [TestCase("AB")]
        [TestCase("ab")]
        [TestCase(STRING_WITH_EXACT_100_CHARS)]
        public void ClientRegisterInputModel_FirstNameHavingAtlease2AndAtMax100CharsAndIs_Valid(string validFirstName)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.FirstName = validFirstName;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("FirstName"), Is.False);

            Assert.That(modelValidator.Valid, Is.True);
        }


        // ************* Check Property > LastName ************* //


        [Test]
        public void ClientRegisterInputModel_LastNameIsNullAndIs_Invalid()
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.LastName = null;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("LastName"), Is.True);

            Assert.That(modelValidator.Valid, Is.False);
        }

        [Test]
        public void ClientRegisterInputModel_LastNameIsEmptyAndIs_Invalid()
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.LastName = "";

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("LastName"), Is.True);

            Assert.That(modelValidator.Valid, Is.False);
        }

        [TestCase("$tone")]
        [TestCase("St one")]
        [TestCase("Arnold5")]
        [TestCase("20Maxwell")]
        [TestCase("M@xw3ll")]
        public void ClientRegisterInputModel_LastNameContainsSymbolsOrNumbersAndIs_Invalid(string invalidLastName)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.LastName = invalidLastName;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("LastName"), Is.True);

            Assert.That(modelValidator.Valid, Is.False);
        }

        [TestCase("Moran")]
        [TestCase("Arnold")]
        [TestCase("Maxwell")]
        [TestCase("Jacobson")]
        public void ClientRegisterInputModel_LastNameIsNotNullOrEmptyAndIs_Valid(string validLastName)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.LastName = validLastName;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("LastName"), Is.False);

            Assert.That(modelValidator.Valid, Is.True);
        }

        [TestCase("A")]
        [TestCase("j")]
        [TestCase(STRING_WITH_MORETHAN_100_CHARS)]
        [TestCase("@")]
        [TestCase("1")]
        public void ClientRegisterInputModel_LastNameNotHavingAtlease2AndAtMax100CharsAndIs_Invalid(string invalidLastName)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.LastName = invalidLastName;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("LastName"), Is.True);

            Assert.That(modelValidator.Valid, Is.False);
        }

        [TestCase("AB")]
        [TestCase("ab")]
        [TestCase(STRING_WITH_EXACT_100_CHARS)]
        public void ClientRegisterInputModel_LastNameHavingAtlease2AndAtMax100CharsAndIs_Valid(string validLastName)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.LastName = validLastName;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("LastName"), Is.False);

            Assert.That(modelValidator.Valid, Is.True);
        }


        // ************* Check Property > Email ************* //


        [TestCase(null)]
        [TestCase("")]
        public void ClientRegisterInputModel_EmailIsNullOrEmptyAndIs_Invalid(string invalidEmail)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.Email = invalidEmail;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("Email"), Is.True);

            Assert.That(modelValidator.Valid, Is.False);
        }

        [TestCase("Jmec")]
        [TestCase("J me")]
        [TestCase("J me$im.com")]
        [TestCase("2George imdotcom")]
        [TestCase("D@ni3L@im.com")]
        [TestCase("Daniel.com")]
        public void ClientRegisterInputModel_EmailIs_Invalid(string invalidEmail)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.Email = invalidEmail;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("Email"), Is.True);

            Assert.That(modelValidator.Valid, Is.False);
        }

        [TestCase("Jame@im")]
        [TestCase("jame@im.com")]
        [TestCase("jame@im.co.us")]
        [TestCase("Jame@im.co.us")]
        [TestCase("D anieL@im.com")]
        [TestCase("D#ni3L@im.com")]
        [TestCase("daniel12@im.com")]
        public void ClientRegisterInputModel_EmailIs_Valid(string validEmail)
        {
            //Arrange
            ClientRegisterInputModel clientRegisterInputModel = GenerateValidClientRegisterInputModel();
            clientRegisterInputModel.Email = validEmail;

            //Act
            ModelValidator modelValidator = new ModelValidator(clientRegisterInputModel);

            //Assert
            Assert.That(modelValidator.ContainsFailureFor("Email"), Is.False);

            Assert.That(modelValidator.Valid, Is.True);
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