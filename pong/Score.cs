using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong
{
    public class Score
    {
        private readonly SpriteFont font;
        private readonly Rectangle gameBoundaries;

        public int PlayerScore { get; set; }
        public int ComputerScore { get; set; }

        public Score(SpriteFont font, Rectangle gameBoundaries)
        {
            this.font = font;
            this.gameBoundaries = gameBoundaries;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            var scoreText = string.Format("{0}:{1}", PlayerScore, ComputerScore);
            var xPosition = gameBoundaries.Width / 2 - (font.MeasureString(scoreText).X / 2);
            var yPosition = gameBoundaries.Height - 80;
            var position = new Vector2(xPosition, yPosition);

            spriteBatch.DrawString(font, scoreText, position, Color.Black);
        }

        public void Update(GameTime gameTime, GameObjects gameObjects)
        {
            if (gameObjects.Ball.Location.X + gameObjects.Ball.GetWidth() < 0)
            {
                ComputerScore++;
                gameObjects.Ball.velocity = new Vector2(0, 0);
                gameObjects.Ball.AttachTo(gameObjects.PlayerPaddle);
            }
            if(gameObjects.Ball.Location.X > gameObjects.Ball.boundaries.Width)
            {
                PlayerScore++;
                gameObjects.Ball.velocity = new Vector2(0, 0);
                gameObjects.Ball.AttachTo(gameObjects.PlayerPaddle);                    
            }
        }
    }
}
