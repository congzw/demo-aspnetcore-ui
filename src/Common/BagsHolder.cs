using System;
using System.Collections.Generic;

namespace Common
{
    public class BagsHolder
    {
        public IDictionary<string, object> GetBag(string bagName, bool createIfNotExist = false)
        {
            if (AllBags.ContainsKey(bagName))
            {
                return (IDictionary<string, object>)AllBags[bagName];
            }

            if (!createIfNotExist)
            {
                return null;
            }

            var dictionary = BagsHelper.Create();
            AllBags[bagName] = dictionary;
            return dictionary;
        }
        public IDictionary<string, object> AllBags { get; set; } = BagsHelper.Create();

        #region for extensions

        private static readonly Lazy<BagsHolder> _lazy = new Lazy<BagsHolder>(() => new BagsHolder());
        public static Func<BagsHolder> Resolve { get; set; } = () => ServiceLocator.Current.GetService<BagsHolder>() ?? _lazy.Value;

        #endregion
    }
}