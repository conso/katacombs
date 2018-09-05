# Agile Tech Praxis Katacombs

Inspired by [Colossal Cave Adventure](https://en.wikipedia.org/wiki/Colossal_Cave_Adventure) this is a kata idea for building a text adventure game which can be expanded *incrementally* and *indefinetly* limited only by imagination.

The game is based on a console application describing a fictional underground world to be explored by the player via a set of commands.
The world is a collection of locations linked to each other geographically (on North, South, East or West) or via specific connection points (doors, passages, gates, stairs, etc). The player can move among them using cardinal points for directions or exploiting the connection points with actions or items. 
It is possible to just look in every directions, but not all the directions are always available for being looked at, nor to move to. 

The world will have treasures hidden in several locations, which will be collected when players enter the location or use the correct item in the correct location. 
The game terminates when the player finds the exit of the katacomb and the score will be the sum of the value of the treasures collected.

When looking somewhere without anything interesting the system should reply **"Nothing interesting to look at there!"**.

When a general action is not available the system will reply **"I can't do that here!"**.

When the system can't understand the command it should prompt **"I don't understand that. English please!"**.

#### Startup

The game at startup shows the **title** and **main description** of the initial location. When the player moves to another location, the system will always prompt **title** and **main description** for the new location.

```
LOST IN SHOREDITCH.
YOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. 
AROUND YOU IS A FOREST OF INDIAN RESTAURANTS. 
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
    **LOOK** allows to look in every direction to have an idea of the surroundings or a better description of an item. 
    
```
LOST IN SHOREDITCH.
YOU ARE STANDING AT THE END OF BRICK LANE BEFORE A SMALL BRICK BUILDING CALLED THE OLD TRUMAN BREWERY. 
AROUND YOU IS A FOREST OF INDIAN RESTAURNTS. 
A SMALL STREAM OF CRAFTED BEER FLOWS OUT OF THE BUILDING AND DOWN A GULLY.
> LOOK N
I CAN SEE A BRICK BUILDING WITH A SIGN SAYING "TRUMAN BREWERY" AND A WOODEN WHITE DOOR
```       
   
   #### World correctness
   There are only two requirements for the world. The first is that there should not be two different locations with the same title. The second is that the locations must have mutual reversed references to each other. That means that if from location A going South I end up in location B, then from location B going North I must end up in location A. Same principle should be valid for all cardinal points, but also when going up and down.
   
   
#### Interact with the environment
There are several commands for interacting with the environment. These commands are always composed by two parts: the action and the object. Usually the object is specified in the main description or in the result of the LOOK command.

 * #### *Opening*
    **OPEN** will try to open the object of the command. Usually it's about doors or gates, but this should be a magic world....
    
```
I CAN SEE A BRICK BUILDING WITH A SIGN SAYING "TRUMAN BREWERY" AND A WOODEN WHITE DOOR.
> OPEN DOOR
YOU ARE INSIDE THE MAIN ROOM OF THE TRUMAN BREWERY. THERE IS A STRONG SMELL OF HOP AND A DOZEN EMPTY CASKS 
``` 

* #### *Taking and dropping items*
    **TAKE** will collect an item from the environment and will put it in the bag. **DROP** allows to leave an item in the environment. Every item can be taken and dropped anywhere and the game has to list the items in the environment just after the main description.
```
INSIDE THE BUILDING.
YOU ARE INSIDE THE BUILDING, A WELL HOUSE FOR LARGE SPRINGS.
THERE ARE SOME KEYS ON THE FLOOR.
> TAKE KEYS
KEYS: TAKEN.
> DROP KEYS
KEYS: DROPPED.
```

* #### *Checking BAG*
    **BAG** will show a list of items in the bag. The bag can containg only 10 items.
```
> BAG
THE BAG CONTAINS: SOME KEYS, A SWISS KNIFE, A CANDLE AND A COMPASS.
```

* #### *Using items*
    **USE** will perform an action with the item, if the environment is setup for it and if we have the item in the bag. The action can result in an extra sentence in the main description, unlocking a passage toward a hidden location, releasing a new item in the location.
```
> USE KEYS
THE RED DOOR HAS BEEN UNLOCKED!
> OPEN DOOR
YOU ARE INSIDE THE RED CHAMBER 
```

#### Collecting gold
The treasures we can find in the cave are in form of gold coins. They get collected automatically when a user move to a location with gold for the first time or opens an item containing gold for the first time. The total amount of gold retrieved can be seen in the BAG.

#### Game utilities

 * #### *Help*
    **?** will list all the available commands and their usage.
    
```
> ?
GO [direction], LOOK [direction/item], OPEN [item], TAKE [item], DROP [item], BAG, USE [item]
``` 

 * #### *Quit*
    **Quit** terminates the game 
