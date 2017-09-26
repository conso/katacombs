# Katacombs

Inspired by [Colossal Cave Adventure](https://en.wikipedia.org/wiki/Colossal_Cave_Adventure) this is a kata idea for building a text adventure game which can be expanded *incrementally* and *indefinetly* limited only by imagination.

## Interactions
The game is based on a console application describing a fictional underground world to be explored by the player via a set of commands.
Most obvious are the commands for moving around the world, but there are several other actions allowed and more can be added in the future.

* #### Exploring the world 
  Moving is the most used command, so it's done just using the cardinal points.
  ```
  > N => go NORTH
  > E => go EAST
  > S => go SOUTH
  > W => go WEST
  ```
  