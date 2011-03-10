//-------------------------------------------------------------------------------
// <copyright file="NoParameterExpression{TExpressionResult}.cs" company="bbv Software Services AG">
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

namespace bbv.Common.EvaluationEngine
{
    using System.Reflection;

    /// <summary>
    /// Base class for expressions that do not have a parameter.
    /// </summary>
    /// <typeparam name="TExpressionResult">The type of the expression result.</typeparam>
    public abstract class NoParameterExpression<TExpressionResult> : IExpression<TExpressionResult, Missing>
    {
        /// <summary>
        /// Evaluates the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        /// <returns>The expression result.</returns>
        public TExpressionResult Evaluate(Missing parameter)
        {
            return this.Evaluate();
        }

        /// <summary>
        /// Describes this instance.
        /// </summary>
        /// <returns>The description of this instance.</returns>
        public abstract string Describe();

        /// <summary>
        /// Evaluates this instance.
        /// </summary>
        /// <returns>The expression result.</returns>
        protected abstract TExpressionResult Evaluate();
    }
}