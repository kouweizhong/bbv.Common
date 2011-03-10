//-------------------------------------------------------------------------------
// <copyright file="Concern.cs" company="bbv Software Services AG">
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

namespace bbv.Common.StateMachine.Specification
{
    using System;

    public static class Concern
    {
        public const string Initialization = "Initialize state machine";

        public const string StartStop = "Start and stop state machine";

        public const string Transition = "Execute transition";

        public const string EntryAndExitActions = "Entry and exit actions";

        public const string ExceptionHandling = "Exception Handling";
    }
}