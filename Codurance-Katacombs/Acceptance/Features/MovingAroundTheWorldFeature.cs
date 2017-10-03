using NUnit.Framework;

namespace Codurance_Katacombs.Acceptance
{
    public partial class MovingAroundTheWorldFeature
    {
        [Test]
        public void Changing_location_always_trigger_next_location_message()
        {
            Given_I_startup_the_game_with_3_locations();
            When_I_move_to_all_locations_and_back();
            Then_all_location_messages_should_have_shown_in_correct_order();
        }
    }
}
