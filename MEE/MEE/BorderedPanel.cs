using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MEE
{
    class BorderedPanel : SelectablePanel
    {
        private int borderWidth;
        private Color borderColor;
        private Color backColor;
        protected SelectablePanel panel;

        public BorderedPanel()
            : base()
        {
            borderWidth = 1;
            borderColor = Color.Black;
            backColor = Color.White;

            panel = new SelectablePanel();
            this.Controls.Add(panel);

            panel.Visible = true;
            panel.BackColor = backColor;
            panel.BorderStyle = BorderStyle.None;
            panel.BackgroundImageLayout = ImageLayout.Stretch;

            SetBorderWidth();
            SetBorderColor();

            panel.MouseDown += new MouseEventHandler(panel_MouseDown);
            panel.MouseMove += new MouseEventHandler(panel_MouseMove);
            panel.MouseUp += new MouseEventHandler(panel_MouseUp);
            panel.PreviewKeyDown += new PreviewKeyDownEventHandler(panel_PreviewKeyDown);

        }

        void panel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            this.OnPreviewKeyDown(e);
        }

        void panel_MouseUp(object sender, MouseEventArgs e)
        {
            this.OnMouseUp(e);
        }

        void panel_MouseMove(object sender, MouseEventArgs e)
        {
            this.OnMouseMove(e);
        }

        void panel_MouseDown(object sender, MouseEventArgs e)
        {
            this.OnMouseDown(e);
        }

        protected override void OnResize(EventArgs e)
        {
            SetBorderWidth();
            base.OnResize(e);
        }

        private void SetBorderWidth()
        {
            /*
            panel.Left = borderWidth;
            panel.Top = borderWidth;
            panel.Width = this.Width - (borderWidth * 2);
            panel.Height = this.Height - (borderWidth * 2);
            */
            panel.Left = 0;
            panel.Top = 0;
            panel.Width = this.Width;
            panel.Height = this.Height;
        }

        private void SetBorderColor()
        {
            base.BackColor = borderColor;
        }

        public int BorderWidth
        {
            get
            {
                return borderWidth;
            }
            set
            {
                borderWidth = value;
                SetBorderWidth();
            }
        }

        public Color BorderColor
        {
            get
            {
                return borderColor;
            }
            set
            {
                borderColor = value;
                SetBorderColor();
            }
        }

        public new Color BackColor // new로 처리하여야함.
        {
            get
            {
                return backColor;
            }
            set
            {
                backColor = value;
                panel.BackColor = backColor;
            }
        }

        public new Image BackgroundImage
        {
            get
            {
                return panel.BackgroundImage;
            }
            set
            {
                panel.BackgroundImage = value;
            }
        }

        public ControlCollection InnerControls
        {
            get
            {
                return panel.Controls;
            }
        }

        public Panel innerPanel
        {
            get
            {
                return panel;
            }
        }

    }
}
