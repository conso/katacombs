package com.codurance.acceptance;

import com.codurance.Direction;
import com.codurance.Game;
import com.codurance.GameImpl;
import com.codurance.Location;
import org.junit.Before;
import org.junit.Test;

import java.io.ByteArrayOutputStream;
import java.io.PrintStream;

import static org.hamcrest.CoreMatchers.containsString;
import static org.hamcrest.CoreMatchers.equalTo;
import static org.hamcrest.MatcherAssert.assertThat;

public class UserMoves {
    private Game game;
    private Location startingLocation = new Location(
            "Starting Location",
            "This is the starting location");
    private Location iceCave = new Location(
            "Ice Cave",
            "It is cold. There is ice. Is it a cave.");
    private ByteArrayOutputStream capturedSystemOut;

    @Before
    public void set_up(){
        capturedSystemOut = new ByteArrayOutputStream();
        System.setOut(new PrintStream(capturedSystemOut));
    }

    @Test
    public void to_an_existing_location() {
        given_the_player_is_in_the_starting_location();
        and_there_is_an_ice_cave_to_the_north();
        when_the_player_moves_north();
        then_the_title_and_description_of_the_ice_cave_should_be_output();
    }

    @Test
    public void to_a_non_existent_location() {
        given_the_player_is_in_the_starting_location();
        when_the_player_moves_north();
        then_the_title_and_description_of_the_starting_location_should_be_output();
        and_the_player_should_be_told_that_there_is_nowhere_to_go();
    }

    @Test
    public void and_then_moves_back_again(){
        given_the_player_is_in_the_starting_location();
        and_there_is_an_ice_cave_to_the_north();
        when_the_player_moves_north();
        and_the_player_moves_south();
        then_the_title_and_description_of_the_starting_location_should_be_output();
    }

    @Test
    public void north_twice(){
        given_the_player_is_in_the_starting_location();
        and_there_is_an_ice_cave_to_the_north();
        when_the_player_moves_north();
        when_the_player_moves_north();
        then_the_title_and_description_of_the_ice_cave_should_be_output();
        and_the_player_should_be_told_that_there_is_nowhere_to_go();
    }


    private void given_the_player_is_in_the_starting_location() {
        game = new GameImpl(startingLocation);
    }

    private void and_there_is_an_ice_cave_to_the_north() {
        startingLocation.createPassageTo(iceCave, Direction.north);
    }

    private void when_the_player_moves_north() {
        game.go(Direction.north);
    }

    private void and_the_player_moves_north() {
        when_the_player_moves_north();
    }

    private void and_the_player_moves_south() {
        game.go(Direction.south);
    }

    private void then_the_title_and_description_of_the_ice_cave_should_be_output() {
        the_title_and_description_of_the_given_location_should_be_output(
                iceCave);
    }

    private void then_the_title_and_description_of_the_starting_location_should_be_output() {
        the_title_and_description_of_the_given_location_should_be_output(
                startingLocation);
    }

    private void the_title_and_description_of_the_given_location_should_be_output(Location location){
        assertThat(
                output(),
                containsString(location.getTitle()));
        assertThat(
                output(),
                containsString(location.getDescription()));
    }

    private void and_the_player_should_be_told_that_there_is_nowhere_to_go() {
        assertThat(output(), containsString("There is nowhere to go in that direction...\n"));
    }

    private String output() {
        return capturedSystemOut.toString();
    }
}
