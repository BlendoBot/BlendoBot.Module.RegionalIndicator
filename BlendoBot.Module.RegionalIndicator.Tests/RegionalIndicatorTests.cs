using Xunit;

namespace BlendoBot.Module.RegionalIndicator.Tests {
	public class RegionalIndicatorTests {
		[Theory]
		[InlineData("lower", ":regional_indicator_l: :regional_indicator_o: :regional_indicator_w: :regional_indicator_e: :regional_indicator_r:")]
		[InlineData("UPPER", ":regional_indicator_u: :regional_indicator_p: :regional_indicator_p: :regional_indicator_e: :regional_indicator_r:")]
		[InlineData("MiXeD", ":regional_indicator_m: :regional_indicator_i: :regional_indicator_x: :regional_indicator_e: :regional_indicator_d:")]
		[InlineData("Has space", ":regional_indicator_h: :regional_indicator_a: :regional_indicator_s: :black_large_square: :regional_indicator_s: :regional_indicator_p: :regional_indicator_a: :regional_indicator_c: :regional_indicator_e:")]
		[InlineData("1 number", ":one: :black_large_square: :regional_indicator_n: :regional_indicator_u: :regional_indicator_m: :regional_indicator_b: :regional_indicator_e: :regional_indicator_r:")]
		[InlineData("yay <:peepoggers:123456789>", ":regional_indicator_y: :regional_indicator_a: :regional_indicator_y: <:peepoggers:123456789>")]
		[InlineData("<@123456789> is 🆒 in <#987654321>", "{<@123456789>:black_large_square: :regional_indicator_i: :regional_indicator_s: :black_large_square: 🆒:black_large_square: :regional_indicator_i: :regional_indicator_n: :black_large_square: <#987654321>}")]
		public void CharacterMappingsTests(string inputString, string expectedOutput) {
			string actualOutput = RegionalIndicator.ConvertString(inputString);
			Assert.Equal(expectedOutput, actualOutput);
		}
	}
}