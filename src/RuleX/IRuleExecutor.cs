using System.Collections.Generic;

namespace RuleX
{
    /// <summary>
    /// Rule executor contract
    /// </summary>
    public interface IRuleExecutor
    {
        RuleResult ExecuteRulesList(List<AbstractRule> rulesToExecute);
        RuleResult ExecuteRule(AbstractRule rule);
    }
}