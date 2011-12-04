namespace Descent.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using Descent.Model.Player;
    using Descent.State;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Descent.Messaging.Events;
    using System.Text;

    /// <summary>
    /// A single element of the user interface that, itself, 
    /// can contain sub-elements
    /// </summary>
    /// <author>
    /// Emil Juul Jacobsen
    /// </author>
    public class GUIElement : DrawableGameComponent
    {
        protected static EventManager manager = Player.Instance.EventManager; //TODO: Where to find this?
        protected static Texture2D background;

        public Rectangle Bound { get; set; }

        private string name;
        public string Name { get { return name; } }

        private bool drawBg = false;

        private bool focus;

        private Collection<GUIElement> children;

        private Dictionary<Drawable, Rectangle> visuals;
        protected Collection<Text> texts;
        private Action<EventManager> onClick = null;

        /// <summary>
        /// Creates a GUIElement with the given boundaries.
        /// </summary>
        /// <param name="name">The name of the element</param>
        /// <param name="x">The x-coordinate of the upper-left corner</param>
        /// <param name="y">The y-coordinate of the upper-left corner</param>
        /// <param name="width">The width of the element</param>
        /// <param name="height">The height of the element</param>
        public GUIElement(Game game,string name, int x, int y, int width, int height) : base(game)
        {
            this.name = name;
            this.focus = false;
            Bound = new Rectangle(x, y, width, height);
            children = new Collection<GUIElement>();
            visuals = new Dictionary<Drawable, Rectangle>();
            texts = new Collection<Text>();

            if (background == null) background = game.Content.Load<Texture2D>("boxbg");
        }

        /// <summary>
        /// Checks if the given point is within the boundaries of the GUIElement.
        /// </summary>
        /// <param name="x">The x-coordinate of the point</param>
        /// <param name="y">The y-coordinate of the point</param>
        /// <returns></returns>
        public bool HasPoint(int x, int y)
        {
            return Bound.Contains(x, y);
        }

        /// <summary>
        /// Tells if the element handled the last click request.
        /// </summary>
        /// <returns>True if focused, else false.</returns>
        public virtual bool HasFocus()
        {
            return this.focus;
        }

        /// <summary>
        /// Determines if a click is within the GUIElement and acts
        /// upon the click if possible.
        /// </summary>
        /// <param name="x">The x-coordinate of the click</param>
        /// <param name="y">The y-coordinate of the click</param>
        public virtual bool HandleClick(int x, int y)
        {
            // is it within me
            if (this.HasPoint(x, y))
            {
                // is it within any of my children
                foreach (GUIElement e in children)
                {
                    if (e.HandleClick(x, y))
                    {
                        focus = false;
                        return true;
                    }
                }

                // ok, its within me, ill handle it!
                if (onClick != null)
                {
                    onClick(manager);
                }
                focus = true;
                return true;
            }
            else
            {
                // nope, wasnt me :(
                focus = false;
                return false;
            }
        }

        /// <summary>
        /// Reacts to the given key type if this GUIElement
        /// is focused.
        /// </summary>
        /// <param name="key">The key that has been pressed and wasn't pressed before</param>
        public virtual void HandleKeyPress(Keys key)
        {
            foreach (GUIElement e in children) e.HandleKeyPress(key);
            // this method can be overwritten if a GUIElement wants to react to keypresses.
        }

        /// <summary>
        /// Replace (if any) the current On Click action with
        /// the one given.
        /// </summary>
        /// <param name="action">The new On Click action</param>
        public void AddClickAction(string target, Action<EventManager> action)
        {
            if (this.name == target)
            {
                this.onClick = action;
            }
            foreach (GUIElement e in children) e.AddClickAction(target, action);
        }

        /// <summary>
        /// Adds the given GUIElement to the set of children within
        /// this one.
        /// </summary>
        /// <param name="child">The new child</param>
        public void AddChild(GUIElement child)
        {
            children.Add(child);
        }

        /// <summary>
        /// Add the drawable to be displayed at the given position
        /// in this GUIElement.
        /// </summary>
        /// <param name="visual">The drawable to display</param>
        /// <param name="position">Where the upper-left corner of the drawable should be</param>
        public void AddDrawable(string target, Drawable visual, Vector2 position)
        {
            if (Name == target)
            {
                visuals.Add(visual, new Rectangle((int)position.X,(int)position.Y,visual.Texture.Width,visual.Texture.Height));
            }
            foreach (GUIElement e in children) e.AddDrawable(target, visual, position);
        }

        /// <summary>
        /// Adds the given string to be drawn on the screen on all children (or this)
        /// with the target name.
        /// </summary>
        /// <param name="target">Only GUIElements with this name should display the text.</param>
        /// <param name="text">The text to be drawn to the screen.</param>
        /// <param name="position">Where the upper-left corner of the text should be</param>
        public void AddText(string target, string text, Vector2 position)
        {
            if (Name == target)
            {
                texts.Add(new Text(WordWrap(text, position), new Vector2(position.X + Bound.X, position.Y + Bound.Y)));
            }
            foreach (GUIElement e in children) e.AddText(target, text, position);
        }

        /// <summary>
        /// Word Wraps the given string so when displayed at the given
        /// position, it will not draw outside the width of the GUIElement.
        /// If too long, the text will however draw outside the bottom
        /// of the box.
        /// </summary>
        /// <param name="text">The text to word wrap</param>
        /// <param name="position">Where the upper-left corner of the drawable should be</param>
        /// <returns>A string with linebreaks so the text will be drawn correctly.</returns>
        protected string WordWrap(string text, Vector2 position)
        {
            int wordsIndex = 0;
            string[] words = text.Split();
            StringBuilder builder = new StringBuilder();

            string currentLine = "";
            string nextWord;
            while (wordsIndex < words.Length)
            {
                nextWord = words[wordsIndex]+" ";

                if (FontHolder.Font.MeasureString(currentLine + nextWord).X < Bound.Width) // word fits
                {
                    currentLine += nextWord;
                    wordsIndex++;
                }else if (FontHolder.Font.MeasureString(nextWord).X > Bound.Width) // cut word
                {
                    int end = nextWord.Length -1;
                    while (FontHolder.Font.MeasureString(currentLine + nextWord.Substring(0, end) + "-").X > Bound.Width) // see what we have space for
                    {
                        end--;
                    }
                    builder.Append(currentLine + nextWord.Substring(0, end)+"-\n"); // add what we had space for
                    currentLine = "";
                    words[wordsIndex] = words[wordsIndex].Substring(end, words[wordsIndex].Length - end); // let the remaining be
                    
                }else// word doesn't fit, bit is not too long
                {
                    builder.Append(currentLine+"\n");
                    currentLine = "";
                }
                
            }
            builder.AppendLine(currentLine);

            return builder.ToString().Trim();
        }

        /// <summary>
        /// Makes the current GUIElement draw a background beneath itself.
        /// </summary>
        /// <param name="toDraw">True if the current GUIElement should draw background</param>
        public void SetDrawBackground(bool toDraw)
        {
            drawBg = toDraw;
        }

        /// <summary>
        /// Draws this GUIElement and then all children on top of it
        /// </summary>
        /// <param name="draw">The SpriteBatch to draw on</param>
        public virtual void Draw(SpriteBatch draw)
        {
            // draw my own background
            if (drawBg)
            {
                draw.Draw(background, Bound, Color.White);
            }

            // draw my own "pictures"
            foreach (Drawable d in visuals.Keys) draw.Draw(d.Texture, visuals[d], Color.White);

            // draw my own text
            foreach (Text t in texts)
            {
                draw.DrawString(FontHolder.Font, t.Line, t.Position, Color.Black);
            } 

            // draw the children on top
            foreach (GUIElement e in children) e.Draw(draw);
        }
    }
}
