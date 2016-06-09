using Microsoft.Xna.Framework;

namespace Nodegame
{
    public enum NodeType {Host, Basic, Target};
    public enum Owner {Player, Enemy};
    internal interface INode
    {
        Vector2 getPosition();
        NodeType getType();
        void setOwner(Owner o);
        Owner getOwner();
    }

}