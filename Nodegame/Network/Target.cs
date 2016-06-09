using System;
using Microsoft.Xna.Framework;

namespace Nodegame
{
    internal class Target : INode
    {
        private Owner owner;
        private Vector2 pos;

        public Target(Owner owner, Vector2 position)
        {
            this.owner = owner;
            this.pos = position;
        }

        public Owner getOwner()
        {
            return owner; 
        }

        public Vector2 getPosition()
        {
            return pos;
        }

        public NodeType getType()
        {
            return NodeType.Target;
        }

        public void setOwner(Owner o)
        {
            this.owner = o;
        }
    }
}