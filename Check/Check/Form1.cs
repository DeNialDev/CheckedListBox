using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Check
{
    
    public partial class  Form1 : Form
    {
        CheckedListBox FavLangs;
        GroupBox grpControls;
        Button AddValue;
        Button EditValue;
        Button DeleteValue;
        Button ShowValues;
        TextBox OldValue;
        TextBox NewValue;
        Label OldCaption;
        Label NewCaption;
        CheckBox chkAll;
        public Form1()
        {
            grpControls = new GroupBox();
            grpControls.Text = "CheckedListBox Demo";
            AddValue = new Button();
            AddValue.Text = "&Add";
            AddValue.Click += new EventHandler(Add_Click);
            EditValue = new Button();
            EditValue.Text = "&Edit";
            EditValue.Click += new EventHandler(Edit_Click);
            DeleteValue = new Button();
            DeleteValue.Text = "&Delete";
            DeleteValue.Click += new EventHandler(Delete_Click);
            ShowValues = new Button();
            ShowValues.Text = "&Show";
            ShowValues.Click += new EventHandler(ShowValues_Click);
            OldValue = new TextBox();
            OldValue.ReadOnly = true;
            NewValue = new TextBox();
            OldCaption = new Label();
            OldCaption.Text = "Old Value:";
            NewCaption = new Label();
            NewCaption.Text = "New Value:";
            chkAll = new CheckBox();
            chkAll.Text = "Check/UnCheck All";
            chkAll.CheckedChanged += new EventHandler(Checked_Changed);
            chkAll.Width = 175;
            OldCaption.Location = new Point(15, 15);
            PositionControl(OldCaption, OldValue, true);
            PositionControl(OldCaption, NewCaption, false);
            PositionControl(OldValue, NewValue, false);
            PositionControl(NewCaption, AddValue, false);
            PositionControl(AddValue, EditValue, true);
            PositionControl(EditValue, DeleteValue, true);
            PositionControl(DeleteValue, ShowValues, true);
            PositionControl(AddValue, chkAll, false);
            grpControls.Controls.AddRange(new Control[] { OldCaption, OldValue, NewCaption, NewValue, AddValue, EditValue, DeleteValue, ShowValues, chkAll });
            grpControls.Size = new Size(450, 200);
            FavLangs = new CheckedListBox();
            FavLangs.Location = new Point(10, 10);
            FavLangs.SelectedIndexChanged += new EventHandler(SelectedIndex_Changed);
            grpControls.Location = new Point(FavLangs.Left + FavLangs.Width + 20, FavLangs.Top);
            this.Controls.AddRange(new Control[] { FavLangs, grpControls });

            InitializeComponent();
        }
        private void PositionControl(Control source, Control destination, bool CanPlaceHorizontal)
        {
            if (CanPlaceHorizontal)
            {
                destination.Location = new Point(source.Left + source.Width + 20, source.Top);
            }
            else
            {
                destination.Location = new Point(source.Left, source.Top + source.Height + 20);
            }
        }
        private void Add_Click(object sender, EventArgs e)
        {
            if (NewValue.Text.Trim() != "")
            {
                FavLangs.Items.Add(NewValue.Text);
            }
            else
            {
                MessageBox.Show("Enter a Value to Add");
            }
        }
        private void SelectedIndex_Changed(object sender, EventArgs e)
        {
            OldValue.Text = FavLangs.Items[FavLangs.SelectedIndex].ToString();
        }
        private void Edit_Click(object sender, EventArgs e)
        {
            if (FavLangs.SelectedIndex == -1)
            {
                MessageBox.Show("Select a Item to Edit");
            }
            else
            {
                if (NewValue.Text.Trim() != "")
                {
                    FavLangs.Items[FavLangs.SelectedIndex] = NewValue.Text;
                }
                else
                {
                    MessageBox.Show("Enter a Value to Edit");
                }
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            if (FavLangs.SelectedIndex != -1)
            {
                FavLangs.Items.RemoveAt(FavLangs.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Select a Item to Delete");
            }
        }
        private void ShowValues_Click(object sender, EventArgs e)
        {
            string SelectedValues = "The following value(s) are Selected:\n" + new String('-', 48) + "\n";
            for (int i = 0; i < FavLangs.CheckedItems.Count; i++)
            {
                SelectedValues += FavLangs.CheckedItems[i].ToString() + "\n";
            }
            MessageBox.Show(SelectedValues);
        }
        private void Checked_Changed(object sender, EventArgs e)
        {
            for (int i = 0; i < FavLangs.Items.Count; i++)
            {
                FavLangs.SetItemChecked(i, chkAll.Checked);
            }
        }
        
           
        
    }
}
