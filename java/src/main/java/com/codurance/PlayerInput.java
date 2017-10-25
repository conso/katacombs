package com.codurance;

import java.util.HashMap;
import java.util.Map;

import static com.codurance.Direction.*;

public class PlayerInput {
    private final Map<String, Direction> directionMap;
    private Game game;

    public PlayerInput(Game game) {
        this.game = game;
        directionMap = new HashMap<>();
        populateDirectionMap();
    }

    private void populateDirectionMap() {
        directionMap.put("N", north);
        directionMap.put("S", south);
        directionMap.put("E", east);
        directionMap.put("W", west);
        directionMap.put("UP", up);
        directionMap.put("DOWN", down);
    }

    public void submit(String rawCommand) {
        if(rawCommand.isEmpty())
            return;

        int lastIndexOfSpace = rawCommand.lastIndexOf(' ');
        if(lastIndexOfSpace == - 1)
            return;

        String rawDirection = rawCommand.substring(lastIndexOfSpace + 1);

        Direction direction =
                directionMap.get(rawDirection);

        if(direction == null)
            return;

        game.go(direction);
    }
}
