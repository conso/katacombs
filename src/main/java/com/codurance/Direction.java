package com.codurance;

public enum Direction {
    north, south, east, west, up, down;

    public Direction complement(){
        switch(this) {
            case down:
                return up;
            case up:
                return down;
            case west:
                return east;
            case east:
                return west;
            case north:
                return south;
            default:
                return north;
        }
    }
}
