using System;
using QATest.src;
using Xunit;
using static QATest.src.Person;

namespace QATest.test
{
    public class AddressBook
    {
        [Fact]
        public void AddTest()
        {
            var p = new Person();
            // arrange
            var expected = true;

            // act
            var actual = Contacts.Add(p);

            // assert
            Assert.True(actual);
        }

        [Fact]
        public void UpdateTest()
        {
            Person p = new Person() { Id = 1, First = "Leon", Last = "Moore"};

            Person actual = Contacts.Update(p);

            Assert.Equal(actual.Id, p.Id);
            Assert.Equal(actual.First, p.First);
            Assert.Equal(actual.Last, p.Last);
        }

        [Fact]
        public void DeleteTest()
        {

        }

        [Fact]
        public void ListTest()
        {

        }

        public void CheckLocale()
        {
            var p = new Person();

            p.DisplayName(EFullName);
        }

        private string USFName(string a, string z)
        {
            return a + z;
        }

        Func<string, string, string> USFullName = (string f, string l) => {return f + " " + l;};
        NameFormat EFullName = (string f, string l) => {return l + " " + f;};
    
        Action<string, string> FullName = (string q, string w) => {};
    }
}