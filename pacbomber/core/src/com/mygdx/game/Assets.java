package com.mygdx.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.audio.Music;
import com.badlogic.gdx.audio.Sound;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.Animation;
import com.badlogic.gdx.graphics.g2d.TextureRegion;

/**
 * This class loads and provides a reference to game assets so that they only
 * need to be loaded once, reducing lag
 */
public class Assets {
    public static Music backgroundMusic;

    public static Sound explosionSound;
    public static Animation<TextureRegion> explosionAnimation;

    public static Animation<TextureRegion> bombAnimation;

    public static Animation<TextureRegion> slimeMoveAnimation;
    public static TextureRegion slimeDeathTexture;
    public static Animation<TextureRegion> eyeballMoveAnimation;
    public static TextureRegion eyeballDeathTexture;

    public static Animation<TextureRegion> playerUpAnimation;
    public static Animation<TextureRegion> playerLeftAnimation;
    public static Animation<TextureRegion> playerRightAnimation;
    public static Animation<TextureRegion> playerDownAnimation;
    public static Animation<TextureRegion> playerDamageAnimation;
    public static TextureRegion playerDeathTexture;
    public static Sound playerHurtSound;

    public Assets() {
        bombAnimation = createAnimation(1, 1, "bomb.png", 0.1f);
        loadBackgroundMusic();
        loadMonsterAssets();
        loadPlayerAssets();
        loadExplosionAssets();
    }

    private void loadBackgroundMusic() {
        backgroundMusic = Gdx.audio.newMusic(Gdx.files.internal("bgmusic.mp3"));
        backgroundMusic.setVolume(0.2f);
        backgroundMusic.setLooping(true);
    }

    private void loadMonsterAssets() {
        slimeMoveAnimation = createAnimation(1, 5, "slime_move.png", 0.1f);
        slimeDeathTexture = new TextureRegion(new Texture(Gdx.files.internal("slime_dead.png")), 16, 16);
        eyeballMoveAnimation = createAnimation(1, 4, "eyeball_move.png", 0.1f);
        eyeballDeathTexture = new TextureRegion(new Texture(Gdx.files.internal("eyeball_dead.png")), 16, 16);
    }

    private void loadPlayerAssets() {
        playerUpAnimation = createAnimation(1, 6, "player_run_up.png", 0.1f);
        playerDownAnimation = createAnimation(1, 6, "player_run_down.png", 0.1f);
        playerLeftAnimation = createAnimation(1, 6, "player_run_left.png", 0.1f);
        playerRightAnimation = createAnimation(1, 6, "player_run_right.png", 0.1f);
        playerDamageAnimation = createAnimation(1, 2, "player_damage.png", 0.2f);
        playerDeathTexture = new TextureRegion(new Texture(Gdx.files.internal("player_dead.png")), 16, 16);
        playerHurtSound = Gdx.audio.newSound(Gdx.files.internal("hurt.wav"));
    }

    private void loadExplosionAssets() {
        explosionAnimation = createAnimation(1, 8, "explosion_green_20.png", 0.1f);
        explosionSound = Gdx.audio.newSound(Gdx.files.internal("explosion.mp3"));
    }

    /**
     * Creates an animation object from a spritesheet
     * @param rows Rows in the spritesheet
     * @param cols Columns in the spritesheet
     * @param path Filepath of the spritesheet
     * @param frameDuration Duration in seconds each frame should be displayed for
     * @return Animation object
     */
    private Animation<TextureRegion> createAnimation(int rows, int cols, String path, float frameDuration) {
        Texture sheet = new Texture(Gdx.files.internal(path));
        TextureRegion[][] temp = TextureRegion.split(sheet,
                sheet.getWidth() / cols,
                sheet.getHeight() / rows);
        TextureRegion[] frames = new TextureRegion[cols * rows];
        int index = 0;
        for (int i = 0; i < rows; i++) {
            for (int j = 0; j < cols; j++) {
                frames[index++] = temp[i][j];
            }
        }
        return new Animation<TextureRegion>(frameDuration, frames);
    }

    public void dispose() {
        backgroundMusic.stop();
    }
}
