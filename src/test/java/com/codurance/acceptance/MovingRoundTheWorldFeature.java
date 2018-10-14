package com.codurance.acceptance;

import com.codurance.*;
import org.junit.Before;
import org.junit.Test;

import java.io.ByteArrayOutputStream;
import java.io.PrintStream;

import static org.hamcrest.MatcherAssert.assertThat;
import static org.hamcrest.core.IsEqual.equalTo;

public class MovingRoundTheWorldFeature {

    private Game game;

    private final static Location STARTING_LOCATION =
            Location.WithTitleAndDescription(
                    "starting",
                    "this is where we start");

    private final static Location NORTH_OF_START =
            Location.WithTitleAndDescription(
                    "north-of-start",
                    "you have moved to the north");

    private final static Location NORTHEAST_OF_START =
            Location.WithTitleAndDescription(
                    "northeast-of-start",
                    "you have moved to the northeast");

    private final static Location EAST_OF_START =
            Location.WithTitleAndDescription(
                    "east-of-start",
                    "you have moved to the east");

    private final static Location UP_FROM_START =
            Location.WithTitleAndDescription(
                    "up-from-start",
                    "you have moved up");
    private ByteArrayOutputStream capturedSystemOut;
    private PlayerInput input;

    @Before
    public void set_up(){
        capturedSystemOut = new ByteArrayOutputStream();
        System.setOut(new PrintStream(capturedSystemOut));
        game = new GameImpl(STARTING_LOCATION);
        input = new PlayerInput(game);
    }

    @Test
    public void should_see_information_about_locations_while_moving_round_the_map() {
        given_an_initialised_game();
        when_the_player_travels_round_the_map();
        then_user_can_see_where_he_is_at_each_step();
    }

    private void given_an_initialised_game() {

        STARTING_LOCATION.createPassageTo(NORTH_OF_START, Direction.north);
        NORTH_OF_START.createPassageTo(NORTHEAST_OF_START, Direction.east);
        NORTHEAST_OF_START.createPassageTo(EAST_OF_START, Direction.south);
        EAST_OF_START.createPassageTo(STARTING_LOCATION, Direction.west);
        STARTING_LOCATION.createPassageTo(UP_FROM_START, Direction.up);
    }

    private void when_the_player_travels_round_the_map() {
        input.submit("GO N");
        input.submit("GO E");
        input.submit("GO S");
        input.submit("GO W");
        input.submit("GO UP");
        input.submit("GO DOWN");
    }

    private void then_user_can_see_where_he_is_at_each_step() {
        String[] outputs = new String[]{
                STARTING_LOCATION.getTitle(),
                STARTING_LOCATION.getDescription(),
                NORTH_OF_START.getTitle(),
                NORTH_OF_START.getDescription(),
                NORTHEAST_OF_START.getTitle(),
                NORTHEAST_OF_START.getDescription(),
                EAST_OF_START.getTitle(),
                EAST_OF_START.getDescription(),
                STARTING_LOCATION.getTitle(),
                STARTING_LOCATION.getDescription(),
                UP_FROM_START.getTitle(),
                UP_FROM_START.getDescription(),
                STARTING_LOCATION.getTitle(),
                STARTING_LOCATION.getDescription(),
        };

        String expected = String.join("\n", outputs) + "\n";

        String output = capturedSystemOut.toString();
        assertThat(output, equalTo(expected));
    }
}
