# Codurance Katacombs

Inspired by [Colossal Cave Adventure](https://en.wikipedia.org/wiki/Colossal_Cave_Adventure) this is a kata idea for building a text adventure game which can be expanded *incrementally* and *indefinetly* limited only by imagination.

The game is based on a console application describing a fictional underground world to be explored by the player via a set of commands.
The world is a collection of environments connected to eachother via specific connection points (doors, passages, gates, stairs, etc). Each environment is divided in locations and the player can move among them using cardinal points for directions. 
It is possible to just look in every directions, but not all the directions are always available for being looked at, nor to move to. 

When looking somewhere without anything interesting the system should reply **"Nothing interesting to look at there!"**.

When a general action is not available the system will reply *"I can't do that here!"*.

When the system can't understand the command it should prompt ***"I don't understand that. English please!"***.

#### Startup

The game at startup describe the **main description** of the initial location. When the player moves to another location, the system will always prompt the main description for that location.

```
YOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. 
AROUND YOU IS A FOREST OF INDIAN RESTAURNTS. 
A SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY.
>
```
   
#### Exploring the world 
 
  * #### *Moving* 
     **GO** followed by the letter of the cardinal point
     
```  
> GO N => move to the NORTH
> GO E => move to the EAST
> GO S => move to the SOUTH
> GO W => move to the WEST
```
       
    
  * #### *Stairs* 
     **GO** followed by **UP** or **DOWN** depending where the stairs are leading
     
```
> GO UP => use stairs to go up
> GO DOWN => use stairs to go down    
```
    
  
  * #### *Looking*
    **LOOK** allows to look in every direction to have an idea of the surrounding environment. 
    
```
YOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. 
AROUND YOU IS A FOREST OF INDIAN RESTAURNTS. 
A SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY.
> LOOK N
I CAN SEE A BRICK BUILDING WITH A SIGN SAYING "TRUMAN BREWERY" AND A WOODEN WHITE DOOR
```       
   
#### Interact with the environment
There are several commands for interacting with the environment. These commands are always composed by two parts: the action and the object. Usually the object is specified in the main description or in the result of the LOOK command.

 * #### *Opening*
    **OPEN** will try to open the object of the command. Usually it's about doors or gates, but this should be a magic world....
    
```
I CAN SEE A BRICK BUILDING WITH A SIGN SAYING "TRUMAN BREWERY" AND A WOODEN WHITE DOOR.
> OPEN DOOR
YOU ARE INSIDE THE MAIN ROOM OF THE TRUMAN BREWERY. THERE IS A STRONG SMELL OF HOP AND A DOZEN EMPTY CASKS 
``` 

* #### *Picking and dropping items*
    **PICK** will collect an item from the environment and will put it in the bag. **DROP** allows to leave an item in the environment. Every item can be picked and dropped anywhere and the game has to list the items in the environment just after the main description.
```
INSIDE THE BUILDING
YOU ARE INSIDE THE BUILDING, A WELL HOUSE FOR LARGE SPRINGS.
THERE ARE SOME KEYS ON THE FLOOR.
> PICK KEYS
KEYS: PICKED.
> DROP KEYS
KEYS: DROPPED.
```

* #### *Checking inventory*
    **INVENTORY** will show a list of items in the bag. The bag can containg only 10 items.
```
> INVENTORY
THE BAG CONTAINS: SOME KEYS, A SWISS KNIFE, A CANDLE AND A COMPASS.
```

* #### *Using items*
    **USE** will perform an action with the item, if the environment is setup for it. It can give an extra sentence in the main description, unlock another passage or location
```
> USE KEYS
THE RED DOOR HAS BEEN UNLOCKED!
> OPEN DOOR
YOU ARE INSIDE THE RED CHAMBER 
```








