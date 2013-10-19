﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;

namespace cb0t
{
    public partial class UserListContainer : UserControl
    {
        public event EventHandler OpenPMRequested;
        public event EventHandler SendAdminCommand;
        public event EventHandler<ULCTXTaskEventArgs> MenuTask;

        private ContextMenuStrip ctx_menu { get; set; }
        private String CTXUserName { get; set; }

        public UserListContainer()
        {
            this.InitializeComponent();
            this.userListBox1.MouseDoubleClick += this.ItemMouseDoubleClick;
            this.ctx_menu = new ContextMenuStrip();
            this.ctx_menu.Items.Add(new ToolStripLabel());
            this.ctx_menu.Items[0].Enabled = false;
            this.ctx_menu.Items.Add(new ToolStripSeparator());//1
            this.ctx_menu.Items.Add("Nudge");//2
            this.ctx_menu.Items.Add("Whois");//3
            this.ctx_menu.Items.Add("Ignore/Unignore");//4
            this.ctx_menu.Items.Add("Scribble");//5
            this.ctx_menu.Items.Add("Copy name");//6
            this.ctx_menu.Items.Add("Add/Remove friend");//7
            this.ctx_menu.Items.Add("Browse");//8
            this.ctx_menu.Items.Add(new ToolStripSeparator());//9
            this.ctx_menu.Items.Add("Kill");//10
            this.ctx_menu.Items.Add("Ban");//11
            this.ctx_menu.Items.Add("Muzzle");//12
            this.ctx_menu.Items.Add("Unmuzzle");//13
            this.ctx_menu.Items.Add(new ToolStripSeparator());//14
            this.ctx_menu.Items.Add("Host kill");//15
            this.ctx_menu.Items.Add("Host ban");//16
            this.ctx_menu.Items.Add("Host muzzle");//17
            this.ctx_menu.Items.Add("Host unmuzzle");//18
            this.ctx_menu.ShowImageMargin = false;
            this.ctx_menu.Opening += this.CTXMenuOpening;
            this.ctx_menu.ItemClicked += this.CTXItemClicked;
            this.userListBox1.ContextMenuStrip = this.ctx_menu;
        }

        private void CTXItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (!String.IsNullOrEmpty(this.CTXUserName))
                if (e.ClickedItem != null)
                {
                    if (e.ClickedItem.Equals(this.ctx_menu.Items[2]))
                        this.MenuTask(this.CTXUserName, new ULCTXTaskEventArgs(ULCTXTask.Nudge));
                    else if (e.ClickedItem.Equals(this.ctx_menu.Items[3]))
                        this.MenuTask(this.CTXUserName, new ULCTXTaskEventArgs(ULCTXTask.Whois));
                    else if (e.ClickedItem.Equals(this.ctx_menu.Items[4]))
                        this.MenuTask(this.CTXUserName, new ULCTXTaskEventArgs(ULCTXTask.IgnoreUnignore));
                    else if (e.ClickedItem.Equals(this.ctx_menu.Items[5]))
                        this.MenuTask(this.CTXUserName, new ULCTXTaskEventArgs(ULCTXTask.Scribble));
                    else if (e.ClickedItem.Equals(this.ctx_menu.Items[6]))
                        this.MenuTask(this.CTXUserName, new ULCTXTaskEventArgs(ULCTXTask.CopyName));
                    else if (e.ClickedItem.Equals(this.ctx_menu.Items[7]))
                        this.MenuTask(this.CTXUserName, new ULCTXTaskEventArgs(ULCTXTask.AddRemoveFriend));
                    else if (e.ClickedItem.Equals(this.ctx_menu.Items[8]))
                        this.MenuTask(this.CTXUserName, new ULCTXTaskEventArgs(ULCTXTask.Browse));
                    else if (e.ClickedItem.Equals(this.ctx_menu.Items[10]))
                        this.SendAdminCommand("kill " + this.CTXUserName, EventArgs.Empty);
                    else if (e.ClickedItem.Equals(this.ctx_menu.Items[11]))
                        this.SendAdminCommand("ban " + this.CTXUserName, EventArgs.Empty);
                    else if (e.ClickedItem.Equals(this.ctx_menu.Items[12]))
                        this.SendAdminCommand("muzzle " + this.CTXUserName, EventArgs.Empty);
                    else if (e.ClickedItem.Equals(this.ctx_menu.Items[13]))
                        this.SendAdminCommand("unmuzzle " + this.CTXUserName, EventArgs.Empty);
                    else if (e.ClickedItem.Equals(this.ctx_menu.Items[15]))
                        this.SendAdminCommand("hostkill " + this.CTXUserName, EventArgs.Empty);
                    else if (e.ClickedItem.Equals(this.ctx_menu.Items[16]))
                        this.SendAdminCommand("hostban " + this.CTXUserName, EventArgs.Empty);
                    else if (e.ClickedItem.Equals(this.ctx_menu.Items[17]))
                        this.SendAdminCommand("hostmuzzle " + this.CTXUserName, EventArgs.Empty);
                    else if (e.ClickedItem.Equals(this.ctx_menu.Items[18]))
                        this.SendAdminCommand("hostunmuzzle " + this.CTXUserName, EventArgs.Empty);
                }
        }

