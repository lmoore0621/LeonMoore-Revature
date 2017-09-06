using WEEK1QUIZ.src;
using Xunit;

namespace WEEK1QUIZ.test
{
    public class PalindromeTest
    {
        [Fact]
        public void PalindromeTrue()
        {
            var p = new Palindrome() {Name = "racecar "};
            var actual = Palindrome.Check(p);

            Assert.True(actual);
        }

        [Fact]
        public void PalindromeTrueCase()
        {
            var p = new Palindrome() {Name = "CiviC"};
            var actual = Palindrome.Check(p);

            Assert.True(actual);
        }

        [Fact]
        public void PalindromeTrueSentence()
        {
            var p = new Palindrome() {Name = "Never Odd or Even"};
            var actual = Palindrome.Check(p);

            Assert.True(actual);
        }

        [Fact]
        public void PalindromeTrueNumbers()
        {
            var p = new Palindrome() {Name = "1234554321"};
            var actual = Palindrome.Check(p);

            Assert.True(actual);
        }

        [Fact]
        public void PalindromeTruePunctuation()
        {
            var p = new Palindrome() {Name = "RaceCar!racecar"};
            var actual = Palindrome.Check(p);

            Assert.True(actual);
        }

        [Fact]
        public void PalindromeTrueFalse1()
        {
            var p = new Palindrome() {Name = "fkjfhk"};
            var actual = Palindrome.Check(p);

            Assert.True(actual);
        }
    }
}
