package com.mygdx.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.Animation;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.maps.tiled.TiledMap;
import com.badlogic.gdx.math.Vector2;

public class Player extends MapObject {

    final int MOVEMENT_SPEED = 100;
    final int STARTING_BOMBS = 3;
    final int STARTING_HEALTH = 3;
    final int BOMB_REGEN_TIME = 2;
    final Direction STARTING_DIRECTION = Direction.LEFT;

    private Animation<TextureRegion> upAnimation;
    private Animation<TextureRegion> downAnimation;
    private Animation<TextureRegion> leftAnimation;
    private Animation<TextureRegion> rightAnimation;
    private Animation<TextureRegion> damageAnimation;
    private TextureRegion deathTexture;

    private float score;

    public enum PlayerState {
        ALIVE,
        DAMAGED,
        DEAD
    }
    private PlayerState playerState;

    private Direction direction;

    private float delta;
    private float stateTime;
    private float damageTime;
    private float deadTime;
    private float bombRegen;

    private int bombs;
    private int health;

    private TextureRegion currentFrame;

    public Player(float x, float y, TiledMap map) {
        super(x, y, map);
        stateTime = 0.0f;
        damageTime = 0.0f;
        deadTime = 0.0f;
        bombRegen = 0.0f;
        playerState = PlayerState.ALIVE;
        direction = STARTING_DIRECTION;
        bombs = STARTING_BOMBS;
        score = 0;
        health = STARTING_HEALTH;
        loadAnimations();
    }

    public void handle() {
        delta = Gdx.graphics.getDeltaTime();
        stateTime += delta;

        if (playerState != PlayerState.DEAD) {
            score += delta * 10;
            bombRegen += delta;
            if (bombRegen > BOMB_REGEN_TIME) {
                bombs += 1;
                bombRegen = 0;
            }
            move(direction, delta, MOVEMENT_SPEED);

            if (playerState == PlayerState.DAMAGED) {
                damageTime += delta;
                if (damageTime > 1) { // Change back to normal ALIVE state after 1 second
                    damageTime = 0;
                    playerState = PlayerState.ALIVE;
                }
            }
        }
        else {
            deadTime += delta;
        }

        handleAnimation();
    }

    public int getScore() {
        return Math.round(score);
    }

    public void addScore(int points) {
        score += points;
    }

    public void dropBomb() {
        if (bombs > 0 ) {
            GameScreen.mapObjects.add(new Bomb(getX(), getY(), map));
            bombs--;
        }
    }

    public int getBombs(){
        return bombs;
    }

    public void changeDirection (Direction newDirection) { direction = newDirection; }

    public TextureRegion getCurrentFrame() { return currentFrame; }

    public void takeDamage() {
        if (playerState != PlayerState.DAMAGED) { // Player is temporarily invulnerable after getting hit
            if (health > 0) {
                health--;
                playerState = PlayerState.DAMAGED;
                Assets.playerHurtSound.play();
            }
            else {
                die();
            }
        }
    }

    public void die() {
        if (playerState != PlayerState.DEAD) {
            Assets.playerHurtSound.play();
            playerState = PlayerState.DEAD;
        }
        else {
            if (deadTime > 3) {
                GameScreen.game.setScreen(MyGdxGame.gameOverScreen);
            }
        }
    }

    private void handleAnimation() {
        if (playerState == PlayerState.ALIVE) {
            switch (direction) {
                case UP:
                    currentFrame = upAnimation.getKeyFrame(stateTime, true);
                    break;
                case DOWN:
                    currentFrame = downAnimation.getKeyFrame(stateTime, true);
                    break;
                case LEFT:
                    currentFrame = leftAnimation.getKeyFrame(stateTime, true);
                    break;
                case RIGHT:
                    currentFrame = rightAnimation.getKeyFrame(stateTime, true);
                    break;
            }
        }
        else if (playerState == PlayerState.DAMAGED ){
            currentFrame = damageAnimation.getKeyFrame(damageTime, false);
        }
        else {
            currentFrame = deathTexture;
        }
    }

    private void loadAnimations() {
        upAnimation = Assets.playerUpAnimation;
        downAnimation = Assets.playerDownAnimation;
        leftAnimation = Assets.playerLeftAnimation;
        rightAnimation = Assets.playerRightAnimation;
        damageAnimation = Assets.playerDamageAnimation;

        deathTexture = Assets.playerDeathTexture;

        currentFrame = upAnimation.getKeyFrames()[0];
    }
}
