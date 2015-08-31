﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Wallpaper_Changer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string line;
            System.IO.StreamReader file = new System.IO.StreamReader("C:\\Users\\Scott\\Pictures\\Pic.txt");

            while ((line = file.ReadLine()) != null)
            {
                posible_items.Items.Add(line);
            }

            if (items_to_use.Items.Count == 0)
            {
                move_left.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<String> files = new List<string>();

            for (int i = 0; i < items_to_use.Items.Count; i++)
            {
                files.Add(items_to_use.Items[i].ToString());
            }

            SysTrayApp tray = new SysTrayApp(files);
            this.Hide();
        }

        private void move_right_Click(object sender, EventArgs e)
        {
            if (posible_items.SelectedItem != null)
            {
                items_to_use.Items.Add(posible_items.SelectedItem);
                posible_items.Items.Remove(posible_items.SelectedItem);
            }
            
            if (posible_items.Items.Count == 0)
            {
                move_right.Enabled = false;
            }

            if (items_to_use.Items.Count > 0)
            {
                move_left.Enabled = true;
            }
        }

        private void move_left_Click(object sender, EventArgs e)
        {
            if (items_to_use.SelectedItem != null)
            {
                posible_items.Items.Add(items_to_use.SelectedItem);
                items_to_use.Items.Remove(items_to_use.SelectedItem);
            }
            
            if (items_to_use.Items.Count == 0)
            {
                move_left.Enabled = false;
            }

            if (posible_items.Items.Count > 0)
            {
                move_right.Enabled = true;
            }
            
        }

        private void posible_items_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (posible_items.SelectedItem != null)
            {
                pictureBox1.ImageLocation = posible_items.SelectedItem.ToString();
            }

        }

        private void load_file_Click(object sender, EventArgs e)
        {
            String file_location;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                
            }
        }
    }
}