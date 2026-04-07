using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MEE
{
    class MoveableBorderedPanel : BorderedPanel
    {
        // 이벤트 델리케이트 정의
        public delegate void MovedResizedHandler(object sender, MovedResizedEventArgs e);

        // 이벰트 정의
        public event MovedResizedHandler MovedResized;


        private const int cGripSize = 2;
        private bool mDragging;
        private Point mDragPos;
        private bool mMoving;
        private bool mNoMove;

        public MoveableBorderedPanel()
            : base()
        {
            this.DoubleBuffered = true;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.BackColor = Color.White;
        }

        public bool NoMove
        {
            get
            {
                return mNoMove;
            }
            set
            {
                mNoMove = value;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            ControlPaint.DrawSizeGrip(e.Graphics, this.BackColor,
            new Rectangle(this.ClientSize.Width - cGripSize, this.ClientSize.Height - cGripSize, cGripSize, cGripSize));
            base.OnPaint(e);
        }

        public bool IsOnGrip(Point pos)
        {
            return pos.X >= this.ClientSize.Width - cGripSize &&
            pos.Y >= this.ClientSize.Height - cGripSize;
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (mNoMove)
                {
                    mDragging = false;
                    mMoving = false;
                }
                else
                {
                    mDragging = IsOnGrip(e.Location);
                    mMoving = !mDragging;
                    mDragPos = e.Location;
                }
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            mDragging = false;
            mMoving = false;
            base.OnMouseUp(e);
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            if (mDragging)
            {
                //this.Size = new Size(this.Width + e.X - mDragPos.X, this.Height + e.Y - mDragPos.Y);
                this.Size = new Size(this.Width + e.X - mDragPos.X, this.Height); // 높이 고정
                mDragPos = e.Location;
            }
            else if (mMoving)
            {
                this.Left = e.X + this.Left - mDragPos.X;
                this.Top = e.Y + this.Top - mDragPos.Y;
            }
            else if (IsOnGrip(e.Location)) this.Cursor = Cursors.SizeNWSE;
            else this.Cursor = Cursors.Default;
            base.OnMouseMove(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            // 화살표로 이동
            if (e.KeyData == Keys.Left)
            {
                //this.Left -= 1;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.MOVE, MovedResizedEventArgs.LEFT, 1));
            }
            else if (e.KeyData == Keys.Right)
            {
                //this.Left += 1;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.MOVE, MovedResizedEventArgs.RIGHT, 1));
            }
            else if (e.KeyData == Keys.Up)
            {
                //this.Top -= 1;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.MOVE, MovedResizedEventArgs.UP, 1));
            }
            else if (e.KeyData == Keys.Down)
            {
                //this.Top += 1;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.MOVE, MovedResizedEventArgs.DOWN, 1));
            }
            // Control + 화살표로 이동(5칸씩)
            if (e.KeyData == (Keys.Control | Keys.Left))
            {
                //this.Left -= 5;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.MOVE, MovedResizedEventArgs.LEFT, 5));
            }
            else if (e.KeyData == (Keys.Control | Keys.Right))
            {
                //this.Left += 5;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.MOVE, MovedResizedEventArgs.RIGHT, 5));
            }
            else if (e.KeyData == (Keys.Control | Keys.Up))
            {
                //this.Top -= 5;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.MOVE, MovedResizedEventArgs.UP, 5));
            }
            else if (e.KeyData == (Keys.Control | Keys.Down))
            {
                //this.Top += 5;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.MOVE, MovedResizedEventArgs.DOWN, 5));
            }
            // Shift + 화살표로 크기 변경
            else if (e.KeyData == (Keys.Shift | Keys.Left))
            {
                //this.Width -= 1;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.RESIZE, MovedResizedEventArgs.LEFT, 1));
            }
            else if (e.KeyData == (Keys.Shift | Keys.Right))
            {
                //this.Width += 1;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.RESIZE, MovedResizedEventArgs.RIGHT, 1));
            }
            else if (e.KeyData == (Keys.Shift | Keys.Up))
            {
                //this.Height -= 1;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.RESIZE, MovedResizedEventArgs.UP, 1));
            }
            else if (e.KeyData == (Keys.Shift | Keys.Down))
            {
                //this.Height += 1;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.RESIZE, MovedResizedEventArgs.DOWN, 1));
            }
            // Shift + Control + 화살표로 크기 변경(5칸씩)
            else if (e.KeyData == (Keys.Control | Keys.Shift | Keys.Left))
            {
                //this.Width -= 5;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.RESIZE, MovedResizedEventArgs.LEFT, 5));
            }
            else if (e.KeyData == (Keys.Control | Keys.Shift | Keys.Right))
            {
                //this.Width += 5;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.RESIZE, MovedResizedEventArgs.RIGHT, 5));
            }
            else if (e.KeyData == (Keys.Control | Keys.Shift | Keys.Up))
            {
                //this.Height -= 5;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.RESIZE, MovedResizedEventArgs.UP, 5));
            }
            else if (e.KeyData == (Keys.Control | Keys.Shift | Keys.Down))
            {
                //this.Height += 5;
                MovedResized(this, new MovedResizedEventArgs(MovedResizedEventArgs.RESIZE, MovedResizedEventArgs.DOWN, 5));
            }
            base.OnKeyDown(e);
        }

    }
}