        private void CTXMenuOpening(object sender, CancelEventArgs e)
        {
            int i = this.userListBox1.SelectedIndex;
            bool can_show = false;

            if (i > -1 && i < this.userListBox1.Items.Count)
                if (this.userListBox1.Items[i] is UserListBoxItem)
                {
                    can_show = true;
                    this.CTXUserName = ((UserListBoxItem)this.userListBox1.Items[i]).Owner.Name;
                    this.ctx_menu.Items[0].Text = "Options for: " + this.CTXUserName;

                    for (int x = 9; x < 14; x++)
                        this.ctx_menu.Items[x].Visible = this.MyLevel > 0;

                    for (int x = 14; x < 19; x++)
                        this.ctx_menu.Items[x].Visible = this.MyLevel == 3;
                }

            if (!can_show)
                e.Cancel = true;
        }

        private void ItemMouseDoubleClick(object sender, MouseEventArgs e)
        {
            int i = this.userListBox1.SelectedIndex;

            if (i > -1 && i < this.userListBox1.Items.Count)
                if (this.userListBox1.Items[i] is UserListBoxItem)
                {
                    String name = ((UserListBoxItem)this.userListBox1.Items[i]).Owner.Name;
                    this.OpenPMRequested(name, EventArgs.Empty);
                }
        }

        public int MyLevel { get; set; }

        public void Free()
        {
            this.userListBox1.ContextMenuStrip = null;
            this.ctx_menu.Opening -= this.CTXMenuOpening;
            this.ctx_menu.ItemClicked -= this.CTXItemClicked;

            while (this.ctx_menu.Items.Count > 0)
                this.ctx_menu.Items[0].Dispose();

            this.ctx_menu.Dispose();
            this.ctx_menu = null;
            this.userListBox1.MouseDoubleClick -= this.ItemMouseDoubleClick;

            while (this.Controls.Count > 0)
                this.Controls.RemoveAt(0);

            this.userListHeader1.Free();
            this.userListHeader1.Dispose();
            this.userListHeader1 = null;
            this.userListBox1.Items.Clear();
            this.userListBox1.Free();
            this.userListBox1.Dispose();
            this.userListBox1 = null;
        }

        public void UpdateLag(ulong lag)
        {
            this.userListHeader1.UpdateLag(lag);
        }

        public void SetToUser(String name)
        {
            for (int i = 0; i < this.userListBox1.Items.Count; i++)
                if (this.userListBox1.Items[i] is UserListBoxItem)
                    if (((UserListBoxItem)this.userListBox1.Items[i]).Owner.Name == name)
                    {
                        this.userListBox1.SelectedIndex = i;
                        this.userListBox1.TopIndex = i;
                        break;
                    }
        }

        public void UpdateServerVersion(String text)
        {
            this.userListHeader1.ServerVersion = text;
        }

