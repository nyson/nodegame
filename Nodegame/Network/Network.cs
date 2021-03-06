﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Nodegame
{
    internal class Network
    {
        List<INode> nodes;
        Texture2D basicTexture;
        Texture2D hostTexture; 
        Texture2D targetTexture;
        SpriteFont font;

        public Network() {
            nodes = defaultNetwork();
        }

        public void initializeGraphics(GraphicsDeviceManager graphics, ContentManager cm) {
            basicTexture  = cm.Load<Texture2D>("Graphics\\ascreen");
            hostTexture   = cm.Load<Texture2D>("Graphics\\ascreen");
            targetTexture = cm.Load<Texture2D>("Graphics\\ascreen");
            font = cm.Load<SpriteFont>("Fonts\\Amosis");
        }

        public void draw(SpriteBatch spriteBatch) {
            foreach(INode n in nodes) {
                drawNode(n, spriteBatch);
            }
        }

        private void drawNode(INode n, SpriteBatch spriteBatch) {
            var p = n.getPosition();
            var ownerTextPos = p;
            var typeTextPos = p;
            // owner text should be above node
            ownerTextPos.Y -= 20;
            typeTextPos.Y += 64;

            Console.WriteLine("texture vector: " + p);
            if (n.getOwner() == Owner.Player)
            {
                spriteBatch.DrawString(font, "Player", ownerTextPos, Color.Red);
            }
            else
            {
                spriteBatch.DrawString(font, "Enemy", ownerTextPos, Color.Red);
            }


            switch (n.getType()) {
                case NodeType.Basic:
                    spriteBatch.DrawString(font, "Basic", typeTextPos, Color.Red);
                    spriteBatch.Draw(basicTexture, p);
                    break;

                case NodeType.Host:
                    spriteBatch.DrawString(font, "Host", typeTextPos, Color.Red);
                    spriteBatch.Draw(hostTexture, p);
                    break;

                case NodeType.Target:
                    spriteBatch.DrawString(font, "Target", typeTextPos, Color.Red);
                    spriteBatch.Draw(targetTexture, p);
                    break;

            }
        }

        private List<INode> defaultNetwork() {
            var nodes = new List<INode>();  
            
            nodes.Add(new Basic(Owner.Enemy, new Vector2(300, 300)));
            nodes.Add(new Host(Owner.Player, new Vector2(100, 300)));
            nodes.Add(new Target(Owner.Enemy, new Vector2(300, 100)));
            return nodes;
        }
    }
}