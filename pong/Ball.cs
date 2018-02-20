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
    public class Ball : Sprite
    {

        float speed = 10f;
        private Paddle attachedToPaddle;
        public readonly Rectangle boundaries;

        public Ball(Texture2D texture, Vector2 location, Color color, Rectangle boundaries) : base(texture, location, color)
        {
            this.boundaries = boundaries;
            //velocity = new Vector2(0, -speed);
        }

        public override void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (attachedToPaddle != null)
            {
                Location.X = attachedToPaddle.Location.X + attachedToPaddle.GetWidth()-1;
                Location.Y = attachedToPaddle.Location.Y + attachedToPaddle.GetHeigth() / 2 - texture.Height / 2;
            }
            else
            {
                if (BoundingBox.Intersects(gameObjects.PlayerPaddle.BoundingBox) || BoundingBox.Intersects(gameObjects.ComputerPaddle.BoundingBox))
                    velocity.X = -velocity.X;
            }

            Launch();
            base.Update(gameTime, gameObjects);

            checkBounds();
        }

        public void AttachTo (Paddle paddle)
        {
            attachedToPaddle = paddle;
        }

        public void Launch()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space) && attachedToPaddle != null)
            {
                velocity = new Vector2(15, attachedToPaddle.GetVelocity().Y);
                attachedToPaddle = null;
                
            }
                     
        }

        public void checkBounds()
        {
            Location.Y = MathHelper.Clamp(Location.Y, 0, boundaries.Height - texture.Height);

            if (Location.Y >= (boundaries.Height - texture.Height) || Location.Y <= 0)
                velocity.Y = -velocity.Y;                     
        }
    }
}
