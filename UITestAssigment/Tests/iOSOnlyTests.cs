﻿using System;
using NUnit.Framework;
using UITestAssigment.Pages;
using Xamarin.UITest;

namespace UITestAssigment.Tests
{
    public class iOSOnlyTests : BaseTestFixture
    {
        public iOSOnlyTests(Platform platform)
            : base(platform)
        {
        }

        [Test]
        public void AddAndDeleteTaskFromList()
        {
            if (OnAndroid)
            {
                Assert.Ignore("Feature not implemented in Android");
            }
            else
            {
                var taskName = "Finish example";

                EnterTask(taskName, "Cross-platform UITest");

                new TaskListPage()
                    .DeleteTask(taskName)
                    .VerifyTaskDoesNotExist(taskName);
            }
        }
    }
}
