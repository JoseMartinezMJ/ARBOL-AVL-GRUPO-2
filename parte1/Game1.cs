using Entregable1.Boton;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Entregable1
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private SpriteFont _spriteFont;
        DibujarAVL arbolAVL = new DibujarAVL(null);
        DibujarAVL arbolAVL_Letra = new DibujarAVL(null);
        Conexion conexion = new Conexion();

        public static int ScreenWidth = 1280;
        public static int ScreenHeight = 720;
        private Color _backgroundColour = Color.DarkGray;
        private List<Component> _gameComponents;
        private int[] NumAleatorio;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = ScreenWidth;
            _graphics.PreferredBackBufferHeight = ScreenHeight;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _spriteFont = Content.Load<SpriteFont>("Font");


            var btnInsertar = new Button(Content.Load<Texture2D>("Button"), Content.Load<SpriteFont>("File"))
            {
                Position = new Vector2(40, 40),
                Text = "Insertar"
            };

            btnInsertar.Click += btnInsertarClick;


            var btnBuscar = new Button(Content.Load<Texture2D>("Button"), Content.Load<SpriteFont>("File"))
            {
                Position = new Vector2(40, 80),
                Text = "Buscar"
            };

            btnBuscar.Click += btnBuscarClick;


            var btnInorden = new Button(Content.Load<Texture2D>("Button"), Content.Load<SpriteFont>("File"))
            {
                Position = new Vector2(40, 120),
                Text = "InOrden"
            };

            btnInorden.Click += btnInordenClick;


            var btnPreOrden = new Button(Content.Load<Texture2D>("Button"), Content.Load<SpriteFont>("File"))
            {
                Position = new Vector2(40, 160),
                Text = "PreOrden"
            };

            btnPreOrden.Click += btnPreOrdenClick;


            var btnPostOrden = new Button(Content.Load<Texture2D>("Button"), Content.Load<SpriteFont>("File"))
            {
                Position = new Vector2(40, 200),
                Text = "PostOrden"
            };

            btnPostOrden.Click += btnPostOrdenClick;

            _gameComponents = new List<Component>()
                {
                    btnInsertar,
                    btnBuscar,
                    btnInorden,
                    btnPreOrden,
                    btnPostOrden
                };
        }

        //Aqui va el codigo para que inserte un nuevo valor aleatorio, para --> Antonio
        private void btnInsertarClick(object sender, System.EventArgs e)
        {

            conexion.Conectar();
            NumAleatorio = new int[11];
            var seed = Environment.TickCount;
            var random = new Random(seed);
            var value = random.Next(1, 11);
            arbolAVL.Insertar(value);
            conexion.InsertarBasedatos(value);



        }

        //Aqui va el codigo para que buscar un nuevo valor, para --> Alex
        private void btnBuscarClick(object sender, System.EventArgs e)
        {
            var random = new Random();

        }

        //Aqui va el codigo para que muestre el orden PreOrden, para --> Alex
        private void btnPreOrdenClick(object sender, System.EventArgs e)
        {
            var random = new Random();

        }

        //Aqui va el codigo para que muestre el orden InOrden, para --> Alisson
        private void btnInordenClick(object sender, System.EventArgs e)
        {
            var random = new Random();

        }

        //Aqui va el codigo para que muestre el orden PostOrden, para --> Alisson
        private void btnPostOrdenClick(object sender, System.EventArgs e)
        {
            var random = new Random();

        }



        protected override void Update(GameTime gameTime)
        {
           if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
               Exit();

            foreach (var component in _gameComponents)
                component.Update(gameTime);


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_backgroundColour);

            _spriteBatch.Begin();

            arbolAVL.DibujarArbol(_graphics, _spriteBatch, 20, _spriteFont);

            foreach (var component in _gameComponents)
                component.Draw(gameTime, _spriteBatch);


            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}