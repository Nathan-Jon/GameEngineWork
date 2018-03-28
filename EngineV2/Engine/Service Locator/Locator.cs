using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine.Interfaces;

namespace Engine.Service_Locator
{
    public class Locator
    {
    #region Variables
        //Create a variable called "instance", which is the single instance of the class.
        private static Locator instance = null;

        //Create a dictionary call providers which has a key of type and value of IProvider.
        private IDictionary<Type, IProvider> providers;
        #endregion

        #region Methods

        public static Locator Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Locator();
                }

                return instance;
            }
        }

        private Locator()
        {
            providers = new Dictionary<Type, IProvider>();
        }

        public IProvider getProvider<T>() where T : IProvider, new()
        {
            if (!providers.ContainsKey(typeof(T)))
            {
                providers.Add(typeof(T), new T());
            }

            return providers[typeof(T)];
    }

        #endregion

    }
}
