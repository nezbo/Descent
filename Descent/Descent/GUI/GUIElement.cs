namespace Descent.GUI
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics.Contracts;
    using System.Linq;
    using System.Text;
    using Descent.Messaging.Events;
    using Descent.Model.Player;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;

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
        protected static Texture2D defaultBG;

        public Rectangle Bound { get; set; }

        private string name;
        public string Name { get { return name; } }

        private bool drawBg = true;
        private Texture2D background = null;
        private SpriteFont font = null;
        public SpriteFont Font { get { return font ?? GUI.Font; } }

        private bool focus;

        protected Collection<GUIElement> children;

        private Dictionary<Drawable, Rectangle> visuals;
        protected Collection<Text> texts;
        private Action<Player, GUIElement> onClick = null;

        /// <summary>
        /// Creates a GUIElement with the given boundaries.
        /// </summary>
        /// <param name="name">The name of the element</param>
        /// <param name="x">The x-coordinate of the upper-left corner</param>
        /// <param name="y">The y-coordinate of the upper-left corner</param>
        /// <param name="width">The width of the element</param>
        /// <param name="height">The height of the element</param>
        public GUIElement(Game game, string name, int x, int y, int width, int height)
            : base(game)
        {
            this.name = name;
            this.focus = false;
            Bound = new Rectangle(x, y, width, height);
            children = new Collection<GUIElement>();
            visuals = new Dictionary<Drawable, Rectangle>();
            texts = new Collection<Text>();

            if (defaultBG == null) defaultBG = game.Content.Load<Texture2D>("darkboxbg");
        }

        /// <summary>
        /// Checks if the given point is within the boundaries of the GUIElement.
        /// </summary>
        /// <param name="x">The x-coordinate of the point</param>
        /// <param name="y">The y-coordinate of the point</param>
        /// <returns>True, if it contains the given point, else false.</returns>
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
        /// Indicate to the element (and all its children) that it
        /// has lost focus.
        /// </summary>
        public void LostFocus()
        {
            focus = false;
            foreach (GUIElement e in children) e.LostFocus();
        }

        /// <summary>
        /// Sets the font that this GUIElement draws its
        /// texts with.
        /// </summary>
        /// <param name="newFont">The new font to draw with.</param>
        public void SetFont(SpriteFont newFont)
        {
            font = newFont;
        }

        /// <summary>
        /// This memthod can be overwritten if you need to act
        /// on clicks that are directly targetting this guielement
        /// and not its sub-elements.
        /// </summary>
        /// <param name="x">The x-coordinate of the direct click.</param>
        /// <param name="y">The y-coordinate of the direct click.</param>
        protected virtual void ActOnDirectClick(int x, int y)
        {
            // can be implemented if needed
        }

        /// <summary>
        /// Determines if a click is within the GUIElement and acts
        /// upon the click if possible.
        /// </summary>
        /// <param name="x">The x-coordinate of the click</param>
        /// <param name="y">The y-coordinate of the click</param>
        public virtual bool HandleClick(int x, int y)
        {
            // is it within me?
            if (this.HasPoint(x, y))
            {
                // is it within any of my children?
                bool handled = false;
                for (int i = children.Count - 1; i >= 0; i--)
                {
                    if (!handled)
                    {
                        handled = children[i].HandleClick(x, y);
                    }
                    else
                    {
                        children[i].LostFocus();
                    }
                }
                if (handled) // did someone take it?
                {
                    focus = false;
                    return true;
                }

                // ok, its within me
                ActOnDirectClick(x, y);

                if (onClick != null)
                {
                    onClick(Player.Instance, this);
                }

                if (drawBg || VisualClicked(x, y))
                {
                    focus = true;
                    return true;
                }
                focus = false;
                return false;

            }
            // nope, wasnt me :(

            // ill tell all my children that it has lost focus.
            LostFocus();
            return false;
        }

        private bool VisualClicked(int x, int y)
        {
            foreach (Rectangle r in visuals.Values)
            {
                if (r.Contains(x, y)) return true;
            }
            return false;
        }

        /// <summary>
        /// Moves this element (and all sub-elements) by the specified amount.
        /// </summary>
        /// <param name="x">The number of pixels it should be moved on the x-axis.</param>
        /// <param name="y">The number of pixels it should be moved on the y-axis.</param>
        public virtual void Move(int x, int y)
        {
            Contract.Ensures(Bound.X == Contract.OldValue<int>(Bound.X) + x);
            Contract.Ensures(Bound.Y == Contract.OldValue<int>(Bound.Y) + y);
            Bound = new Rectangle(Bound.X + x, Bound.Y + y, Bound.Width, Bound.Height);
            foreach (GUIElement e in children) e.Move(x, y);
            foreach (Text t in texts) t.Position = new Vector2(t.Position.X + x, t.Position.Y + y);

            Drawable[] values = visuals.Keys.ToArray();
            for (int i = 0; i < values.Length; i++)
            {
                Rectangle old = visuals[values[i]];
                visuals[values[i]] = new Rectangle(old.X + x, old.Y + y, old.Width, old.Height);
            }

        }

        /// <summary>
        /// Disables all elements below (and including) the target
        /// element. They will not take inputs or display anything.
        /// </summary>
        /// <param name="target">What to disable.</param>
        public void Disable(string target)
        {
            if (Name == target)
            {
                SetDrawBackground(false);
                texts.Clear();
                visuals.Clear();
                onClick = null;
                children.Clear();
            }
            foreach (GUIElement e in children) e.Disable(target);
        }

        /// <summary>
        /// Reacts to the given key type if this GUIElement
        /// is focused.
        /// </summary>
        /// <param name="key">The key that has been pressed and wasn't pressed before</param>
        public virtual void HandleKeyPress(Keys key)
        {
            Contract.Requires(Keyboard.GetState().IsKeyDown(key));

            foreach (GUIElement e in children) e.HandleKeyPress(key);
            // this method can be overwritten if a GUIElement wants to react to keypresses.
        }

        /// <summary>
        /// Replace (if any) the current On Click action with
        /// the one given.
        /// </summary>
        /// <param name="target">The target GUIElement for the action</param>
        /// <param name="action">The new On Click action</param>
        public void SetClickAction(string target, Action<Player, GUIElement> action)
        {
            Contract.Requires(target != "");

            if (this.Name == target)
            {
                this.onClick = action;
            }
            foreach (GUIElement e in children) e.SetClickAction(target, action);
        }

        /// <summary>
        /// Adds the given GUIElement to the set of children within
        /// this one.
        /// </summary>
        /// <param name="child">The new child</param>
        public void AddChild(GUIElement child)
        {
            Contract.Requires(child.Bound.X >= Bound.X);
            Contract.Requires(child.Bound.Y >= Bound.Y);
            children.Add(child);
        }

        /// <summary>
        /// Removes all children.
        /// </summary>
        public void ClearChildren()
        {
            children.Clear();
        }

        /// <summary>
        /// Add the drawable to be displayed at the given position
        /// in this GUIElement.
        /// </summary>
        /// <param name="target">The target GUIElement for the action</param>
        /// <param name="visual">The drawable to display</param>
        /// <param name="position">Where the upper-left corner of the drawable should be</param>
        public void AddDrawable(string target, Drawable visual, Vector2 position)
        {
            Contract.Requires(target != "");
            Contract.Requires(visual != null);
            Contract.Requires(visual.Texture != null);
            AddDrawable(target, visual, new Rectangle((int)position.X, (int)position.Y, visual.Texture.Width, visual.Texture.Height));
        }

        /// <summary>
        /// Add the drawable to be displayed on the screen bounding the given rectangle.
        /// </summary>
        /// <param name="target">The target GUIElement for the action</param>
        /// <param name="visual">The drawable to display</param>
        /// <param name="rectangle">The drawable should be stretched to be drawn at the rectangle</param>
        public void AddDrawable(string target, Drawable visual, Rectangle rectangle)
        {
            Contract.Requires(target != "");
            Contract.Requires(visual != null);
            Contract.Requires(visual.Texture != null);

            Contract.Requires(rectangle.X >= Bound.X);
            Contract.Requires(rectangle.Y >= Bound.Y);
            Contract.Requires(rectangle.X + rectangle.Width <= Bound.X + Bound.Width);
            Contract.Requires(rectangle.Y + rectangle.Height <= Bound.Y + Bound.Height);
            if (Name == target)
            {
                visuals.Add(visual, rectangle);
            }
            foreach (GUIElement e in children)
            {
                if (e.Bound.Contains(rectangle)) e.AddDrawable(target, visual, rectangle);
            }
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
            AddText(target, text, position, Color.Black);
        }

        /// <summary>
        /// Adds the given string to be drawn on the screen on all children (or this)
        /// with the target name.
        /// </summary>
        /// <param name="target">Only GUIElements with this name should display the text.</param>
        /// <param name="text">The text to be drawn to the screen.</param>
        /// <param name="position">Where the upper-left corner of the text should be</param>
        /// <param name="color">The color that the text should be drawn in</param>
        public void AddText(string target, string text, Vector2 position, Color color)
        {
            Contract.Requires(target != null);
            Contract.Requires(text != null);

            if (Name == target)
            {
                texts.Add(new Text(WordWrap(text, position), new Vector2(position.X + Bound.X, position.Y + Bound.Y), color));
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
            Contract.Requires(text != null);

            int wordsIndex = 0;
            string[] words = text.Split();
            StringBuilder builder = new StringBuilder();

            int totalSpace = Bound.Width - (int)position.X + 15;

            string currentLine = "";
            string nextWord;
            while (wordsIndex < words.Length)
            {
                nextWord = words[wordsIndex];

                if (GUI.Font.MeasureString(currentLine + nextWord).X <= totalSpace) // word fits
                {
                    currentLine += nextWord + " ";
                    wordsIndex++;
                }
                else if (GUI.Font.MeasureString(nextWord).X > totalSpace) // cut word
                {
                    int end = nextWord.Length - 1;
                    while (GUI.Font.MeasureString(currentLine + nextWord.Substring(0, end) + "-").X > totalSpace) // see what we have space for
                    {
                        end--;
                    }
                    builder.Append(currentLine + nextWord.Substring(0, end) + "-\n"); // add what we had space for
                    currentLine = "";
                    words[wordsIndex] = words[wordsIndex].Substring(end, words[wordsIndex].Length - end); // let the remaining be
                }
                else// word doesn't fit, bit is not too long
                {
                    builder.Append(currentLine + "\n");
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
            Contract.Ensures(DrawsBackground() == toDraw);

            drawBg = toDraw;
        }

        /// <summary>
        /// Does the element draw a background behind it.
        /// </summary>
        /// <returns>True if it draws background behind it, else false.</returns>
        [Pure]
        public bool DrawsBackground()
        {
            return drawBg;
        }

        /// <summary>
        /// Changes the background to the given asset and enables
        /// background drawing.
        /// </summary>
        /// <param name="assetName">The name of the asset in the Content project.</param>
        public void SetBackground(string assetName)
        {
            Contract.Ensures(DrawsBackground());

            background = Game.Content.Load<Texture2D>(assetName);
            SetDrawBackground(true);
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
                draw.Draw(background ?? defaultBG, Bound, Color.White);
            }

            // draw my own "pictures"
            foreach (Drawable d in visuals.Keys) draw.Draw(d.Texture, visuals[d], Color.White);

            // draw my own text
            foreach (Text t in texts)
            {
                draw.DrawString(Font, t.Line, t.Position, t.Color);
            }

            // draw the children on top
            foreach (GUIElement e in children) e.Draw(draw);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GUIElement e in children) e.Update(gameTime);
        }
    }
}
