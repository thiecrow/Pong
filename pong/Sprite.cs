using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Sprite
    {
        protected readonly Texture2D texture;
        public Vector2 Location;
        public int Width;
        public int Heigth;
        public Vector2 velocity = Vector2.Zero;
        protected Color color;

        public Sprite(Texture2D texture, Vector2 location, Color color)
        {
            this.texture = texture;
            Location = location;
            this.color = color;
        }

        public int GetWidth()
        { return texture.Width; }

        public int GetHeigth()
        {
            return texture.Height;
        }

        public Vector2 GetVelocity()
        {
            return velocity;
        }
        public Rectangle BoundingBox
        {
            get
            {
                return new Rectangle((int)Location.X, (int)Location.Y, GetWidth(), GetHeigth());
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture,Location,color);
        }

        public virtual void Update(GameTime gameTime, GameObjects gameObjects)
        {
            Location += velocity;
                       
        }
    }
}
