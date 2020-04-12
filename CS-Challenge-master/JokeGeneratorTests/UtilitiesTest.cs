using JokeGenerator;
using NUnit.Framework;

namespace JokeGeneratorTests
{
    public class Tests
    {
        private Utilities _utilities;
        [SetUp]
        public void Setup()
        {
            _utilities = new Utilities();
        }

        [Test]
        public void TestReplacingNameInJoke_UpperCaseName_ShouldBeEqual()
        {
            var joke = _utilities.ReplaceNameInJoke("Mohamed", "Omar", "Believe it or not, CHUCK NORRIS IS RIGHT BEHIND YOU!");
            Assert.AreEqual("Believe it or not, Mohamed Omar IS RIGHT BEHIND YOU!", joke);
        }

        [Test]
        public void TestReplacingNameInJoke_NoSpaceBetweenReplacedNameAndNextWord_ShouldBeEqual()
        {
            var joke = _utilities.ReplaceNameInJoke("Mohamed", "Omar", "No statement can catch the ChuckNorrisException.");
            Assert.AreEqual("No statement can catch the Mohamed Omar Exception.", joke);
        }

        [Test]
        public void TestReplacingNameInJoke_NameToBeReplacedIsRepeated_ShouldBeEqual()
        {
            var joke = _utilities.ReplaceNameInJoke("Mohamed", "Omar", "Believe it or not, CHUCK NORRIS IS RIGHT BEHIND YOU! CHUCK NORRIS");
            Assert.AreEqual("Believe it or not, Mohamed Omar IS RIGHT BEHIND YOU! Mohamed Omar", joke);
        }

        [Test]
        public void TestReplacingNameInJoke_NameToBeReplacedIsAtTheBegining_ShouldBeEqual()
        {
            var joke = _utilities.ReplaceNameInJoke("Mohamed", "Omar", "CHUCK NORRIS Believe it or not, CHUCK NORRIS IS RIGHT BEHIND YOU!");
            Assert.AreEqual("Mohamed Omar Believe it or not, Mohamed Omar IS RIGHT BEHIND YOU!", joke);
        }

        [Test]
        public void TestReplacingNameInJoke_NameToBeReplacedIsAtTheEnd_ShouldBeEqual()
        {
            var joke = _utilities.ReplaceNameInJoke("Mohamed", "Omar", "Believe it or not, CHUCK NORRIS IS RIGHT BEHIND YOU! CHUCK NORRIS");
            Assert.AreEqual("Believe it or not, Mohamed Omar IS RIGHT BEHIND YOU! Mohamed Omar", joke);
        }

        [Test]
        public void TestReplacingNameInJoke_NameToBeReplacedIsMissing_ShouldBeEqual()
        {
            var joke = _utilities.ReplaceNameInJoke("Mohamed", "Omar", "Believe it or not, IS RIGHT BEHIND YOU!");
            Assert.AreEqual("Believe it or not, IS RIGHT BEHIND YOU!", joke);
        }

        [Test]
        public void TestReplacingNameInJoke_FirstNameHasSpace_ShouldBeEqual()
        {
            var joke = _utilities.ReplaceNameInJoke("Mohamed Mohamed", "Omar", "Believe it or not, CHUCK NORRIS IS RIGHT BEHIND YOU!");
            Assert.AreEqual("Believe it or not, Mohamed Mohamed Omar IS RIGHT BEHIND YOU!", joke);
        }

        [Test]
        public void TestReplacingNameInJoke_LastNameHasSpace_ShouldBeEqual()
        {
            var joke = _utilities.ReplaceNameInJoke("Mohamed", "Omar Omar", "Believe it or not, CHUCK NORRIS IS RIGHT BEHIND YOU!");
            Assert.AreEqual("Believe it or not, Mohamed Omar Omar IS RIGHT BEHIND YOU!", joke);
        }
        [Test]
        public void TestReplacingNameInJoke_FirstAndLastNameAreNull_ShouldBeEqual()
        {
            var joke = _utilities.ReplaceNameInJoke(null, null, "Believe it or not, CHUCK NORRIS IS RIGHT BEHIND YOU!");
            Assert.AreEqual("Believe it or not, CHUCK NORRIS IS RIGHT BEHIND YOU!", joke);
        }

        [Test]
        public void TestReplacingNameInJoke_FirstAndLastNameAreEmpty_ShouldBeEqual()
        {
            var joke = _utilities.ReplaceNameInJoke("", "", "Believe it or not, CHUCK NORRIS IS RIGHT BEHIND YOU!");
            Assert.AreEqual("Believe it or not,   IS RIGHT BEHIND YOU!", joke);
        }
    }
}