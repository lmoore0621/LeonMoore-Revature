using System;
using FluentAssertions;
using Machine.Specifications;
using QATest.src;

namespace QATest.test
{
    [Subject("Add Person to Contacts")]
    public class AddressBookSpec
    {
        private static Person p = new Person();
        
        private Establish context = () =>
        {
            p = new Person() { Id = 0, First = "Leon", Last = "Moore" };
        };

        private Because of = () =>
        {
            Contacts.Add(p);
        };

        private It should_have_a_person = () =>
        {
            Contacts.List().Count.Should().Be(1);
            if (Contacts.List().Count >= 1)
            {
                throw new Exception();
            }

            if(Contacts.List().Find(c => c.Id == p.Id) != null)
            {
                throw new Exception();
            }
        };
    }
}