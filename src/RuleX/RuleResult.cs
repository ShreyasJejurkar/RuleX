using System.Collections.Generic;
using System.Linq;

namespace RuleX
{
    /// <summary>
    /// Represents the result of rule execution. 
    /// </summary>
    public class RuleResult
    {
        /// <summary>
        /// If there 0 <see cref="ErrorMessages"/> then this will be true
        /// and will considered as rule has been passed without errors. 
        /// </summary>
        public bool IsPassed => ErrorMessages.Count == 0;

        /// <summary>
        /// List containing error messages
        /// </summary>
        public List<string> ErrorMessages { get; }

        private RuleResult(IEnumerable<string> messages = null)
        {
            ErrorMessages = new List<string>();
            if (messages != null)
                ErrorMessages = messages.ToList();
        }

        internal static RuleResult Default()
        {
            return new RuleResult();
        }

        /// <summary>
        /// Represents Rule has been successfully passed.
        /// </summary>
        /// <returns></returns>
        public static RuleResult Success()
        {
            return new RuleResult();
        }

        /// <summary>
        /// Rule has been failed.
        /// </summary>
        /// <param name="messages">list of error messages</param>
        /// <returns></returns>
        public static RuleResult Fail(params string[] messages)
        {
            return new RuleResult(messages);
        }

        public static RuleResult operator +(RuleResult result1, RuleResult result2)
        {
            var finalResult = Default();
            finalResult.ErrorMessages.AddRange(result1.ErrorMessages);
            finalResult.ErrorMessages.AddRange(result2.ErrorMessages);
            return finalResult;
        }
    }
}
