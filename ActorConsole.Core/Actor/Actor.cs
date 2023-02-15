﻿using ActorConsole.Core.Actor.Attributes;

namespace ActorConsole.Core.Actor
{
    /// <summary>
    /// Main controller class that holds all the attibutes of an actor.
    /// </summary>
    public sealed class Actor
    {
        internal static int Amount = 1;
        private string _Name;

        /// <summary>
        /// Name of the actor in game.
        /// </summary>
        public string Name
        {
            get => _Name;
            set
            {
                if (_Name != null)
                    Memory.IW4.SendDvar($"mvm_actor_rename {_Name} {value}");
                _Name = value;
                Manager.RaiseOnActorAttributeModified(this);
            }
        }

        /// <summary>
        /// Anims Attribute
        /// </summary>
        public Anims Anims { get; private set; }

        /// <summary>
        /// Models Attribute
        /// </summary>
        public Models Models { get; private set; }

        /// <summary>
        /// Weapons Attribute
        /// </summary>
        public Weapons Weapons { get; private set; }

        /// <summary>
        /// Walking Attribute
        /// </summary>
        public Walking Walking { get; private set; }

        /// <summary>
        /// Pathing Attribute
        /// </summary>
        public Pathing Pathing { get; private set; }

        /// <summary>
        /// Constructor, is marked internal because actors should be created through the static Manager class.
        /// </summary>
        internal Actor()
        {
            Memory.IW4.SendDvar($"mvm_actor_spawn {Models.BODY_DEFAULT} {Models.HEAD_DEFAULT}");
            Anims = new Anims(this);
            Models = new Models(this);
            Weapons = new Weapons(this);
            Pathing = new Pathing(this);
            Walking = new Walking(this);

            Name = $"actor{Amount}";

            Amount++;
        }

        /// <summary>
        /// Removes actor from the game and unlinks attributes from actor class.
        /// </summary>
        internal void Delete()
        {
            Weapons.NullAllBones();
            Anims = null;
            Models = null;
            Weapons = null;
            Walking = null;
            Pathing = null;
            Memory.IW4.SendDvar($"mvm_actor_delete {Name}");
        }

        /// <summary>
        /// Moves the actor to the current position of the player in game.
        /// </summary>
        public void MoveToCurrentPostition()
        {
            Memory.IW4.SendDvar($"mvm_actor_move {Name}");
        }
    }
}