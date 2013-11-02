﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace cb0t
{
    public partial class SettingsPanel : UserControl
    {
        private GlobalSettings global_settings { get; set; }
        private HashlinkSettings hashlink_settings { get; set; }
        private PersonalSettings personal_settings { get; set; }
        private AudioSettings audio_settings { get; set; }
        private FilterSettings filter_settings { get; set; }
        private MenuSettings menu_settings { get; set; }

        public event EventHandler JoinFromHashlinkClicked;

        public SettingsPanel()
        {
            this.InitializeComponent();
            this.treeView1.ExpandAll();
        }

        public void CreateSettings()
        {
            this.global_settings = new GlobalSettings();
            this.global_settings.Dock = DockStyle.Fill;
            this.global_settings.AutoScroll = true;
            this.global_settings.Populate();
            this.hashlink_settings = new HashlinkSettings();
            this.hashlink_settings.Dock = DockStyle.Fill;
            this.hashlink_settings.AutoScroll = true;
            this.hashlink_settings.Populate();
            this.hashlink_settings.JoinFromHashlink += this.JoinFromHashlink;
            this.personal_settings = new PersonalSettings();
            this.personal_settings.Dock = DockStyle.Fill;
            this.personal_settings.AutoScroll = true;
            this.personal_settings.Populate();
            this.audio_settings = new AudioSettings();
            this.audio_settings.Dock = DockStyle.Fill;
            this.audio_settings.AutoScroll = true;
            this.audio_settings.Populate();
            this.filter_settings = new FilterSettings();
            this.filter_settings.Dock = DockStyle.Fill;
            this.filter_settings.AutoScroll = true;
            this.filter_settings.Populate();
            this.menu_settings = new MenuSettings();
            this.menu_settings.Dock = DockStyle.Fill;
            this.menu_settings.AutoScroll = true;
            this.menu_settings.Populate();

            this.treeView1.SelectedNode = this.treeView1.Nodes[0];
        }

        private void JoinFromHashlink(object sender, EventArgs e)
        {
            this.JoinFromHashlinkClicked(sender, e);
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;

            while (this.panel1.Controls.Count > 0)
                this.panel1.Controls.RemoveAt(0);

            if (e.Node.Equals(this.treeView1.Nodes[0]))
                this.panel1.Controls.Add(this.global_settings);
            else if (e.Node.Equals(this.treeView1.Nodes[1]))
                this.panel1.Controls.Add(this.hashlink_settings);
            else if (e.Node.Equals(this.treeView1.Nodes[2]))
                this.panel1.Controls.Add(this.personal_settings);
            else if (e.Node.Equals(this.treeView1.Nodes[3]))
                this.panel1.Controls.Add(this.audio_settings);
            else if (e.Node.Equals(this.treeView1.Nodes[4]))
                this.panel1.Controls.Add(this.filter_settings);
            else if (e.Node.Equals(this.treeView1.Nodes[5]))
                this.panel1.Controls.Add(this.menu_settings);
        }

        private void treeView1_BeforeCollapse(object sender, TreeViewCancelEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
