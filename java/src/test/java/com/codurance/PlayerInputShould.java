package com.codurance;

import junitparams.JUnitParamsRunner;
import junitparams.Parameters;
import org.junit.Before;
import org.junit.Test;
import org.junit.runner.RunWith;

import static com.codurance.Direction.*;
import static org.mockito.Matchers.any;
import static org.mockito.Mockito.*;

@RunWith(JUnitParamsRunner.class)
public class PlayerInputShould {
    private Game game;
    private PlayerInput input;

    @Before
    public void set_up() {
        game = mock(Game.class);
        input = new PlayerInput(game);
    }

    @Test public void
    do_nothing_with_an_empty_command() {
        input.submit("");
    }

    @Test public void
    not_call_go_when_go_command_is_missing_a_direction() {
        input.submit("GO");
        verify(game, never()).go(any());
    }
    
    @Test
    @Parameters({
            "GO N, north",
            "GO S, south",
            "GO E, east",
            "GO W, west",
            "GO UP, up",
            "GO DOWN, down",
    }) public void
    call_go_when_given_a_valid_go_command(String command, Direction expectedDirection) {
        input.submit(command);
        verify(game, times(1)).go(expectedDirection);
    }
}
