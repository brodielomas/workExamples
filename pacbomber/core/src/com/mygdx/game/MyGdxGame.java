package com.mygdx.game;

import com.badlogic.gdx.ApplicationListener;
import com.badlogic.gdx.Game;
import com.badlogic.gdx.Gdx;

public class MyGdxGame extends Game implements ApplicationListener {

	public static MenuScreen menuScreen;
	public static GameScreen gameScreen;
	public static GameOverScreen gameOverScreen;
	
	@Override
	public void create () {
		Gdx.app.log("MyGdxGame", "create");
		menuScreen = new MenuScreen(this);
		gameScreen = new GameScreen(this);
		gameOverScreen = new GameOverScreen(this);
		Gdx.app.log("MyGdxGame", "changing to menuScreen...");
		setScreen(menuScreen);
		Gdx.app.log("MyGdxGame", "screen set to menuScreen");
	}

	@Override
	public void render () {
		super.render();
	}
	@Override
	public void dispose () {
		super.dispose();
	}
	@Override
	public void resize(int width, int height) {
		super.resize(width, height);
	}
	@Override
	public void pause() {
		super.pause();
	}
	@Override
	public void resume() {
		super.resume();
	}
}
