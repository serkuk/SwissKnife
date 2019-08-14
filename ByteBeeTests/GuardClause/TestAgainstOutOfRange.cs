﻿using System;
using ByteBee;
using ByteBee.Core;
using ByteBee.Core.GuardClause;
using NUnit.Framework;

namespace ByteBeeTests.GuardClause
{
    [TestFixture]
    public class TestAgainstOutOfRange
    {
        [Test]
        public void When_ValueIsInExactlyOnBounds_Then_ShouldPass()
        {
            void PerformTest() => Bee.Guard.OutOfRange(7, 7, 7, "input was out of range");
            Assert.DoesNotThrow(PerformTest);
        }

        [Test]
        public void When_ValueIsInExactlyOnUpperBounds_Then_ShouldPass()
        {
            void PerformTest() => Bee.Guard.OutOfRange(7, 0, 7, "input was out of range");
            Assert.DoesNotThrow(PerformTest);
        }

        [Test]
        public void When_ValueIsInExactlyOnLowerBounds_Then_ShouldPass()
        {
            void PerformTest() => Bee.Guard.OutOfRange(0, 0, 7, "input was out of range");
            Assert.DoesNotThrow(PerformTest);
        }
        [Test]
        public void When_ValueIsOutsideLowerBound_Then_ThrowAnException()
        {
            void PerformTest() => Bee.Guard.OutOfRange(-7, 0, 7, "input was out of range");
            Assert.Throws<ArgumentOutOfRangeException>(PerformTest);
        }

        [Test]
        public void When_ValueIsOutsideUpperBound_Then_ThrowAnException()
        {
            void PerformTest() => Bee.Guard.OutOfRange(10, 0, 7, "input was out of range");
            Assert.Throws<ArgumentOutOfRangeException>(PerformTest);
        }

        [Test]
        public void When_LowerAndUpperBoundAreSwitchedButWithinRange_Then_ShouldSwapBoundAndPass()
        {
            void PerformTest() => Bee.Guard.OutOfRange(4, 7, 0, "input was out of range");
            Assert.DoesNotThrow(PerformTest);
        }
    }
}