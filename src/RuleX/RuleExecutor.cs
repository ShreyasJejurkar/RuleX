using System.Collections.Generic;

namespace RuleX
{
    public class RuleExecutor : IRuleExecutor
    {
        /// <summary>
        /// Executes the given list of <see cref="AbstractRule"/>
        /// </summary>
        /// <param name="rulesToExecute"></param>
        /// <returns></returns>
        public RuleResult ExecuteRulesList(List<AbstractRule> rulesToExecute)
        {
            var consolidatedRuleResult = RuleResult.Default();

            foreach (var rule in rulesToExecute)
            {
                var result = rule.Process();
                if(!result.IsPassed)
                    consolidatedRuleResult.ErrorMessages.AddRange(result.ErrorMessages);
            }

            return consolidatedRuleResult;
        }

        /// <summary>
        /// Will execute the given <see cref="rule"/>
        /// </summary>
        /// <param name="rule">The rule</param>
        /// <returns><see cref="RuleResult"/> of given <see cref="rule"/>  </returns>
        public RuleResult ExecuteRule(AbstractRule rule)
        {
            return rule.Process();
        }
    }
}