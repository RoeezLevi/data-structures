using BoxDelivery.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace WindowsFormsBoxShop
{
    public partial class Manager : Form
    {
        public Manager()
        {
            InitializeComponent();
            dataGridView1.DataSource = CreateDataTable(Storage.AvailabelInStock);
            dataGridView2.DataSource = CreateDataTable(Storage.LowInStock);
            dataGridView3.DataSource = CreateDataTable(Storage.NeedToRestock);
            dataGridView4.DataSource = CreateDataTable(Storage.NotSelling);
        }
        DataGridViewRow[] selectedRow = new DataGridViewRow[3];
        int datagrid;

        private void Manager_Load(object sender, EventArgs e)
        {

        }
        public DataTable CreateDataTable(List<Box> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add("x", typeof(double));
            table.Columns.Add("y", typeof(double));
            table.Columns.Add("Amount", typeof(int));
            table.Columns.Add("Volume", typeof(double));

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].IsExpiered() == true)
                {
                    while (list[i].IsEmpty()==false&& list[i].IsExpiered() == true && list[i] != null)
                    {
                        Storage.sortedBoxList.DequeueBox(list[i]);
                    }
                }
                table.Rows.Add(list[i].X, list[i].Y, list[i].Amount, list[i].Volume);
            }
            return table;
        }
        private void Bind_dataGridView1_Using_DataTable_load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CreateDataTable(Storage.AvailabelInStock);
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                int index = e.RowIndex;
                datagrid = 0;
                selectedRow[datagrid] = dgv.Rows[index];
            }
            catch
            {

            }

        }

        private void Bind_dataGridView2_Using_DataTable_load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CreateDataTable(Storage.LowInStock);
        }

        private void dataGridView2_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                int index = e.RowIndex;
                datagrid = 1;
                selectedRow[datagrid] = dgv.Rows[index];
            }
            catch { }


        }
        private void Bind_dataGridView3_Using_DataTable_load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CreateDataTable(Storage.NeedToRestock);
        }
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                int index = e.RowIndex;
                datagrid = 2;
                selectedRow[datagrid] = dgv.Rows[index];
            }
            catch { }


        }
        private void Bind_dataGridView4_Using_DataTable_load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = CreateDataTable(Storage.NotSelling);
        }
        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = (DataGridView)sender;
                int index = e.RowIndex;
                datagrid = 3;
                selectedRow[datagrid] = dgv.Rows[index];
            }
            catch { }


        }
        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            string inputText = textBox3.Text;
            if (inputText != "")
            {
                try
                {
                    double value = double.Parse(inputText);
                }
                catch
                {
                    MessageBox.Show("Enter only numbers.");
                    textBox3.Clear();
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string inputText = textBox3.Text;
            if (inputText != "")
            {
                try
                {
                    double value = double.Parse(inputText);
                }
                catch
                {
                    MessageBox.Show("Enter only numbers.");
                    textBox1.Clear();
                }
            }
        }
        private bool DequeueByIndex(Box box)
        {
            int Size;
            if (comboBox1.Text == "All")
            {
                Size = Storage.sortedBoxList.FindTargetBox(box).Amount;/////אולי פשוט להגדיר את הבוקס כפג תוקפ ואז להוריד אותו
            }
            else
                Size = int.Parse(comboBox1.Text);
           
            if (Size == 1)
            {
                if (Storage.sortedBoxList.DequeueBox(box) == 0)///////////
                {
                    MessageBox.Show($"there are no longer boxes of the:\nX:{box.X}\nY:{box.Y}");
                    return true;
                }
            }
            int indexer = 1;
                while (indexer <= Size)
                {
                    if (Storage.sortedBoxList.DequeueBox(box) == 0)
                    {
                        /*                        if (Storage.sortedBoxList.FindSmallestBiggerBox(box) != null)
                                                {
                                                    Box besttemp = Storage.sortedBoxList.FindSmallestBiggerBox(box);
                                                    if (MessageBox.Show($"the box that we found for you is done\nyou currently have {indexer} boxes and you said you need {int.Parse(comboBox1.Text) - indexer} more boxes\nwould you like to continue with the best next option:\n X:{besttemp.X}\nY:{besttemp.Y}\nexperassion date:{besttemp.ExpireDate}", "acceptbox", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                                                    {
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        box = besttemp;
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("we know you dont have all yor boxes but we cant find a box for you sorry");
                                                    break;
                                                }*/
                        MessageBox.Show($"there are no longer boxes of the:\nX:{box.X}\nY:{box.Y}");
                        break;
                    }
                    indexer++;

                }
            
            return true;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                MessageBox.Show("please select how many boxes you want first");
            else
            {

                if (textBox1.Text != "" && textBox3.Text != "")
                {
                    Box box = new Box(double.Parse(textBox3.Text), double.Parse(textBox1.Text));

                    if (Storage.sortedBoxList.DequeueBox(box) == -1)
                    {
                        bool exist = false;
                        int place = 0;

                        /* Box temp = Storage.sortedBoxList.FindSmallestBiggerBox(box);
                         if (temp != null)
                         {
                             if (MessageBox.Show($"we didnt find the box you looked for here is the best next option:\n X:{temp.X}\nY:{temp.Y}\nexperassion date:{temp.ExpireDate}", "acceptbox", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                             {
                                 DequeueByIndex(temp);
                             }
                         }
                         else
                             MessageBox.Show("we cant find a box for you sorry");*/
                    }
                    else
                    {
                        DequeueByIndex(box);
                    }
                }
                else if (selectedRow[datagrid] != null)
                {
                    Box box = new Box(double.Parse(selectedRow[datagrid].Cells[0].Value.ToString()), double.Parse(selectedRow[datagrid].Cells[1].Value.ToString()));
                    if (Storage.sortedBoxList.DequeueBox(box) == -1)
                    {
                        int place = 0;
                        foreach (var queue in Storage.NeedToRestock)
                        {
                            if (queue.CompareTo(box) == 0)
                            {
                                break;
                            }
                            place++;
                        }
                        Storage.NeedToRestock.RemoveAt(place);
                    }
                    else
                        DequeueByIndex(box);
                }
                else
                    MessageBox.Show("we cant find a box for you sorry");
                dataGridView1.DataSource = CreateDataTable(Storage.AvailabelInStock);
                dataGridView1.Refresh();
                dataGridView2.DataSource = CreateDataTable(Storage.LowInStock);
                dataGridView2.Refresh();
                dataGridView3.DataSource = CreateDataTable(Storage.NeedToRestock);
                dataGridView3.Refresh();
                dataGridView4.DataSource = CreateDataTable(Storage.NotSelling);
                dataGridView4.Refresh();
                selectedRow[datagrid] = null;
                textBox3.Clear();
                textBox1.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int indexer = 1;
            int Size = 0;
            if (comboBox1.Text == "")
                MessageBox.Show("please select how many boxes you want first");
            else
            {
                Box box = null;
                if (textBox1.Text != "" && textBox3.Text != "")
                {
                    box = new Box(double.Parse(textBox3.Text), double.Parse(textBox1.Text));
                }
                else if (selectedRow[datagrid] != null)
                {
                    box = new Box(double.Parse(selectedRow[datagrid].Cells[0].Value.ToString()), double.Parse(selectedRow[datagrid].Cells[1].Value.ToString()));
                }
                if (box != null)
                {
                    if (comboBox1.Text == "All")
                        Size = 15;
                    else
                        Size = int.Parse(comboBox1.Text);
                    while (indexer <= Size)
                    {
                        if (Storage.sortedBoxList.Enqueue(box) == false)
                        {
                            MessageBox.Show($"the place of the box:\nX:{box.X}\nY:{box.Y}\n is full you ordered more {Size - indexer} Boxes\nwe are returning them right now");
                        }
                        indexer++;
                    }
                    if (indexer > 15)
                        indexer = 15;
                    MessageBox.Show($"we added {indexer - 1} of the boxes:\nX:{box.X}\nY:{box.Y}\n to your storage");
                }

            }

            dataGridView1.DataSource = CreateDataTable(Storage.AvailabelInStock);
            dataGridView1.Refresh();
            dataGridView2.DataSource = CreateDataTable(Storage.LowInStock);
            dataGridView2.Refresh();
            dataGridView3.DataSource = CreateDataTable(Storage.NeedToRestock);
            dataGridView3.Refresh();
            dataGridView4.DataSource = CreateDataTable(Storage.NotSelling);
            dataGridView4.Refresh();
            selectedRow[datagrid] = null;
            textBox3.Clear();
            textBox1.Clear();
        }

        private void EXITbutton_Click(object sender, EventArgs e)
        {
            StorageActions.Exit();
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StorageActions.Exit();
            MainPage main = new MainPage();
            main.Show();
            this.Hide();
        }


    }
}
