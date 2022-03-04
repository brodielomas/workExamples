package com.mygdx.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.audio.Sound;
import com.badlogic.gdx.graphics.g2d.Animation;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.maps.tiled.TiledMap;
import com.badlogic.gdx.math.Vector2;

public class Explosion extends MapObject {
    private final float VOLUME = 0.3f;

    private Player player;
    private TextureRegion currentFrame;
    private Animation<TextureRegion> animation;
    private Sound explosionSound;
    private float stateTime;
    private float delta;

    public Explosion(float x, float y, TiledMap map,Direction direction) {
        super(x, y, map);
        loadAssets();

        // If this is the first explosion, expand in all directions
        if(direction == Direction.NONE) {
            explosionSound.play(VOLUME);
            Vector2 leftCell = new Vector2(getMapCoordinates().x - 1, getMapCoordinates().y);
            Vector2 rightCell = new Vector2(getMapCoordinates().x + 1, getMapCoordinates().y);
            Vector2 aboveCell = new Vector2(getMapCoordinates().x,getMapCoordinates().y - 1);
            Vector2 belowCell = new Vector2(getMapCoordinates().x,getMapCoordinates().y + 1);
            if (!isWall(leftCell)) {
                GameScreen.mapObjects.add(new Explosion(getX() - tileWidth, getY(), map, Direction.LEFT));
            }
            if (!isWall(rightCell)) {
                GameScreen.mapObjects.add(new Explosion(getX() +tileWidth, getY(), map, Direction.RIGHT));
            }
            if (!isWall(aboveCell)) {
                GameScreen.mapObjects.add(new Explosion(getX(), getY() + tileHeight, map, Direction.UP));
            }
            if (!isWall(belowCell)) {
                GameScreen.mapObjects.add(new Explosion(getX(), getY() - tileHeight, map, Direction.DOWN));

            }
        }
        else if (direction == Direction.LEFT) { // Expand left
            Vector2 leftCell = new Vector2(getMapCoordinates().x - 1, getMapCoordinates().y);
            if (!isWall(leftCell)) {
                GameScreen.mapObjects.add(new Explosion(getX() - tileWidth, getY(), map, Direction.LEFT));
            }

        }
        else if (direction == Direction.RIGHT) { // Expand right
            Vector2 rightCell = new Vector2(getMapCoordinates().x+ 1, getMapCoordinates().y);
            if (!isWall(rightCell)) {
                GameScreen.mapObjects.add(new Explosion(getX() +tileWidth, getY(), map, Direction.RIGHT));
            }
        }
        else if (direction == Direction.UP) { // Expand upwards
            Vector2 aboveCell = new Vector2(getMapCoordinates().x,getMapCoordinates().y-1);
            if (!isWall(aboveCell)) {
                GameScreen.mapObjects.add(new Explosion(getX(), getY() + tileHeight, map, Direction.UP));
            }
        }
        else { // Expand down
            Vector2 belowCell = new Vector2(getMapCoordinates().x,getMapCoordinates().y+1);
            if (!isWall(belowCell)) {
                GameScreen.mapObjects.add(new Explosion(getX(), getY() - tileHeight, map, Direction.DOWN));
            }
        }
    }

    @Override
    public TextureRegion getCurrentFrame() {
        return currentFrame;
    }

    @Override
    public void handle() {
        delta = Gdx.graphics.getDeltaTime();
        stateTime += delta;
        currentFrame = animation.getKeyFrame(stateTime, false);

        if (currentFrame == animation.getKeyFrames()[7]) { // Disappear at the end of the animation
            this.die();
        }

        for (int i = 0; i < GameScreen.monsters.size(); i++) {
            Monster currentMonster = GameScreen.monsters.get(i);
            if (currentMonster.boundingBox.overlaps(boundingBox)) {
                currentMonster.die();
            }
        }

        if (GameScreen.player.boundingBox.overlaps(boundingBox)) {
            GameScreen.player.takeDamage();
        }
    }

    private void loadAssets() {
        animation = Assets.explosionAnimation;
        currentFrame = animation.getKeyFrames()[0];
        explosionSound = Assets.explosionSound;
    }

    public void die() {
        GameScreen.mapObjects.remove(this);
    }
}
