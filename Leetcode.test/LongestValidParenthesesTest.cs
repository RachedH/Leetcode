using Xunit;

namespace Leetcode.test
{
    public class LongestValidParenthesesTest
    {
        [Fact]
        public void TestParentheses()
        {
            Assert.Equal(2, LongestValidParentheses.Execute("(()"));
            Assert.Equal(0, LongestValidParentheses.Execute("(("));
            Assert.Equal(4, LongestValidParentheses.Execute(")()())"));
            Assert.Equal(2, LongestValidParentheses.Execute("()(()"));
            Assert.Equal(2, LongestValidParentheses.Execute("(()(((()"));
            Assert.Equal(2, LongestValidParentheses.Execute("))))((()(("));
            Assert.Equal(4, LongestValidParentheses.Execute("()()"));
            Assert.Equal(6, LongestValidParentheses.Execute("()(())"));
            Assert.Equal(6, LongestValidParentheses.Execute("(()())"));
            Assert.Equal(6, LongestValidParentheses.Execute(")(())))(())())"));
            Assert.Equal(6, LongestValidParentheses.Execute("()(())"));
            Assert.Equal(10, LongestValidParentheses.Execute(")(())(()()))("));
        }
    }
}