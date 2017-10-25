package com.codurance;

import junitparams.JUnitParamsRunner;
import junitparams.Parameters;
import org.junit.Test;
import org.junit.runner.RunWith;

import static com.codurance.Direction.*;
import static org.hamcrest.CoreMatchers.equalTo;
import static org.hamcrest.MatcherAssert.assertThat;

@RunWith(JUnitParamsRunner.class)
public class LocationShould {
    private static final Location INITIAL_LOCATION =
        Location.WithTitleAndDescription(
            "initial",
            "the initial location");

    private static final Location OTHER_LOCATION =
        Location.WithTitleAndDescription(
                "other",
                "the other location");

    @Test
    @Parameters({
        "north",
        "south",
        "east",
        "west",
        "up",
        "down"
    }) public void
    always_set_up_a_return_passage_in_the_complementary_direction(Direction passageDirection) {
        INITIAL_LOCATION.createPassageTo(OTHER_LOCATION, passageDirection);
        Location finalLocation = OTHER_LOCATION.moveTo(passageDirection.complement());
        assertThat(finalLocation, equalTo(INITIAL_LOCATION));
    }
}
