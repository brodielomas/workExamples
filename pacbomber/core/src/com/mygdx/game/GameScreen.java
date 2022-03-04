package com.mygdx.game;

import com.badlogic.gdx.Gdx;
import com.badlogic.gdx.Input;
import com.badlogic.gdx.Screen;
import com.badlogic.gdx.audio.Music;
import com.badlogic.gdx.audio.Sound;
import com.badlogic.gdx.graphics.Color;
import com.badlogic.gdx.graphics.GL20;
import com.badlogic.gdx.graphics.OrthographicCamera;
import com.badlogic.gdx.graphics.Texture;
import com.badlogic.gdx.graphics.g2d.Animation;
import com.badlogic.gdx.graphics.g2d.BitmapFont;
import com.badlogic.gdx.graphics.g2d.SpriteBatch;
import com.badlogic.gdx.graphics.g2d.TextureRegion;
import com.badlogic.gdx.maps.tiled.TiledMap;
import com.badlogic.gdx.maps.tiled.TiledMapRenderer;
import com.badlogic.gdx.maps.tiled.TiledMapTileLayer;
import com.badlogic.gdx.maps.tiled.TmxMapLoader;
import com.badlogic.gdx.maps.tiled.renderers.OrthogonalTiledMapRenderer;
import com.badlogic.gdx.math.Vector;
import com.badlogic.gdx.math.Vector2;
import com.badlogic.gdx.scenes.scene2d.InputEvent;
import com.badlogic.gdx.scenes.scene2d.ui.TextButton;
import com.badlogic.gdx.scenes.scene2d.Stage;
import com.badlogic.gdx.scenes.scene2d.ui.Skin;
import com.badlogic.gdx.scenes.scene2d.utils.ClickListener;

import java.util.ArrayList;

public class GameScreen implements Screen {

    static final int TILE_WIDTH = 16;
    static final int TILE_HEIGHT = 16;
    static final int MAP_WIDTH = 19;
    static final int MAP_HEIGHT = 22;

    public static MyGdxGame game;

    private TiledMap tiledMap;
    private OrthographicCamera camera;
    private TiledMapRenderer tiledMapRenderer;
    private SpriteBatch spriteBatch;

    public static ArrayList<MapObject> mapObjects;
    public static ArrayList<Monster> monsters;
    public static Player player;

    private Stage stage;
    private Skin skin;

    TextButton leftButton;
    TextButton rightButton;
    TextButton upButton;
    TextButton downButton;
    TextButton bombButton;

    private float monsterTimer;
    private float monsterSpawnInterval;
    private int monstersSpawned;
    private int lastMonstersSpawned;

    private boolean lastFrameSpacebarPressed;

    private BitmapFont font;
    static public int totalScore;

    public static Assets assets;

    public GameScreen(MyGdxGame game) { this.game = game; }

    public void create() {
        Gdx.app.log("GameScreen", "create");
        font = new BitmapFont(Gdx.files.internal("gui/gravity.fnt"));
        font.getData().setScale(0.35f, 0.35f);

        assets = new Assets();

        loadLevel();
        createCamera();

        mapObjects = new ArrayList<MapObject>();
        monsters = new ArrayList<Monster>();

        // Create the player
        player = new Player(9 * TILE_WIDTH, 9 * TILE_HEIGHT, tiledMap);

        stage = new Stage();
        spriteBatch = new SpriteBatch();
        monsterTimer = 0;
        monsterSpawnInterval = 2;
        monstersSpawned = 0;

        totalScore = 0;

        lastFrameSpacebarPressed = false;

        assets.backgroundMusic.play();

        createInputButtons();
    }

    @Override
    public void render(float delta) {
        Gdx.gl.glClearColor((float)24/255, (float)33/255, (float)93/255, 1);
        Gdx.gl.glBlendFunc(GL20.GL_SRC_ALPHA, GL20.GL_ONE_MINUS_SRC_ALPHA);
        Gdx.gl.glClear(GL20.GL_COLOR_BUFFER_BIT);

        totalScore = player.getScore();

        handleKeyboardInput();
        handleMonsterSpawning(delta);

        tiledMapRenderer.setView(camera);
        camera.update();
        tiledMapRenderer.render();

        handleMapObjects(); // Handle the game logic for all map objects
        handleMonsters();
        player.handle();

        spriteBatch.setProjectionMatrix(camera.combined);
        spriteBatch.begin();
        for (int i = 0; i < mapObjects.size(); i++) { // Draw every map object to the screen
            MapObject currentMapObject = mapObjects.get(i);
            if (currentMapObject != null) {
                spriteBatch.draw(currentMapObject.getCurrentFrame(), currentMapObject.getX(), currentMapObject.getY());
            }
        }
        for (int i = 0; i < monsters.size(); i++) {
            Monster currentMonster = monsters.get(i);
            if (currentMonster != null) {
                spriteBatch.draw(currentMonster.getCurrentFrame(), currentMonster.getX(), currentMonster.getY());
            }
        }

        spriteBatch.draw(player.getCurrentFrame(), player.getX(), player.getY());
        font.draw(spriteBatch, "SCORE: " + player.getScore(), -120, 335);
        font.draw(spriteBatch, "BOMBS: " + player.getBombs(), 335, 335);
        spriteBatch.end();
        stage.draw();
    }

