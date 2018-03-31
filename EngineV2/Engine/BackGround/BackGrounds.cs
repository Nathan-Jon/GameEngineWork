using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Engine.Interfaces;

/// <summary>
/// Class to Create and store backgrounds
/// 
/// Author: Carl Chalmers
/// Date of change: 04/03/18
/// Version 0.5
/// 
/// </summary>
namespace Engine.BackGround
{
    public class BackGrounds :IBackGrounds
    {
        #region Variables

        //Create a dictionary to store the background, set the key to type string and value to type Texture2D
        public static IDictionary<string, Texture2D> Backgrounds = new Dictionary<string, Texture2D>();
        //Create a variable of type rectangle, which will be used to store the height and width of the background.
        public Rectangle Size;
        //Create a variable of type string which will store the current background that is being drawn.
        string BackGround;

        #endregion

        #region Methods

        public BackGrounds(int width, int height)
        {
            Size = new Rectangle(0, 0, width, height); 
        }

        /// <summary>
        /// Create a method called Initialize which will be passed varibales of type string and Texture2D,
        /// call them BackgroundName and Texture.
        /// This method will add the backgrounds to the backgrounds dictionary and store the current background 
        /// that is being drawn. 
        /// </summary>
        public void Initialize(string BackgroundName, Texture2D Texture)
        {
            Backgrounds.Add(BackgroundName, Texture);
            BackGround = BackgroundName;
        }

        /// <summary>
        /// Draws the entity based on the texture that is selected in the dictionary and the size that has been 
        /// given to the background when it was initalized
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Backgrounds[BackGround], Size, Color.AntiqueWhite);   
        }
        #endregion
    }
}
