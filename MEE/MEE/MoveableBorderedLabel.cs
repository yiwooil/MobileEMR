using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MEE
{
    class MoveableBorderedLabel : MoveableBorderedPanel
    {
        private Label label;

        public String autoFit = ""; // 2024.04.26 WOOIL
        public String typeName = ""; // 2026.04.21 WOOIL

        public MoveableBorderedLabel()
        {
            initLabel("");
        }

        public Label InnerLabel
        {
            get
            {
                return label;
            }
        }
        //public int InnerLabelLeft
        //{
        //    get
        //    {
        //        return label.Left;
        //    }
        //    set
        //    {
        //        label.Left = value;
        //    }
        //}

        public int InnerLabelWidth
        {
            get
            {
                return label.Width;
            }
            set
            {
                label.Width = value;
            }
        }

        public Color TextColor
        {
            get
            {
                return label.ForeColor;
            }
            set
            {
                label.ForeColor = value;
            }
        }

        private void resetLocation()
        {
            label.Top = 0;
            label.Left = 0;
            //int top = (this.Height - label.Height) / 2;
            //if (top < 0) top = 0;
            //label.Top = top;
        }

        protected override void OnResize(EventArgs e)
        {
            this.resetLocation();
            base.OnResize(e);
        }

        protected override void OnTextChanged(EventArgs e)
        {
            this.resetLocation();
            base.OnTextChanged(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            this.resetLocation();
            base.OnFontChanged(e);
        }
        public void setText(String text)
        {
            label.Text = text;
        }

        private void initLabel(String text)
        {
            label = new Label();
            label.AutoSize = true;
            label.Text = text;
            label.BackColor = Color.Transparent;
            this.InnerControls.Add(label);

            label.MouseDown += new MouseEventHandler(label_MouseDown);
            label.MouseMove += new MouseEventHandler(label_MouseMove);
            label.MouseUp += new MouseEventHandler(label_MouseUp);
        }

        void label_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }

        void label_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        void label_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (label != null)
                    label.Dispose();
            }
            label = null;
        }

    }
}
