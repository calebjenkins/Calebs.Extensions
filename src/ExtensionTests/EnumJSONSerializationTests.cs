using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace ExtensionTests
{
	public class EnumJSONSerializationTests
	{
		[Fact] // Passes Will FALSE (Fails)
		public void SerializingWithStraightEnums()
	{
			// var converter = new Jason
			var StartMsg = new MessageWithOptionsEnum() { Options = Options.Large };
		
			var msgJson = StartMsg.ToJson();
			var EndMsg = msgJson.FromJson<MessageWithOptions2Enum>();

            var startToString = StartMsg.Options.ToString();
			var endToString = EndMsg.Options.ToString();

			startToString.Should().Be(endToString);

			StartMsg.Options.ToString().Should().Be(EndMsg.Options.ToString());
		}

        [Fact] // It's a lot of work to get the object to serialize the enum as a string. 
        public void SerializingWithEnumsBacking()
		{
			var StartMsg = new MessageWithEnumBacking () { Options = Options.Large };

            var msgJson = StartMsg.ToJson();
            var EndMsg = msgJson.FromJson<MessageWithOptions2Enum>();

            StartMsg.Options.ToString().Should().Be(EndMsg.Options.ToString());
		}

        [Fact] // This is much better. Using a Newtonsoft attribute on the enum, forces the ToString on the enum instead of the index
        public void SerializingWithStraightEnumsUsingJasonAttributes()
		{
			var StartMsg = new MessageWithOptions1EnumWithAttribute () { Options = Options.Large };

			var msgJson = StartMsg.ToJson();
            var EndMsg = msgJson.FromJson<MessageWithStringOptions>();

            StartMsg.Options.ToString().Should().Be(EndMsg.Options.ToString());
		}

		[Fact]
		public void SerializingWithEnumMemberAttribute_DoesntWork_Enum_Serializes_Index_Instead_of_String()
		{
			var StartMsg = new MessageWithEnumMemberOptions() { Options = OptionWithEnumMember.Largish };
			
			var msgJson = StartMsg.ToJson();
			var EndMsg = msgJson.FromJson<MessageWithStringOptions>();

			StartMsg.Options.ToString().Should().Be("Largish");
			// Maps to ..
			EndMsg.Options.Should().Be("Large");
		}
	}
}