    private void handleMonsterSpawning(float delta) {
        monsterTimer += delta;
        if (monstersSpawned == 0) {
            monsters.add(new Monster(9 * TILE_WIDTH, 12 * TILE_HEIGHT,  tiledMap));
            monstersSpawned++;
        }

        if (monsterTimer >= monsterSpawnInterval) {
            monsters.add(new Monster(9 * TILE_WIDTH, 12 * TILE_HEIGHT,  tiledMap));
            monstersSpawned += 1;
            monsterTimer = 0;
        }
        if (monstersSpawned >= lastMonstersSpawned + 10) {
            if (monsterSpawnInterval >= 1) {
                monsterSpawnInterval -= 1;
            }
            else {
                monsterSpawnInterval = 0.8f;
            }
            lastMonstersSpawned = monstersSpawned;
        }
    }

    private void handleKeyboardInput() {
        if (Gdx.input.isKeyPressed(Input.Keys.LEFT)) {
            player.changeDirection(Player.Direction.LEFT);
        }
        else if (Gdx.input.isKeyPressed(Input.Keys.RIGHT)) {
            player.changeDirection(Player.Direction.RIGHT);
        }
        else if (Gdx.input.isKeyPressed(Input.Keys.UP)) {
            player.changeDirection(Player.Direction.UP);
        }
        else if (Gdx.input.isKeyPressed(Input.Keys.DOWN)) {
            player.changeDirection(Player.Direction.DOWN);
        }

        if (Gdx.input.isKeyPressed(Input.Keys.SPACE)) {
            if (!lastFrameSpacebarPressed) {
                player.dropBomb();
            }
            lastFrameSpacebarPressed = true;
        }
        else {
            lastFrameSpacebarPressed= false;
        }
    }

    private void createInputButtons() {
        skin = new Skin(Gdx.files.internal("gui/uiskin.json"));

        leftButton = new TextButton("", skin);
        setButton(leftButton, Color.GRAY, 50f, 50f, 20f, 100f);
        rightButton = new TextButton("", skin);
        setButton(rightButton, Color.GRAY, 50f, 50f, 120f, 100f);
        upButton = new TextButton("", skin);
        setButton(upButton, Color.GRAY, 50f, 50f, 70f, 150f);
        downButton = new TextButton("", skin);
        setButton(downButton, Color.GRAY, 50f, 50f, 70f, 50f);

        bombButton = new TextButton("BOMB", skin);
        setButton(bombButton, Color.GRAY, 100f, 100f, 650f, 300f);
        bombButton.getLabel().setFontScale(1f,1f);

        // Listeners to detect button interaction from user
        leftButton.addListener(new ClickListener() {
            @Override
            public void clicked(InputEvent event, float x, float y) {
                player.changeDirection(Player.Direction.LEFT);
            }
        });
        rightButton.addListener(new ClickListener() {
            @Override
            public void clicked(InputEvent event, float x, float y) {
                player.changeDirection(Player.Direction.RIGHT);
            }
        });
        upButton.addListener(new ClickListener() {
            @Override
            public void clicked(InputEvent event, float x, float y) {
                player.changeDirection(Player.Direction.UP);
            }
        });
        downButton.addListener(new ClickListener() {
            @Override
            public void clicked(InputEvent event, float x, float y) {
                player.changeDirection(Player.Direction.DOWN);
            }
        });
        bombButton.addListener(new ClickListener() {
            @Override
            public void clicked(InputEvent event, float x, float y) {
                player.dropBomb();
            }
        });
        

        stage.addActor(leftButton);
        stage.addActor(rightButton);
        stage.addActor(upButton);
        stage.addActor(downButton);
        stage.addActor(bombButton);

        Gdx.input.setInputProcessor(stage);
    }

    private void loadLevel() {
        tiledMap = new TmxMapLoader().load("level1.tmx");
        tiledMapRenderer = new OrthogonalTiledMapRenderer(tiledMap);
    }

    private void createCamera() {
        camera = new OrthographicCamera();
        camera.setToOrtho(false, Gdx.graphics.getWidth() / 1.37f, Gdx.graphics.getHeight() / 1.37f);
        camera.position.x = (MAP_WIDTH / 2) * TILE_WIDTH + 15;
    }

    private void handleMapObjects() {
        for (int i = 0; i < mapObjects.size(); i++) {
            mapObjects.get(i).handle();
        }
    }

    private void handleMonsters() {
        for (int i = 0; i < monsters.size(); i++) {
            monsters.get(i).handle();
        }
    }

    private void setButton(TextButton button, Color color, float width, float height, float x, float y) {
        button.setColor(color);
        button.setWidth(width);
        button.setHeight(height);
        button.setPosition(x, y);
    }

    @Override
    public void show() {
        Gdx.app.log("GameScreen", "show called");
        create();
    }
    @Override
    public void resize(int width, int height) { }
    @Override
    public void pause() { }
    @Override
    public void resume() { }
    @Override
    public void hide() { }
    @Override
    public void dispose() {
        assets.dispose();
    }
}
