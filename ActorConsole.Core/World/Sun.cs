﻿using ActorConsole.Core.Json.TinyJson;
using AnotherExternalMemoryLibrary.Extensions;
using System.Collections.Generic;

namespace ActorConsole.Core.World
{
    /// <summary>
    /// A class containing properties for all aspects of the sun in game.
    /// </summary>
    public static class Sun
    {
        /// <summary>
        /// Ranges from 0 ... 2 typically.
        /// The green channel.
        /// </summary>
        public static float Blue
        {
            get => Memory.IW4.Game.Read<float>(Memory.Addresses.Sun.Blue);
            set => Memory.IW4.Game.Write(Memory.Addresses.Sun.Blue, value);
        }

        /// <summary>
        /// Ranges from 0 ... 2 typically.
        /// The blue channel.
        /// </summary>
        public static float Green
        {
            get => Memory.IW4.Game.Read<float>(Memory.Addresses.Sun.Green);
            set => Memory.IW4.Game.Write(Memory.Addresses.Sun.Green, value);
        }

        /// <summary>
        /// Ranges from 0 ... 2 typically.
        /// The red channel.
        /// </summary>
        public static float Red
        {
            get => Memory.IW4.Game.Read<float>(Memory.Addresses.Sun.Red);
            set => Memory.IW4.Game.Write(Memory.Addresses.Sun.Red, value);
        }

        /// <summary>
        /// Ranges from 0 ... 2 typically.
        /// The x position.
        /// </summary>
        public static float X
        {
            get => Memory.IW4.Game.Read<float>(Memory.Addresses.Sun.X);
            set => Memory.IW4.Game.Write(Memory.Addresses.Sun.X, value);
        }

        /// <summary>
        /// Ranges from 0 ... 2 typically.
        /// The y position.
        /// </summary>
        public static float Y
        {
            get => Memory.IW4.Game.Read<float>(Memory.Addresses.Sun.Y);
            set => Memory.IW4.Game.Write(Memory.Addresses.Sun.Y, value);
        }

        /// <summary>
        /// Ranges from 0 ... 2 typically.
        /// The z position.
        /// </summary>
        public static float Z
        {
            get => Memory.IW4.Game.Read<float>(Memory.Addresses.Sun.Z);
            set => Memory.IW4.Game.Write(Memory.Addresses.Sun.Z, value);
        }

        /// <summary>
        /// Reads all properties of the a sun json and set them to each property in this class.
        /// </summary>
        /// <param name="rawJson">The raw json string.</param>
        public static void LoadJson(string rawJson)
        {
            foreach (KeyValuePair<string, float> field in rawJson.FromJson<Dictionary<string, float>>())
            {
                System.Reflection.PropertyInfo prop = typeof(Sun).GetProperty(field.Key, System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
                prop.SetValue(null, field.Value);
            }
        }

        /// <summary>
        /// Deserializes all the properties into a json.
        /// </summary>
        /// <returns>The raw json string of all the properties.</returns>
        public static new string ToString()
        {
            return new { Red, Green, Blue, X, Y, Z }.ToJson();
        }
    }
}
