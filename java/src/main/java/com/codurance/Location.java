package com.codurance;

import java.util.HashMap;
import java.util.Map;

public class Location {
    private final String description;
    private final String title;
    private Map<Direction, Location> passages;

    public Location(String title, String description) {
        this.title = title;
        this.description = description;
        passages = new HashMap<>();
    }

    public String getDescription() {
        return description;
    }

    public String getTitle() {
        return title;
    }

    public void createPassageTo(Location location, Direction direction) {
        putPassage(location, direction);
        Direction returnDirection = direction.complement();
        location.putReturnPassage(this, returnDirection);
    }

    public Location moveTo(Direction direction) {
        return passages.get(direction);
    }

    public static Location WithTitleAndDescription(String title, String description) {
        return new Location(title, description);
    }

    private void putReturnPassage(Location location, Direction direction) {
        putPassage(location, direction);
    }

    private void putPassage(Location location, Direction direction) {
        passages.put(direction, location);
    }

    @Override
    public String toString() {
        return title + ": " + hashCode();
    }
}
