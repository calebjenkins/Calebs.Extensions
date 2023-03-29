using Xunit;
using Newtonsoft;
using Newtonsoft.Json;
using System.Diagnostics;
using Calebs.Extensions;

namespace EnumTests
{
	public class EnumJSONSerializationTests
	{
		[Fact] // Passes Will FALSE (Fails)
		public void SerializingWithStraightEnums()
	{
			//var converter = new Jason
			var StartMsg = new MessageWithOptionsEnum() { Options = Options.Large };
			var msgJson = JsonConvert.SerializeObject(StartMsg);

			var EndMsg = JsonConvert.DeserializeObject<MessageWithOptions2Enum>(msgJson);

			StartMsg.Options.ToString().Should().Be(EndMsg.Options.ToString());
		}

        [Fact] // It's a lot of work to get the object to serialize the enum as a string. 
        public void SerializingWithEnumsBacking()
		{
			var StartMsg = new MessageWithEnumBacking () { Options = Options.Large };
			var msgJson = JsonConvert.SerializeObject(StartMsg);

			var EndMsg = JsonConvert.DeserializeObject<MessageWithOptions2Enum>(msgJson);

			StartMsg.Options.ToString().Should().Be(EndMsg.Options.ToString());
		}

        [Fact] // This is much better. Using a Newtonsoft attribute on the enum, forces the ToString on the enum instead of the index
        public void SerializingWithStraightEnumsUsingJasonAttributes()
		{
			var StartMsg = new MessageWithOptions1EnumWithAttribute () { Options = Options.Large };
			var msgJson = JsonConvert.SerializeObject(StartMsg);

			var EndMsg = JsonConvert.DeserializeObject<MessageWithStringOptions>(msgJson);

            StartMsg.Options.ToString().Should().Be(EndMsg.Options.ToString());
		}

		[Fact]
		public void SerializingWithEnumMemberAttribute_DoesntWork_Enum_Serializes_Index_Instead_of_String()
		{
			var StartMsg = new MessageWithEnumMemberOptions() { Options = OptionWithEnumMember.Largish };
			var msgJson = JsonConvert.SerializeObject(StartMsg);

			var EndMsg = JsonConvert.DeserializeObject<MessageWithStringOptions>(msgJson);

            StartMsg.Options.ToString().Should().NotBe(EndMsg.Options.ToString());
			EndMsg.Options.ToString().Should().Be("0");
		}
	}
}
