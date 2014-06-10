using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace FluentAssertionsTest
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void TestAssertions()
        {
            var one = CreateActivitySummariesOne();
            var two = CreateActivitySummariesTwo();

            one.ShouldAllBeEquivalentTo(two, options =>
                options.Excluding(activity => activity.ActivityDetails.InternalId));
        }

        private IEnumerable<ActivitySummary> CreateActivitySummariesOne()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return new ActivitySummary { Id = i, ActivityDetails = new ActivityDetails {InternalId = i}};
            }
        }

        private IEnumerable<ActivitySummary> CreateActivitySummariesTwo()
        {
            for (int i = 0; i < 3; i++)
            {
                yield return new ActivitySummary { Id = i, ActivityDetails = new ActivityDetails { InternalId = i * 2 } };
            }
        }
    }
}
