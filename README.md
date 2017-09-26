# Codurance Katacombs

Inspired by [Colossal Cave Adventure](https://en.wikipedia.org/wiki/Colossal_Cave_Adventure) this is a kata idea for building a text adventure game which can be expanded *incrementally* and *indefinetly* limited only by imagination.

## Interactions
The game is based on a console application describing a fictional underground world to be explored by the player via a set of commands.
Most obvious are the commands for moving around the world, but there are several other actions allowed and more can be added in the future.

   #### Exploring the world 
   The world is a collection of environments connected to eachother via specific connection points (doors, passages, gates, stairs, etc). Each environment is divided in squares and the player can move among them using cardinal points for directions. It is also possible to just look in every directions. But not all the directions are always available for moving into, neither being looked at. When the action is not available the system will reply ***"I can't do that here!"***
   * #### *Startup*
     The game at startup describe the **main description** of the initial location. When the player moves to another location, the system will always prompt the main description for that location.
        ```
        YOU ARE STANDING AT THE END OF A ROAD BEFORE A SMALL BRICK BUILDING. 
        AROUND YOU IS A FOREST.  A SMALL STREAM FLOWS OUT OF THE BUILDING AND DOWN A GULLY.
        >
        ```
    
   * #### *Looking*
        **LOOK** allows to look in every direction to have an idea of the surrounding environment. 
        ```
        YOU ARE STANDING AT THE END OF A ROAD BEFORE A SMALL BRICK BUILDING. 
        AROUND YOU IS A FOREST.  A SMALL STREAM FLOWS OUT OF THE BUILDING AND DOWN A GULLY.
        > LOOK N
        I CAN SEE A SMALL BRICK BUILDING WITH A WOODEN WHITE DOOR
        ```
   
  * #### *Moving* 
     **GO** followed by the letter of the cardinal point
    ```
    > GO N => move to the NORTH
    > GO E => move to the EAST
    > GO S => move to the SOUTH
    > GO W => move to the WEST
    ```
  


