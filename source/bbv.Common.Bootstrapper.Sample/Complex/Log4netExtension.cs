//-------------------------------------------------------------------------------
// <copyright file="Log4NetExtension.cs" company="bbv Software Services AG">
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

namespace bbv.Common.Bootstrapper.Sample.Complex
{
    using System;

    using log4net.Appender;
    using log4net.Config;
    using log4net.Layout;

    /// <summary>
    /// Extension which configures log4net.
    /// </summary>
    public class Log4NetExtension : ComplexExtensionBase
    {
        /// <inheritdoc />
        public override void Start()
        {
            base.Start();

            Console.WriteLine("Log4NetExtension is starting.");

            var appender = new ConsoleAppender { Layout = new PatternLayout { ConversionPattern = "%logger - %message%newline" } };

            BasicConfigurator.Configure(appender);
        }

        public override string Describe()
        {
            return "Extension which configures log4net.";
        }
    }
}