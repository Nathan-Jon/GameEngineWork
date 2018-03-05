using System.Collections.Generic;
using EngineV2.Interfaces;

namespace EngineV2.Buttons
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

        public static List<IButton> menuButtons= new List<IButton>();

        #endregion

        #region Methods

        public void Initalize(IButton but)
        {
            menuButtons.Add(but);
        }

        #endregion

    }
}
