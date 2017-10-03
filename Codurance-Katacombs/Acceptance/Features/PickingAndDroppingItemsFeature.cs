using NUnit.Framework;

namespace Codurance_Katacombs.Acceptance
{
    public partial class PickingAndDroppingItemsFeature
    {
        [Test]
        public void Empty_bag_display_message_when_checked()
        {
            Given_I_have_an_empty_bag();
            When_I_check_the_content_of_the_bag();
            Then_message_should_have_been_shown();
        }
    }
}
