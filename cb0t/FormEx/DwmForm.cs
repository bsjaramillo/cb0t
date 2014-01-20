﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FormEx
{
    public class DwmForm : Form
    {
        public JumpListEx.JumpListContainer JumpList { get; private set; }
        public PreviewToolStripEx.PreviewToolStripContainer PreviewToolStrip { get; private set; }
        public TaskBarProgressBarEx.TaskBarProgress TaskBarProgress { get; private set; }
        public OverlayIconEx.OverlayIcon OverlayIcon { get; private set; }

        public DwmForm()
        {
            bool can_win7 = false;

            if (Environment.OSVersion.Version.Major > 6)
                can_win7 = true;

            if (Environment.OSVersion.Version.Major == 6)
                if (Environment.OSVersion.Version.Minor >= 1)
                    can_win7 = true;

            if (!can_win7)
            {
                this.JumpList = null;
                this.PreviewToolStrip = null;
                this.TaskBarProgress = null;
                this.OverlayIcon = null;
            }
            else
            {
                this.JumpList = new JumpListEx.JumpListContainer(this);
                this.PreviewToolStrip = new PreviewToolStripEx.PreviewToolStripContainer(this);
                this.TaskBarProgress = new TaskBarProgressBarEx.TaskBarProgress(this);
                this.OverlayIcon = new OverlayIconEx.OverlayIcon(this);
            }
        }
    }
}
