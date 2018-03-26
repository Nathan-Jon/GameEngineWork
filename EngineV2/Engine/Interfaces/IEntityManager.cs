using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Engine.Interfaces
{
    /// <summary>
    /// 
    /// Interface for Entity Manager Factory
    /// Author: Nathan Robertson
    /// Edit Date: 03/02/18
    /// Version 0.5
    /// 
    /// </summary>
    public interface IEntityManager
    {
        T CreateEnt<T>(Texture2D text, Vector2 Posn, ICollidable col, IBehaviourManager IBehave) where T : IEntity, new();    
    }
}
