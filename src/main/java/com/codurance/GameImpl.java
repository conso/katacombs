package com.codurance;

public class GameImpl implements Game {
    private Location currentLocation;

    public GameImpl(Location currentLocation){
        this.currentLocation = currentLocation;
        printLocationEnteredDialogue(currentLocation);
    }

    public Location getCurrentLocation() {
        return currentLocation;
    }

    @Override
    public void go(Direction direction) {
        Location newLocation = currentLocation.moveTo(direction);

        if (newLocation == null) {
            printFailedMovementWarning();
        }
        else {
            currentLocation = newLocation;
        }

        printLocationEnteredDialogue(currentLocation);
    }

    public void printLocationEnteredDialogue(Location location) {
        System.out.println(location.getTitle());
        System.out.println(location.getDescription());
    }

    private void printFailedMovementWarning() {
        System.out.println("There is nowhere to go in that direction...");
    }
}
