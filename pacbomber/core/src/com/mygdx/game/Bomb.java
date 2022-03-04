package com.mygdx.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.Animation;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.graphics.g3d.particles.ParticleSorter;
import com.badlogic.gdx.maps.tiled.TiledMap;

public class Bomb extends MapObject {
    private final float BOMB_TIME = 2;

    private TextureRegion currentFrame;
    private Animation<TextureRegion> bombAnimation;
    private float timer;
    private float delta;

    public Bomb(float x, float y, TiledMap map) {
        super(x, y, map);
        loadAnimations();
        timer = 0;
    }

    @Override
    public TextureRegion getCurrentFrame() {
        return currentFrame;
    }

    @Override
    public void handle() {
        delta = Gdx.graphics.getDeltaTime();
        timer += delta;

        if (timer >= BOMB_TIME) {
            GameScreen.mapObjects.add(new Explosion(getX(), getY(), map, Direction.NONE));
            GameScreen.mapObjects.remove(this);
            timer = 0;
        }
    }

    private void loadAnimations() {
        bombAnimation = Assets.bombAnimation;
        currentFrame = bombAnimation.getKeyFrames()[0];
    }
}
