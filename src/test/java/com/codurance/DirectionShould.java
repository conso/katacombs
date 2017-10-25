package com.codurance;

import junitparams.JUnitParamsRunner;
import junitparams.Parameters;
import org.junit.Test;
import org.junit.runner.RunWith;

import static com.codurance.Direction.*;
import static org.hamcrest.CoreMatchers.equalTo;
import static org.hamcrest.MatcherAssert.assertThat;

@RunWith(JUnitParamsRunner.class)
public class DirectionShould {
    @Test
    @Parameters({
            "south, north",
            "north, south",
            "east, west",
            "west, east",
            "up, down",
            "down, up",
    }) public void
    complement_with_the_opposite_direction(Direction source, Direction expected) {
        assertThat(source.complement(), equalTo(expected));
    }
}
