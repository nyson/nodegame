using System;
using Microsoft.Xna.Framework;

namespace Nodegame
{
    internal class Host : INode
    {
        private Owner owner;
        private Vector2 pos;
        

        public Host(Owner owner, Vector2 pos)
        {
            this.owner = owner;
            this.pos = pos;
        }

        public Owner getOwner()
        {
            return this.owner;
        }

        public Vector2 getPosition()
        {
            return pos;
        }

        public NodeType getType()
        {
            return NodeType.Host;
        }

        public void setOwner(Owner o)
        {
            this.owner = o;
        }
    }
}