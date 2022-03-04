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

public class MenuScreen implements Screen {

    private MyGdxGame game;
    private SpriteBatch batch;
    private Stage stage;
    private Skin skin;
    private BitmapFont font;

    public MenuScreen(MyGdxGame game) { this.game = game; }

    public void create() {
        Gdx.app.log("MenuScreen", "create");
        batch = new SpriteBatch();
        stage = new Stage();
        skin = new Skin(Gdx.files.internal("gui/uiskin.json"));
        font = new BitmapFont(Gdx.files.internal("gui/gravity.fnt"));

        createMenuButtons();
    }

    private void createMenuButtons() {
        final TextButton startButton = new TextButton("Start", skin);
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
                Gdx.app.log("MenuScreen", "changing to gameScreen...");
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

    /**
     * Renders the menu screen
     * @param delta
     */
    @Override
    public void render(float delta) {
        Gdx.gl.glClearColor((float)24/255, (float)33/255, (float)93/255, 1);
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);

        batch.begin();
        stage.draw();
        font.draw(batch, "PACBOMBER", Gdx.graphics.getWidth() / 2 - 140f, Gdx.graphics.getHeight() / 2 + 100f);
        batch.end();
    }

    @Override
    public void show() {
        Gdx.app.log("MenuScreen","show called");
        create();
    }

    @Override
    public void resize(int width, int height) { }
    @Override
    public void pause() { }
    @Override
    public void resume() { }
    @Override
    public void hide() {
        Gdx.app.log("MenuScreen","hide called");
        dispose();
    }
    @Override
    public void dispose() {
        stage.dispose();
    }
}
