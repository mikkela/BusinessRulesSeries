﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business;
using Xunit;
using Xunit.Extensions;

namespace BusinessTest
{
    public class OldBusinessRuleTest : TestBase
    {
        [Theory]
        [PropertyData("UnderAge")]
        public void Evaluates_to_false_for_under_aged_people(int age)
        {
            Assert.False(new OldBusinessRule(age).Evaluate());
        }

        [Theory]
        [PropertyData("Young")]
        public void Evaluates_to_false_for_young_people(int age)
        {
            Assert.False(new OldBusinessRule(age).Evaluate());
        }

        [Theory]
        [PropertyData("MiddleAged")]
        public void Evaluates_to_false_for_middle_aged_people(int age)
        {
            Assert.False(new OldBusinessRule(age).Evaluate());
        }

        [Theory]
        [PropertyData("Old")]
        public void Evaluates_to_true_for_old_people(int age)
        {
            Assert.True(new OldBusinessRule(age).Evaluate());
        }
    }
}