package com.codurance;

import org.junit.Before;
import org.junit.Test;

import java.io.ByteArrayOutputStream;
import java.io.PrintStream;

import static org.hamcrest.CoreMatchers.equalTo;
import static org.hamcrest.MatcherAssert.assertThat;

public class GameImplShould {
    private static final String DEFAULT_LOCATION_NAME = "Default";
    private static final String DEFAULT_LOCATION_DESCRIPTION = "It is cold. There is ice. Is it a cave.";
    private static final Location DEFAULT_LOCATION =
            new Location(DEFAULT_LOCATION_NAME,
                         DEFAULT_LOCATION_DESCRIPTION);
    private GameImpl game;
    private ByteArrayOutputStream capturedSystemOut;

    @Before
    public void set_up(){
        game = new GameImpl(DEFAULT_LOCATION);
        capturedSystemOut = new ByteArrayOutputStream();
        System.setOut(new PrintStream(capturedSystemOut));
    }

    @Test
    public void start_in_default_location() {
        Location location = game.getCurrentLocation();
        assertThat(location, equalTo(DEFAULT_LOCATION));
    }

    @Test
    public void output_default_location_entered_text() {
        game.printLocationEnteredDialogue(DEFAULT_LOCATION);
        String expectedLocationDescription =
            DEFAULT_LOCATION_NAME + "\n" +
            DEFAULT_LOCATION_DESCRIPTION + "\n";
        String locationDescription = capturedSystemOut.toString();
        assertThat(locationDescription, equalTo(expectedLocationDescription));
    }
}