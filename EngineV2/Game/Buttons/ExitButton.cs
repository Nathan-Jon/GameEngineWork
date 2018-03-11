using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Managers;
using Engine.Interfaces;

namespace ProjectHastings.Buttons
{
    /// <summary>
    /// Class to Create and update the Exit button.
    /// 
    /// Author: Carl Chalmers
    /// Date of change: 04/03/18
    /// Version 0.5
    /// 
    /// </summary>
    class ExitButton : IButton
    {
        #region Variables
        //Create a variable of type Texture2D and call it Texture
        public Texture2D Texture;
        //Create a variable of type Vector2 and call it Position
        public static Vector2 Position;
        //Create a variable of type Rectangle and call it Hitbox, make it a get/set. 
        public Rectangle HitBox { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Create a method called Initialize which will be passed varibales of type Vector2 and Texture2D,
        /// call them Posn and tex.
        /// This method will set the position and the texture of this class with the varibale that are being passed through.
        /// </summary>
        public void Initialize(Texture2D tex, Vector2 Posn)
        {
            Texture = tex;
            Position = Posn;
        }

        /// <summary>
        /// Draws the entity using the classes texture and position  
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.AntiqueWhite);

        }
        /// <summary>
        /// Create a method called update, which will update the hitbox variable.
        /// </summary>
        public void update()
        {
            HitBox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
        }

        /// <summary>
        /// Create a method called Click, which will be called when the buttons recieves input from the mouse.
        /// </summary>
        public void click()
        {
            SceneManager.ExitGame = true;
        }
        #endregion

    }
}