        public void AcquireServerIcon(IPEndPoint ep)
        {
            this.userListHeader1.AcquireServerIcon(ep);
        }

        public void ClearUserList()
        {
            this.userListBox1.BeginInvoke((Action)(() =>
            {
                this.userListBox1.Items.Clear();
                this.userListBox1.BeginUpdate();
                this.userListBox1.Items.Add(new UserListBoxSectionItem(UserListBoxSectionType.Friends));
                this.userListBox1.Items.Add(new UserListBoxEmptyItem(UserListBoxSectionType.Friends));
                this.userListBox1.Items.Add(new UserListBoxSectionItem(UserListBoxSectionType.Admins));
                this.userListBox1.Items.Add(new UserListBoxEmptyItem(UserListBoxSectionType.Admins));
                this.userListBox1.Items.Add(new UserListBoxSectionItem(UserListBoxSectionType.Users));
                this.userListBox1.Items.Add(new UserListBoxEmptyItem(UserListBoxSectionType.Users));
            }));
        }

        public void ResumeUserlist()
        {
            this.userListBox1.BeginInvoke((Action)(() => this.userListBox1.EndUpdate()));
        }

        public void AddUserItem(User user)
        {
            this.userListBox1.BeginInvoke((Action)(() =>
            {
                if (user.IsFriend)
                {
                    int start_index = -1, end_index = -1;

                    for (int i = 0; i < this.userListBox1.Items.Count; i++)
                    {
                        if (this.userListBox1.Items[i] is UserListBoxSectionItem)
                            if (((UserListBoxSectionItem)this.userListBox1.Items[i]).Section == UserListBoxSectionType.Friends)
                                start_index = i;

                        if (this.userListBox1.Items[i] is UserListBoxSectionItem)
                            if (((UserListBoxSectionItem)this.userListBox1.Items[i]).Section == UserListBoxSectionType.Admins)
                                end_index = i;
                    }

                    if (start_index > -1 && end_index > start_index)
                    {
                        if (this.userListBox1.Items[end_index - 1] is UserListBoxEmptyItem)
                        {
                            int ti = this.userListBox1.TopIndex;
                            this.userListBox1.Items.RemoveAt(end_index - 1);
                            this.userListBox1.TopIndex = ti < this.userListBox1.Items.Count ? ti : (this.userListBox1.Items.Count - 1);
                            this.userListBox1.Items.Insert((end_index - 1), new UserListBoxItem(user));
                        }
                        else this.userListBox1.Items.Insert(end_index, new UserListBoxItem(user));
                    }
                }
                else if (user.Level > 0)
                {
                    int start_index = -1, end_index = -1;

                    for (int i = 0; i < this.userListBox1.Items.Count; i++)
                    {
                        if (this.userListBox1.Items[i] is UserListBoxSectionItem)
                            if (((UserListBoxSectionItem)this.userListBox1.Items[i]).Section == UserListBoxSectionType.Admins)
                                start_index = i;

                        if (this.userListBox1.Items[i] is UserListBoxSectionItem)
                            if (((UserListBoxSectionItem)this.userListBox1.Items[i]).Section == UserListBoxSectionType.Users)
                                end_index = i;
                    }

                    if (start_index > -1 && end_index > start_index)
                    {
                        if (this.userListBox1.Items[end_index - 1] is UserListBoxEmptyItem)
                        {
                            int ti = this.userListBox1.TopIndex;
                            this.userListBox1.Items.RemoveAt(end_index - 1);
                            this.userListBox1.TopIndex = ti < this.userListBox1.Items.Count ? ti : (this.userListBox1.Items.Count - 1);
                            this.userListBox1.Items.Insert((end_index - 1), new UserListBoxItem(user));
                        }
                        else this.userListBox1.Items.Insert(end_index, new UserListBoxItem(user));

                        this.userListBox1.SortAdmins();
                    }
                }
                else
                {
                    int ti = this.userListBox1.TopIndex;

                    if (this.userListBox1.Items[this.userListBox1.Items.Count - 1] is UserListBoxEmptyItem)
                        this.userListBox1.Items.RemoveAt(this.userListBox1.Items.Count - 1);

                    this.userListBox1.TopIndex = ti < this.userListBox1.Items.Count ? ti : (this.userListBox1.Items.Count - 1);
                    this.userListBox1.Items.Add(new UserListBoxItem(user));
                }

                int total_count = 0;

                for (int i = 0; i < this.userListBox1.Items.Count; i++)
                    if (this.userListBox1.Items[i] is UserListBoxItem)
                        total_count++;

                this.userListHeader1.HeaderText = "Users (" + total_count + ")";
                this.userListHeader1.Invalidate();
            }));
        }

