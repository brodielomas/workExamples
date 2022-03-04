package com.mygdx.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.maps.tiled.TiledMap;
import com.badlogic.gdx.math.Rectangle;
import com.badlogic.gdx.math.Vector2;

abstract public class MapObject {

    protected TiledMap map;
    protected Rectangle boundingBox;
    protected int tileWidth;
    protected int tileHeight;
    protected int[][] walls;

    protected enum Direction {
        UP,
        DOWN,
        LEFT,
        RIGHT,
        NONE
    }

    public MapObject(float x, float y, TiledMap map) {
        this.map = map;
        this.tileWidth = (int)map.getProperties().get("tilewidth");
        this.tileHeight = (int)map.getProperties().get("tileheight");
        this.boundingBox = new Rectangle(x, y, tileWidth - 3, tileHeight - 3);
        instantiateWalls();
    }

    public float getX() {
        return boundingBox.x;
    }

    public float getY() {
        return boundingBox.y;
    }

    /**
     * Get Tiled map coordinates of current position
     * @return Vector2 coordinates
     */
    protected Vector2 getMapCoordinates() {
        return new Vector2(Math.round(boundingBox.x / tileWidth), (int)map.getProperties().get("height") - 1 - Math.round(boundingBox.y / tileHeight));
    }

    /**
     * Unreverse the y axis
     * @param y
     * @return y
     */
    private float unreverseY(float y) {
        return (int)map.getProperties().get("height") - 1 - y;
    }

    /**
     * Get coordinates for the next cell in the specified direction
     * @param direction
     * @return Cell coordinates
     */
    private Vector2 getTargetCell(Direction direction) {
        Vector2 targetCell = getMapCoordinates();

        if (direction == Direction.UP) { targetCell.y -= 1; }
        else if (direction == Direction.DOWN) { targetCell.y += 1; }
        else if (direction == Direction.LEFT) { targetCell.x -= 1; }
        else { targetCell.x += 1; }

        return targetCell;
    }

    /**
     * Get position of the edge of a wall
     * @param wall Coordinates of the wall
     * @param side Which side to get the edge of
     * @return Edge position
     */
    private float getWallEdge(Vector2 wall, Direction side) {
        if (side == Direction.UP) { return tileHeight * (unreverseY(wall.y) + 1); }
        else if (side == Direction.DOWN) { return tileHeight * (unreverseY(wall.y) + 1) - tileHeight; }
        else if (side == Direction.LEFT) { return tileWidth * (wall.x + 1) - tileWidth; }
        else { return tileWidth * (wall.x + 1); }
    }

    /**
     * Get position of an edge of this object
     * @param side Which side to get the edge of
     * @return Position
     */
    private float getEdge(Direction side) {
        if (side == Direction.UP) { return getY() + tileHeight; }
        else if (side == Direction.DOWN) { return getY(); }
        else if (side == Direction.LEFT) { return getX(); }
        else { return getX() + tileWidth; }
    }

    /**
     * Move object in a certain direction
     * @param direction Direction to move
     * @param delta Delta time
     * @param speed Movement speed
     */
    public void move(Direction direction, float delta, int speed) {
        Vector2 targetCell = getTargetCell(direction); // Cell the object is trying to move to
        Vector2 movementVector = new Vector2();

        // If trying to move into a wall
        if (isWall(targetCell)) {
            movementVector = walkIntoEdge(direction, targetCell, speed, delta, movementVector);
        }
        else { // If no wall nearby, keep moving normally
            if (direction == Direction.UP) { movementVector.y += speed * delta; }
            else if (direction == Direction.DOWN) { movementVector.y -= speed * delta; }
            else if (direction == Direction.LEFT) { movementVector.x -= speed * delta; }
            else { movementVector.x += speed * delta; }
        }

        // Stop sprite clipping into other tiles
        Vector2 currentCoordinates = getMapCoordinates();

        if (direction == Direction.UP || direction == Direction.DOWN) {
            if (getX() % tileWidth != 0) {
                if (getX() / tileWidth > currentCoordinates.x && isWall(new Vector2(currentCoordinates.x + 1, currentCoordinates.y))) { // Position is too far right
                    movementVector = walkIntoEdge(Direction.LEFT, new Vector2(currentCoordinates.x - 1, currentCoordinates.y), speed, delta, movementVector);
                }
                else if (getX() / tileWidth < currentCoordinates.x && isWall(new Vector2(currentCoordinates.x - 1, currentCoordinates.y))) { // Position is too far left
                    movementVector = walkIntoEdge(Direction.RIGHT, new Vector2(currentCoordinates.x + 1, currentCoordinates.y), speed, delta, movementVector);
                }
            }
        }
        else {
            if (getY() % tileHeight != 0) {
                if (getY() / tileHeight > currentCoordinates.y && isWall(new Vector2(currentCoordinates.x, currentCoordinates.y - 1))) { // Position is too far down
                    movementVector = walkIntoEdge(Direction.UP, new Vector2(currentCoordinates.x, currentCoordinates.y - 1), speed, delta, movementVector);
                }
                else if (getY() / tileHeight < currentCoordinates.y && isWall(new Vector2(currentCoordinates.x, currentCoordinates.y + 1))) { // Position is too far up
                    movementVector = walkIntoEdge(Direction.DOWN, new Vector2(currentCoordinates.x, currentCoordinates.y + 1), speed, delta, movementVector);
                }
            }
        }

        move(movementVector);
    }

