using System.Collections.Generic;
using Engine.Interfaces;

namespace Engine.Buttons
{
    /// <summary>
    /// Class to store buttons within a list
    /// 
    /// Author: Carl Chalmers
    /// Date of change: 04/03/18
    /// Version 0.5
    /// 
    /// </summary>
    public class ButtonList
    {
        #region Variables

        public static List<IButton> Buttons = new List<IButton>();

        #endregion

        #region Methods

        public void Initalize(IButton but)
        {
            Buttons.Add(but);
        }

        #endregion

    }
}
