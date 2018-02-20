using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
    public enum PlayerTypes
    {
        Human,
        Computer
    }

    public class Paddle : Sprite
    {
        private readonly Rectangle boundaries;
        private readonly PlayerTypes playerType;
        float speed = 10f;
      

        public Paddle(Texture2D texture, Vector2 location,Color color,Rectangle boundaries, PlayerTypes playerType) : base(texture, location,color)
        {
            this.boundaries = boundaries;
            this.playerType = playerType;
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if(playerType == PlayerTypes.Computer)
            {
                if (gameObjects.Ball.Location.Y + gameObjects.Ball.GetHeigth() / 2 > gameObjects.ComputerPaddle.Location.Y + gameObjects.ComputerPaddle.GetHeigth() / 2 + 50)
                    velocity = new Vector2(0, speed);
                else if (gameObjects.Ball.Location.Y + gameObjects.Ball.GetHeigth() / 2 < gameObjects.ComputerPaddle.Location.Y + gameObjects.ComputerPaddle.GetHeigth() / 2 - 50)
                    velocity = new Vector2(0, -speed);
                else
                    velocity = new Vector2(0, 0);
            }
            if (playerType == PlayerTypes.Human)
            {
                //Move paddle up
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                    velocity = new Vector2(0, -speed);

                //move paddle down
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                    velocity = new Vector2(0, speed);

                //stop paddle when no input
                if (Keyboard.GetState().IsKeyUp(Keys.Up) && Keyboard.GetState().IsKeyUp(Keys.Down))
                    velocity = new Vector2(0, 0);
            }

            base.Update(gameTime,gameObjects);

            checkBounds();
        }

        public void checkBounds()
        {
            Location.Y = MathHelper.Clamp(Location.Y, 0, boundaries.Height - texture.Height);
        }

    }
}