        private void CheckSectionEmpty(UserListBoxSectionType section)
        {
            if (section == UserListBoxSectionType.Friends)
            {
                int start_index = -1, end_index = -1;

                for (int i = 0; i < this.userListBox1.Items.Count; i++)
                {
                    if (this.userListBox1.Items[i] is UserListBoxSectionItem)
                        if (((UserListBoxSectionItem)this.userListBox1.Items[i]).Section == UserListBoxSectionType.Friends)
                            start_index = i;

                    if (this.userListBox1.Items[i] is UserListBoxSectionItem)
                        if (((UserListBoxSectionItem)this.userListBox1.Items[i]).Section == UserListBoxSectionType.Admins)
                            end_index = i;
                }

                if (start_index > -1)
                    if (end_index < (start_index + 2))
                        this.userListBox1.Items.Insert((start_index + 1), new UserListBoxEmptyItem(UserListBoxSectionType.Friends));
            }
            else if (section == UserListBoxSectionType.Admins)
            {
                int start_index = -1, end_index = -1;

                for (int i = 0; i < this.userListBox1.Items.Count; i++)
                {
                    if (this.userListBox1.Items[i] is UserListBoxSectionItem)
                        if (((UserListBoxSectionItem)this.userListBox1.Items[i]).Section == UserListBoxSectionType.Admins)
                            start_index = i;

                    if (this.userListBox1.Items[i] is UserListBoxSectionItem)
                        if (((UserListBoxSectionItem)this.userListBox1.Items[i]).Section == UserListBoxSectionType.Users)
                            end_index = i;
                }

                if (start_index > -1)
                    if (end_index < (start_index + 2))
                        this.userListBox1.Items.Insert((start_index + 1), new UserListBoxEmptyItem(UserListBoxSectionType.Admins));
            }
            else if (this.userListBox1.Items.Count > 0)
            {
                if (!(this.userListBox1.Items[this.userListBox1.Items.Count - 1] is UserListBoxItem))
                    this.userListBox1.Items.Add(new UserListBoxEmptyItem(UserListBoxSectionType.Users));
            }
        }

        public void UpdateUserAppearance(User user)
        {
            this.userListBox1.BeginInvoke((Action)(() =>
            {
                for (int i = 0; i < this.userListBox1.Items.Count; i++)
                    if (this.userListBox1.Items[i] is UserListBoxItem)
                        if (((UserListBoxItem)this.userListBox1.Items[i]).Owner.Name == user.Name)
                        {
                            this.userListBox1.Invalidate(this.userListBox1.GetItemRectangle(i));
                            break;
                        }
            }));
        }

