package com.mygdx.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.Animation;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.maps.tiled.TiledMap;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.utils.Queue;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Random;

public class Monster extends MapObject {

    static final int MOVEMENT_SPEED = 50;

    private Animation<TextureRegion> moveAnimation;
    private TextureRegion deathTexture;
    private TextureRegion currentFrame;

    private float delta;
    private float stateTime;
    private float deathTime;

    private enum State {
        ALIVE,
        DEAD
    }
    private State state;

    public Monster(float x, float y, TiledMap map) {
        super(x, y, map);
        loadAnimation();
        state = State.ALIVE;
        deathTime = 0;
    }

    public void handle() {
        delta = Gdx.graphics.getDeltaTime();
        stateTime += delta;

        handleAnimation();
        handleDeath();

        if (state == State.ALIVE) {
            move(getMovementDirection(getNextCell(GameScreen.player.getMapCoordinates())), delta, MOVEMENT_SPEED);
            if (boundingBox.overlaps(GameScreen.player.boundingBox)) {
                GameScreen.player.takeDamage();
            }
        }
    }

    public TextureRegion getCurrentFrame() {
        return currentFrame;
    }

    public void die() {
        if (state != State.DEAD) {
            state = State.DEAD;
            GameScreen.player.addScore(100);
        }
    }

    private void handleDeath() {
        if (state == State.DEAD) {
            deathTime += delta;
            if (deathTime >= 0.1f) {
                GameScreen.monsters.remove(this);
            }
        }
    }

    private void handleAnimation() {
        if (state == State.ALIVE) {
            currentFrame = moveAnimation.getKeyFrame(stateTime, true);
        }
        else {
            currentFrame = deathTexture;
        }
    }

    /**
     * Get movement direction for any adjacent cell
     * @param nextCell
     * @return
     */
    private Direction getMovementDirection(Vector2 nextCell) {
        Vector2 currentCell = getMapCoordinates();
        Direction direction;

        if (nextCell.y == currentCell.y - 1) {
            direction = Direction.UP;
        }
        else if (nextCell.y == currentCell.y + 1) {
            direction = Direction.DOWN;
        }
        else if (nextCell.x == currentCell.x - 1) {
            direction = Direction.LEFT;
        }
        else {
            direction = Direction.RIGHT;
        }
        return direction;
    }

    /**
     * Get next cell on path towards the player using A* algorithm
     * @param destination
     * @return
     */
    private Vector2 getNextCell(Vector2 destination) {
        Vector2 startingCell = getMapCoordinates();

        Queue<Vector2> frontier = new Queue<Vector2>();
        frontier.addLast(startingCell);
        HashMap<Vector2, Vector2> cameFrom = new HashMap<Vector2, Vector2>();
        cameFrom.put(startingCell, null);

        Vector2 currentCell = startingCell;

        // Search the map
        while (!frontier.isEmpty()) {
            currentCell = frontier.first();
            frontier.removeFirst();

            if (currentCell.equals(destination)) {
                break;
            }

            Vector2 aboveCell = new Vector2(currentCell.x, currentCell.y - 1);
            Vector2 belowCell = new Vector2(currentCell.x, currentCell.y + 1);
            Vector2 leftCell = new Vector2(currentCell.x - 1, currentCell.y);
            Vector2 rightCell = new Vector2(currentCell.x + 1, currentCell.y);
            Vector2[] adjacentCells = new Vector2[]{ aboveCell, belowCell, leftCell, rightCell };
            for (int i = 0; i < adjacentCells.length; i++) {
                if (!isWall(adjacentCells[i])) {
                    if (!cameFrom.containsKey(adjacentCells[i])) {
                        frontier.addLast(adjacentCells[i]);
                        cameFrom.put(adjacentCells[i], currentCell);
                    }
                }
            }
        }

        // Reconstruct path
        ArrayList<Vector2> path = new ArrayList<Vector2>();
        while (!currentCell.equals(startingCell)) {
            path.add(currentCell);
            currentCell = cameFrom.get(currentCell);
        }

        if (path.size() > 0) {
            return path.get(path.size() - 1); // Return the next cell monster must move to
        }
        else {
            return startingCell; // Monster should not move
        }
    }

    private void loadAnimation() {
        Random random = new Random();
        // 50% chance to be either a slime or eyeball
        if (random.nextBoolean()) {
            moveAnimation = Assets.slimeMoveAnimation;
            deathTexture = Assets.slimeDeathTexture;
        }
        else {
            moveAnimation = Assets.eyeballMoveAnimation;
            deathTexture = Assets.eyeballDeathTexture;
        }
    }
}
