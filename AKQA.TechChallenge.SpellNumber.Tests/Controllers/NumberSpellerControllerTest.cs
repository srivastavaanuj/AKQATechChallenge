using AKQA.TechChallenge.SpellNumber.Service.Controllers;
using Xunit;

namespace NumberToWordsConvertor.Tests.Controllers
{
   
    public class NumberSpellerContollerTest
    {
        [Fact]
        public void SpellNumberSucceedsWithIntegerNumber()     
        {
            var controller = new NumberSpellerController();
            string result = controller.SpellNumber("123456");
            Assert.Equal("ONE HUNDRED TWENTY THREE THOUSAND FOUR HUNDRED FIFTY SIX DOLLARS", result);
        }
        [Fact]    
        public void SpellNumberSucceedsWithDecimalNumber()
        {
            var controller = new NumberSpellerController();
            string result = controller.SpellNumber("123456.77");
            Assert.Equal("ONE HUNDRED TWENTY THREE THOUSAND FOUR HUNDRED FIFTY SIX DOLLARS AND SEVENTY SEVEN CENTS",result);
        }
        [Fact]
        public void SpellNumberSucceedsWithDecimalValue()
        {
            var controller = new NumberSpellerController();
            string result = controller.SpellNumber(".77");
            Assert.Equal("ZERO DOLLARS AND SEVENTY SEVEN CENTS", result);
        }

        [Fact]
        public void SpellNumberFailsWithIncorrectIntegerNumber()
        {
            var controller = new NumberSpellerController();
            string result = controller.SpellNumber("123457");
            Assert.NotEqual("ONE HUNDRED TWENTY THREE THOUSAND FOUR HUNDRED FIFTY SIX DOLLARS", result);
        }

    }
}
