using System;
using Microsoft.Xna.Framework;

namespace Nodegame
{
    internal class Basic : INode
    {
        private Owner owner; 
        private double Health;
        private Vector2 pos;

        public Basic(Owner o, Vector2 p) {
            owner = o;
            pos = p;
        }
        public Basic(Vector2 p): this(Owner.Enemy, p) {}
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
            return NodeType.Basic;
        }

        public void setOwner(Owner o)
        {
            owner = o;
        }
    }
}