package com.mygdx.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Screen;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.scenes.scene2d.InputEvent;
import com.badlogic.gdx.scenes.scene2d.Stage;
import com.badlogic.gdx.scenes.scene2d.ui.Skin;
import com.badlogic.gdx.scenes.scene2d.ui.TextButton;
import com.badlogic.gdx.scenes.scene2d.utils.ClickListener;

public class GameOverScreen implements Screen {

    private MyGdxGame game;
    private SpriteBatch batch;
    private Stage stage;
    private Skin skin;
    private BitmapFont font;
    private BitmapFont font2;
    private BitmapFont buttonFont;
    public GameOverScreen(MyGdxGame game) { this.game = game;}

    /**
     * Creates the GameOverScreen.
     */
    public void create() {
        Gdx.app.log("GameOverScreen", "create");
        batch = new SpriteBatch();
        stage = new Stage();
        skin = new Skin(Gdx.files.internal("gui/uiskin.json"));
        font = new BitmapFont(Gdx.files.internal("gui/gravity.fnt"));
        font.getData().setScale(1f, 1f);

        font2 = new BitmapFont(Gdx.files.internal("gui/gravity.fnt"));
        font2.getData().setScale(0.75f, 0.75f);

        buttonFont = new BitmapFont(Gdx.files.internal("gui/gravity.fnt"));
        buttonFont.getData().setScale(0.4f, 0.4f);

        createMenuButtons();
    }

    /**
     * Creates menu buttons with click listeners and behaviour, then adds them to the stage
     */
    private void createMenuButtons() {
        final TextButton startButton = new TextButton("Retry", skin);
        startButton.setWidth(200f);
        startButton.setHeight(100f);
        startButton.setPosition(Gdx.graphics.getWidth() / 2 - 250f, Gdx.graphics.getHeight() / 2 - 150f);

        final TextButton exitButton = new TextButton("Exit", skin);
        exitButton.setWidth(200f);
        exitButton.setHeight(100f);
        exitButton.setPosition(Gdx.graphics.getWidth() / 2 + 50, Gdx.graphics.getHeight() / 2 - 150f);

        stage.addActor(startButton);
        stage.addActor(exitButton);
        Gdx.input.setInputProcessor(stage);

        startButton.addListener(new ClickListener() {
            @Override
            public void clicked(InputEvent event, float x, float y) {
                Gdx.app.log("GameOverScreen", "changing to gameScreen...");
                game.setScreen(MyGdxGame.gameScreen);
            }
        });
        exitButton.addListener(new ClickListener() {
            @Override
            public void clicked(InputEvent event, float x, float y) {
                Gdx.app.exit();
            }
        });
    }

    private void drawText() {
        font.draw(batch, "Game Over", Gdx.graphics.getWidth() / 2 - 150, Gdx.graphics.getHeight() / 2 + 100f);
        font2.draw(batch, "SCORE: " + GameScreen.totalScore, Gdx.graphics.getWidth() / 2 - 130, Gdx.graphics.getHeight() / 2 + 50f);
    }

    /**
     * Renders the GameOverScreen
     * @param delta
     */
    @Override
    public void render(float delta) {
        Gdx.gl.glClearColor((float)24/255, (float)33/255, (float)93/255, 1);
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);

        batch.begin();
        stage.draw();
        drawText();
        batch.end();
    }

    @Override
    public void show() {
        Gdx.app.log("GameOverScreen","show called");
        create();
    }
    @Override
    public void resize(int width, int height) {
    }
    @Override
    public void pause() {
    }
    @Override
    public void resume() {
    }
    @Override
    public void hide() {
        Gdx.app.log("GameOverScreen","hide called");
        dispose();
    }

    /**
     * Disposes of the GameOverScreen
     */
    @Override
    public void dispose() {
        MyGdxGame.gameScreen.dispose();
        stage.dispose();
    }
}
