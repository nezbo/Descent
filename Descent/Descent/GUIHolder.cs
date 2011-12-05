using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

namespace Descent
{
    public class GUIHolder
    {
        public static SpriteFont Font { get; set; }

        private static Dictionary<string, string> inputs = new Dictionary<string, string>();

        public static string GetInputFrom(string key)
        {
            if (inputs.ContainsKey(key))
            {
                return inputs[key];
            }
            return "";
        }

        public static void SetInput(string key, string input)
        {
            inputs[key] = input;
        }
    }
}