        public void UpdateUserLevel(User user, byte before)
        {
            this.userListBox1.BeginInvoke((Action)(() =>
            {
                bool section_changing = ((before == 0 && user.Level > 0) || (before > 0 && user.Level == 0)) && !user.IsFriend;
                int index = -1;
                UserListBoxSectionType section = UserListBoxSectionType.Friends;

                for (int i = 0; i < this.userListBox1.Items.Count; i++)
                    if (this.userListBox1.Items[i] is UserListBoxItem)
                    {
                        if (((UserListBoxItem)this.userListBox1.Items[i]).Owner.Name == user.Name)
                        {
                            index = i;
                            break;
                        }
                    }
                    else if (this.userListBox1.Items[i] is UserListBoxSectionItem)
                        section = ((UserListBoxSectionItem)this.userListBox1.Items[i]).Section;

                if (index > -1)
                {
                    UserListBoxItem item = (UserListBoxItem)this.userListBox1.Items[index];

                    if (section_changing)
                    {
                        int ti = this.userListBox1.TopIndex;
                        this.userListBox1.Items.RemoveAt(index);
                        this.userListBox1.TopIndex = ti < this.userListBox1.Items.Count ? ti : (this.userListBox1.Items.Count - 1);
                        ti = this.userListBox1.TopIndex;
                        this.CheckSectionEmpty(section);
                        this.userListBox1.TopIndex = ti < this.userListBox1.Items.Count ? ti : (this.userListBox1.Items.Count - 1);
                        this.AddUserItem(user);
                    }
                    else this.userListBox1.Invalidate(this.userListBox1.GetItemRectangle(index));
                }
            }));
        }

        public void UpdateUserFriendship(User user)
        {
            this.userListBox1.BeginInvoke((Action)(() =>
            {
                int index = -1;
                UserListBoxSectionType section = UserListBoxSectionType.Friends;

                for (int i = 0; i < this.userListBox1.Items.Count; i++)
                    if (this.userListBox1.Items[i] is UserListBoxItem)
                    {
                        if (((UserListBoxItem)this.userListBox1.Items[i]).Owner.Name == user.Name)
                        {
                            index = i;
                            break;
                        }
                    }
                    else if (this.userListBox1.Items[i] is UserListBoxSectionItem)
                        section = ((UserListBoxSectionItem)this.userListBox1.Items[i]).Section;

                if (index > -1)
                {
                    UserListBoxItem item = (UserListBoxItem)this.userListBox1.Items[index];
                    int ti = this.userListBox1.TopIndex;
                    this.userListBox1.Items.RemoveAt(index);
                    this.userListBox1.TopIndex = ti < this.userListBox1.Items.Count ? ti : (this.userListBox1.Items.Count - 1);
                    ti = this.userListBox1.TopIndex;
                    this.CheckSectionEmpty(section);
                    this.userListBox1.TopIndex = ti < this.userListBox1.Items.Count ? ti : (this.userListBox1.Items.Count - 1);
                    this.AddUserItem(user);
                }
            }));
        }

        public void RemoveUserItem(User user)
        {
            this.userListBox1.BeginInvoke((Action)(() =>
            {
                int index = -1;
                UserListBoxSectionType section = UserListBoxSectionType.Friends;

                for (int i = 0; i < this.userListBox1.Items.Count; i++)
                    if (this.userListBox1.Items[i] is UserListBoxItem)
                    {
                        if (((UserListBoxItem)this.userListBox1.Items[i]).Owner.Name == user.Name)
                        {
                            index = i;
                            break;
                        }
                    }
                    else if (this.userListBox1.Items[i] is UserListBoxSectionItem)
                        section = ((UserListBoxSectionItem)this.userListBox1.Items[i]).Section;

                if (index > -1)
                {

                    int ti = this.userListBox1.TopIndex;
                    this.userListBox1.OnItemRemoved(index);
                    this.userListBox1.Items.RemoveAt(index);
                    this.userListBox1.TopIndex = ti < this.userListBox1.Items.Count ? ti : (this.userListBox1.Items.Count - 1);
                    ti = this.userListBox1.TopIndex;
                    this.CheckSectionEmpty(section);
                    this.userListBox1.TopIndex = ti < this.userListBox1.Items.Count ? ti : (this.userListBox1.Items.Count - 1);
                }

                int total_count = 0;

                for (int i = 0; i < this.userListBox1.Items.Count; i++)
                    if (this.userListBox1.Items[i] is UserListBoxItem)
                        total_count++;

                this.userListHeader1.HeaderText = "Users (" + total_count + ")";
                this.userListHeader1.Invalidate();
            }));
        }

        public void SetCrypto(bool is_crypto)
        {
            this.userListHeader1.SetCrypto(is_crypto);
        }
    }
}
