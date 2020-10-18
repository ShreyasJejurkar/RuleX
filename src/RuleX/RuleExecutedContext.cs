using System;

namespace RuleX
{
    /// <summary>
    /// This contain the information about executed rule.
    /// </summary>
    /// <remarks>
    /// Get's passed to <see cref="AbstractRule.AfterExecute"/> method
    /// </remarks>
    public class RuleExecutedContext
    {
        /// <summary>
        /// Represents the given rule was skipped or not.
        /// </summary>
        public bool IsSkipped { get; }

        /// <summary>
        /// The execution result of give rule.
        /// </summary>
        public RuleResult Result { get; }

        /// <summary>
        /// Contains the <see cref="Exception"/> information in case it occurred while executing given rule. 
        /// </summary>
        public Exception RuleException { get; private set; }

        internal RuleExecutedContext(bool skipped, RuleResult result)
        {
            IsSkipped = skipped;
            Result = result;
        }

        internal void SetException(Exception e)
        {
            RuleException = e;
        }
    }
}