    private Vector2 walkIntoEdge(Direction direction, Vector2 targetCell, int speed, float delta, Vector2 movementVector) {
        float objectEdge;
        float wallEdge;

        if (direction == Direction.UP) {
            objectEdge = getEdge(Direction.UP);
            wallEdge = getWallEdge(targetCell, Direction.DOWN);

            if (objectEdge + speed * delta < wallEdge) { // If moving will not pass the edge of the wall, move
                movementVector.y += speed * delta;
            }
            else { // If moving will pass the edge of the wall, hit the wall and stop
                movementVector.y = wallEdge - objectEdge;
            }
        }
        else if (direction == Direction.DOWN) {
            objectEdge = getEdge(Direction.DOWN);
            wallEdge = getWallEdge(targetCell, Direction.UP);

            if (objectEdge - speed * delta > wallEdge) { // If moving will not pass the edge of the wall, move
                movementVector.y -= speed * delta;
            }
            else { // If moving will pass the edge of the wall, hit the wall and stop
                movementVector.y = wallEdge - objectEdge;
            }
        }
        else if (direction == Direction.LEFT) {
            objectEdge = getEdge(Direction.LEFT);
            wallEdge = getWallEdge(targetCell, Direction.RIGHT);

            if (objectEdge - speed * delta > wallEdge) { // If moving will not pass the edge of the wall, move
                movementVector.x -= speed * delta;
            }
            else { // If moving will pass the edge of the wall, hit the wall and stop
                movementVector.x = wallEdge - objectEdge;
            }
        }
        else {
            objectEdge = getEdge(Direction.RIGHT);
            wallEdge = getWallEdge(targetCell, Direction.LEFT);

            if (objectEdge + speed * delta < wallEdge) { // If moving will not pass the edge of the wall, move
                movementVector.x += speed * delta;
            }
            else { // If moving will pass the edge of the wall, hit the wall and stop
                movementVector.x = wallEdge - objectEdge;
            }
        }
        return movementVector;
    }

    private void move(Vector2 movement) {
        boundingBox.x += movement.x;
        boundingBox.y += movement.y;
    }

    abstract public TextureRegion getCurrentFrame();

    /**
     * Handles logic for the map object and sets the current frame
     */
    abstract public void handle();

    protected boolean isWall(Vector2 cell) {
        int x = (int)cell.x;
        int y = (int)cell.y;

        if (walls.length <= y || y <= 0) {
            return true;
        }
        else if (walls[y].length <= x || x <= 0) {
            return true;
        }
        else {
            if (walls[y][x] == 0) {
                return false;
            }
            else {
                if (walls[y][x] == 2 && this.getClass() == Monster.class) {
                    return false;
                }
                return true;
            }
        }
    }

    private void instantiateWalls() {
        // 0 = no walls, 1 = wall, 2 = wall that only monsters can pass through
        this.walls = new int[][] {
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                {1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1},
                {1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1},
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                {1, 0, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 0, 1},
                {1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1},
                {1, 1, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 1, 1},
                {0, 0, 1, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 1, 0, 0},
                {0, 0, 1, 0, 0, 1, 0, 1, 1, 2, 1, 1, 0, 1, 0, 0, 1, 0, 0},
                {0, 0, 1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1, 0, 0},
                {0, 0, 1, 0, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 0, 1, 0, 0},
                {0, 0, 0, 1, 0, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 1, 0, 0, 0},
                {1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1},
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                {1, 0, 1, 1, 0, 1, 1, 1, 0, 1, 0, 1, 1, 1, 0, 1, 1, 0, 1},
                {1, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 1},
                {1, 1, 0, 1, 0, 1, 0, 1, 1, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1},
                {1, 0, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1, 0, 0, 0, 0, 1},
                {1, 0, 1, 1, 1, 1, 1, 1, 0, 1, 0, 1, 1, 1, 1, 1, 1, 0, 1},
                {1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1},
                {1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
        };
    }
}
