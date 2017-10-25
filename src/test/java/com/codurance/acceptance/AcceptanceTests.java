package com.codurance.acceptance;

import org.junit.Test;

public class AcceptanceTests {
    // player can move between locations

    // treasure is collected automatically when a user enters a new location with gold for the first time

    // treasure is collected automatically when a user opens an item containing gold for the first time

    // items can be used to achieve effects

    // game ends when player finds end of catacombs

    // score calculated based on total value of all treasure collected

    // can look at things for more information

    // When looking somewhere without anything interesting the system should reply "Nothing interesting to look at there!"

    // When a general action is not available the system will reply "I can't do that here!"

    // When the system can't understand the command it should prompt "I don't understand that. English please!"

    // The game at startup shows the title and main description of the initial location

    // When the player moves to another location, the system will always prompt title and main description for the new location

    /* various commands are built in
        GO
            UP
            DOWN
            N
            S
            E
            W
        LOOK
            UP
            DOWN
            N
            S
            E
            W
        OPEN
            <ITEM>
        PICK
            <ITEM>
        DROP
            <ITEM>
        BAG
        USE
            <ITEM>
     */

    // game needs to be consistent - go NORTH then SOUTH and you need to be in the same place you started

    // use a specific item to open a passage
}
