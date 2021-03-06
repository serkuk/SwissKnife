﻿using System;
using ByteBee;
using NUnit.Framework;

namespace ByteBeeTests.GuardClause
{
    //[TestFixture]
    //public class TestAgainstNullOrEmpty
    //{
    //    [Test]
    //    public void When_UseNull_Then_ThrowAnException()
    //    {
    //        void ExecuteSystemUnderTest() => Guard.AgainstNullOrEmpty(null, "string was empty");
    //        Assert.Throws<ArgumentNullException>(ExecuteSystemUnderTest);
    //    }

    //    [Test]
    //    public void When_UseEmptyString_Then_ThrowAnException()
    //    {
    //        string sut = string.Empty;
    //        void ExecuteSystemUnderTest() => Guard.AgainstNullOrEmpty(sut, "string was empty");
    //        Assert.Throws<ArgumentException>(ExecuteSystemUnderTest);
    //    }

    //    [Test]
    //    public void When_UseWhitespaceString_Then_ThrowAnException()
    //    {
    //        string sut = "   ";
    //        void ExecuteSystemUnderTest() => Guard.AgainstNullOrEmpty(sut, "string was empty");
    //        Assert.Throws<ArgumentException>(ExecuteSystemUnderTest);
    //    }

    //    [Test]
    //    public void When_UseNonEmptyString_Then_ShouldPass()
    //    {
    //        string sut = "hello world";
    //        void ExecuteSystemUnderTest() => Guard.AgainstNullOrEmpty(sut, "string was empty");
    //        Assert.DoesNotThrow(ExecuteSystemUnderTest);
    //    }

    //    [Test]
    //    public void When_UseLeadingWhitespaceString_Then_ShouldPass()
    //    {
    //        string sut = "  hello world";
    //        void ExecuteSystemUnderTest() => Guard.AgainstNullOrEmpty(sut, "string was empty");
    //        Assert.DoesNotThrow(ExecuteSystemUnderTest);
    //    }

    //    [Test]
    //    public void When_UseTrailingWhitespaceString_Then_ShouldPass()
    //    {
    //        string sut = "hello world  ";
    //        void ExecuteSystemUnderTest() => Guard.AgainstNullOrEmpty(sut, "string was empty");
    //        Assert.DoesNotThrow(ExecuteSystemUnderTest);
    //    }
    //}
}