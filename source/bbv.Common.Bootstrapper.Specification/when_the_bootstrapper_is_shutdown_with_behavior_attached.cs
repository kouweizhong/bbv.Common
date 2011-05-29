//-------------------------------------------------------------------------------
// <copyright file="when_the_bootstrapper_is_shutdown_with_behavior_attached.cs" company="bbv Software Services AG">
//   Copyright (c) 2008-2011 bbv Software Services AG
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
// </copyright>
//-------------------------------------------------------------------------------

namespace bbv.Common.Bootstrapper.Specification
{
    using System.Collections.Generic;
    using System.Linq;

    using bbv.Common.Bootstrapper.Specification.Dummies;

    using FluentAssertions;

    using Machine.Specifications;

    [Subject(Concern)]
    public class when_the_bootstrapper_is_shutdown_with_behavior_attached : BootstrapperWithBehaviorSpecification
    {
        Establish context = () =>
        {
            Bootstrapper.Initialize(Strategy);
            Bootstrapper.AddExtension(First);
            Bootstrapper.AddExtension(Second);
        };

        Because of = () =>
        {
            Bootstrapper.Shutdown();
        };

        It should_only_initialize_once_for_all_extensions = () =>
        {
            Strategy.ShutdownConfigurationInitializerAccessCounter.Should().Be(1);
        };

        It should_pass_the_initialized_values_to_the_extension = () =>
        {
            var expected = new Dictionary<string, string>
                {
                    { "ShutdownTest", "ShutdownTestValue" },
                    { "ShutdownFirstValue", "ShutdownTestValue" },
                    { "ShutdownSecondValue", "ShutdownTestValue" },
                };

            First.ShutdownConfiguration.Should().BeEquivalentTo(expected);
            Second.ShutdownConfiguration.Should().BeEquivalentTo(expected);

            First.Unregistered.Should().Be("ShutdownTest");
            Second.Unregistered.Should().Be("ShutdownTest");
        };

        It should_execute_the_extensions_and_the_extension_point_according_to_the_strategy_defined_order = () =>
        {
            var sequence = CustomExtensionBase.Sequence;

            sequence.Should().HaveCount(24);
            sequence.ElementAt(0).Should().BeEquivalentTo("SecondExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.SecondExtension at shutdown first beginning.");
            sequence.ElementAt(1).Should().BeEquivalentTo("FirstExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.FirstExtension at shutdown first beginning.");
            sequence.ElementAt(2).Should().BeEquivalentTo("SecondExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.SecondExtension at shutdown second beginning.");
            sequence.ElementAt(3).Should().BeEquivalentTo("FirstExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.FirstExtension at shutdown second beginning.");

            sequence.ElementAt(4).Should().BeEquivalentTo("SecondExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.SecondExtension at input modification with ShutdownTestValueFirst.");
            sequence.ElementAt(5).Should().BeEquivalentTo("FirstExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.FirstExtension at input modification with ShutdownTestValueFirst.");
            sequence.ElementAt(6).Should().BeEquivalentTo("SecondExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.SecondExtension at input modification with ShutdownTestValueSecond.");
            sequence.ElementAt(7).Should().BeEquivalentTo("FirstExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.FirstExtension at input modification with ShutdownTestValueSecond.");
            sequence.ElementAt(8).Should().BeEquivalentTo("SecondExtension: Unregister");
            sequence.ElementAt(9).Should().BeEquivalentTo("FirstExtension: Unregister");

            sequence.ElementAt(10).Should().BeEquivalentTo("SecondExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.SecondExtension at configuration modification with ShutdownFirstValue = ShutdownTestValue.");
            sequence.ElementAt(11).Should().BeEquivalentTo("FirstExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.FirstExtension at configuration modification with ShutdownFirstValue = ShutdownTestValue.");
            sequence.ElementAt(12).Should().BeEquivalentTo("SecondExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.SecondExtension at configuration modification with ShutdownSecondValue = ShutdownTestValue.");
            sequence.ElementAt(13).Should().BeEquivalentTo("FirstExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.FirstExtension at configuration modification with ShutdownSecondValue = ShutdownTestValue.");
            sequence.ElementAt(14).Should().BeEquivalentTo("SecondExtension: DeConfigure");
            sequence.ElementAt(15).Should().BeEquivalentTo("FirstExtension: DeConfigure");

            sequence.ElementAt(16).Should().BeEquivalentTo("SecondExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.SecondExtension at shutdown first stop.");
            sequence.ElementAt(17).Should().BeEquivalentTo("FirstExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.FirstExtension at shutdown first stop.");
            sequence.ElementAt(18).Should().BeEquivalentTo("SecondExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.SecondExtension at shutdown second stop.");
            sequence.ElementAt(19).Should().BeEquivalentTo("FirstExtension: Behaving on bbv.Common.Bootstrapper.Specification.Dummies.FirstExtension at shutdown second stop.");
            sequence.ElementAt(20).Should().BeEquivalentTo("SecondExtension: Stop");
            sequence.ElementAt(21).Should().BeEquivalentTo("FirstExtension: Stop");

            sequence.ElementAt(22).Should().BeEquivalentTo("SecondExtension: Dispose");
            sequence.ElementAt(23).Should().BeEquivalentTo("FirstExtension: Dispose");
        };
    }
}