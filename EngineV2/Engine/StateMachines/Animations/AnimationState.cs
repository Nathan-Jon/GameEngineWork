using System;
using System.Collections.Generic;
using System.Dynamic;
using Engine.Animations;
using Engine.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.StateMachines.Animations
{
    public class AnimationState : IAnimationState
    {
        //Int of Current Frame in Animation
        public int CurrentFrame { get; private set; }
        //In for the FrameRate of the Animation
        public float FrameRate { get; private set; }
        //float for the Speed of the Animation - <0 plays backwards >0 plays forwards
        public float AnimationSpeed { get; private set; }
        //Animation Variables
        public Texture2D SpriteSheet { get; private set; }
        public int TargetRow { get; private set; }
        public int TargetColumn { get; private set; }

        /// <summary>
        /// Initialise a SpriteSheet Animation state
        /// </summary>
        /// <param name="fps"></param>
        public AnimationState(Texture2D animation, int fps, int targetRow, int targetColumn)
        {
            //Perform a null check on the animation
            if (animation != null)
                //Set the SpriteSheet variable to animation
                SpriteSheet = animation;
            else { throw new Exception("SpritesheetAnimation is Null"); }

            //Initialise Rows and ColumnsVariables
            TargetRow = targetRow;
            TargetColumn = targetColumn;

            //Set the Animation speed of the animation
            FrameRate = 1f / fps;

            //Initialise the current Frame
            CurrentFrame = 0;
        }

        /// <summary>
        /// Initialise a SpriteSheet Animation state and animation speed 
        /// </summary>
        /// <param name="animationSpeed"></param>
        /// <param name="fps"></param>
        public AnimationState(Texture2D animation, int fps, int targetRow, int targetColumn, float animationSpeed)
        {
            //Perform a null check on the animation
            if (animation != null)
                //Set the SpriteSheet variable to animation
                SpriteSheet = animation;
            else { throw new Exception("SpritesheetAnimation is Null"); }

            //Initialise Rows and ColumnsVariables
            TargetRow = targetRow;
            TargetColumn = targetColumn;

            //Set the Animation speed of the animation
            FrameRate = animationSpeed / fps;
            //Store the AnimationSpeed Variable
            AnimationSpeed = animationSpeed;
            //Set the Initialise currentframe variable
            CurrentFrame = 0;
        }

        /// <summary>
        /// Initialise a SpriteSheet Animation state and Starting frame
        /// </summary>
        /// <param name="animationSpeed"></param>
        /// <param name="fps"></param>
        /// <param name="currentFrame"></param>
        public AnimationState(Texture2D animation, int fps, int targetRow, int targetColumn, float animationSpeed, int currentFrame)
        {

            //Perform a null check on the animation
            if (animation != null)
                //Set the SpriteSheet variable to animation
                SpriteSheet = animation;
            else { throw new Exception("SpritesheetAnimation is Null"); }

            //Initialise Rows and ColumnsVariables
            TargetRow = targetRow;
            TargetColumn = targetColumn;

            //Set the Animation speed of the animation
            FrameRate = animationSpeed / fps;
            //Store the AnimationSpeed Variable
            AnimationSpeed = animationSpeed;
            //Set the Initialise currentframe variable
            CurrentFrame = currentFrame;
        }



        /// <summary>
        /// Reverts the Current Frame Variable to 0
        /// </summary>
        public void ResetAnimation()
        {
            CurrentFrame = 0;
        }

        #region Animation

        /*
        #region Variables
        //Create Intergers called _width and _height that will store the height and width of the animation
        public static int _width, _height;
        //Create Intergers called CurrentFrame and totalFrames that will store.
        private int _currentFrame, _totalFrames;
        //Create an Interger called _timeSinceLatFrame that will store how long it has been since last frame, set it to 0.
        private int _timeSinceLastFrame = 0;
        //Create an Interger called _millisecondsPerFrame that stores how many milliseconds there will be between each frame, set it to 200.
        private int _millisecondsPerFrame = 200;
        //Create Intergers called _rows, _columns that will store how many rows and columns are in the spritesheet.
        private int _rows, _columns;
        //Create Intergers called _row, _column that will store which row and column is needed for a specific animation.
        private int _row, _column;
        //Create a variable of type IEntity called entity that will store object of type IEntity.
        public IEntity entity;
        //Create a variable of type Rectangle called sourceRectangle which will store information on what part of the spritesheet to look at for the animation.
        // Create a variable of type Rectangle called destinationRectangle which will store information on where sourceRectangle will be created.
        private Rectangle sourceRectangle, destinationRectangle;

        #endregion

        #region Methods
        /// <summary>
        /// Create a method called Initialize that gets passed variables of types IEntity, INTS and then stores then with in other variables.
        /// </summary>

        public void Initialize(IEntity ent, int rows, int columns)
        {
            entity = ent;
            _columns = columns;
            _rows = rows;
        }

        /// <summary>
        /// Create a method called Update that gets passed a variable of type GameTime.
        /// This method updates the animation frames. 
        /// </summary>
        public void Update(GameTime gameTime)
        {
            //Set _timeSinceLastFrame += milliseconds generated by gametime.
            _timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;

            //Create an If the check to see if _timeSinceLastFrame > _millisecondsPerFrame.
            if (_timeSinceLastFrame > _millisecondsPerFrame)
            {
                //Set _timeSinceLastFrame -= _millisecondsPerFrame.
                _timeSinceLastFrame -= _millisecondsPerFrame;


                _currentFrame++;

                //Create an If Statment to check if the current frames is == to the total frames (_currentFrame == _totalFrames) 
                //if so set current frames to 0.
                if (_currentFrame == _totalFrames)
                {
                    _currentFrame = 0;
                }
            }

        }

        /// <summary>
        /// Create a method called Draw that gets passed a variable of type SpriteBatch.
        /// This method will draw the animation frames. 
        /// </summary>
        public void Draw(SpriteBatch spriteBatch)
        {

            //Assign _width variable with the correct width of one of the images with in the spritesheet. 
            //Do this by getting the texture width and divide it by the amount of columns the spritesheet has.
            _width = entity.Texture.Width / _columns;
            //Assign _height variable with the correct height of one of the images with in the spritesheet. 
            //Do this by getting the texture height and divide it by the amount of rows the spritesheet has.
            _height = entity.Texture.Height / _rows;
            //Assign _row variable the row that wants to be shown in the animation.
            _row = entity.getRows();
            //Assign _column variable the columns that are going to be shown in the animation.
            _column = _currentFrame % _columns;

            //Create a new rectangle and assign it to the sourceRectangle variable.
            //The rectangle will hold all the information it need to create a rectangle around the image on the spritesheet.
            sourceRectangle = new Rectangle(_width * _column, _height * _row, _width, _height);
            //Create a new rectangle and assign it to the destinationRectangle variable.
            //The rectangle will hold all the information it needs for where the animations is going to be created.
            destinationRectangle = new Rectangle((int)entity.Position.X, (int)entity.Position.Y, _width, _height);
            //Call the Draw method from the spritebatch method and assign it the correct parameters need to draw the animations.
            spriteBatch.Draw(entity.Texture, destinationRectangle, sourceRectangle, Color.White);

        }

        #endregion
        */

        #endregion
    }
}
