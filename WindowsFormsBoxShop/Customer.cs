using BoxDelivery.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsBoxShop
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            dataGridView1.Refresh();
            dataGridView1.DataSource = CreateDataTable(Storage.AvailabelInStock);
        }
        DataGridViewRow selectedRow = null;

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
                    Storage.sortedBoxList.DequeueBox(list[i]);
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
                int index = e.RowIndex;
                selectedRow = dataGridView1.Rows[index];
            }
            catch
            {

            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = e.RowIndex;
                selectedRow = dataGridView1.Rows[index];
            }
            catch 
            { 

            }


        }

        private void Customer_Load(object sender, EventArgs e)
        {

        }



        private void textBox3_TextChanged(object sender, EventArgs e)
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
        private void textBox2_TextChanged(object sender, EventArgs e)
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
                    textBox2.Clear();
                }
            }
        }
        private bool DequeueByIndex(Box box)
        {
            Box nextbox;
            if (int.Parse(comboBox1.Text) == 1)
            {
                Storage.sortedBoxList.DequeueBox(box);
            }
            else
            {


                int indexer = 1;
                while (indexer <= int.Parse(comboBox1.Text))
                {
                    if (Storage.sortedBoxList.DequeueBox(box) == 0&&indexer!= int.Parse(comboBox1.Text))
                    {
                        if (textBox1.Text == "")
                        {
                            nextbox = Storage.sortedBoxList.FindSmallestBiggerBox(box);
                        }
                        else
                        {
                            nextbox = Storage.sortedBoxList.FindSmallestBiggerBoxByPrecentage(box, double.Parse(textBox1.Text));
                        }
                        if (nextbox != null)
                        {
                            Box besttemp;
                            if (textBox1.Text == "")
                            {
                                besttemp = Storage.sortedBoxList.FindSmallestBiggerBox(box);
                            }
                            else
                            {
                                besttemp = Storage.sortedBoxList.FindSmallestBiggerBoxByPrecentage(box, double.Parse(textBox1.Text));
                            }
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
                        }
                    }
                    indexer++;
                }
            }
            return true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                MessageBox.Show("please select how many boxes you want first");
            else
            {

                if (textBox2.Text != "" && textBox3.Text != "")
                {
                    Box box = new Box(double.Parse(textBox3.Text), double.Parse(textBox2.Text));

                    if (Storage.sortedBoxList.DequeueBox(box) == -1)
                    {
                        Box temp;
                        if (textBox1.Text == "")
                        {
                            temp = Storage.sortedBoxList.FindSmallestBiggerBox(box);
                        }
                        else
                        {
                            temp = Storage.sortedBoxList.FindSmallestBiggerBoxByPrecentage(box, double.Parse(textBox1.Text));
                        }
                        if (temp != null)
                        {
                            if (MessageBox.Show($"we didnt find the box you looked for here is the best next option: \nX:{temp.X}\nY:{temp.Y}\nexperassion date:{temp.ExpireDate}", "acceptbox", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                DequeueByIndex(temp);
                            }
                        }
                        else
                            MessageBox.Show("we cant find a box for you sorry");
                    }
                    else
                    {


                        DequeueByIndex(box);
                    }
                }
                else if (selectedRow != null)
                {
                    Box box = new Box(double.Parse(selectedRow.Cells[0].Value.ToString()), double.Parse(selectedRow.Cells[1].Value.ToString()));
                    DequeueByIndex(box);
                }
                else
                    MessageBox.Show("we cant find a box for you sorry");
                MessageBox.Show("THANK YOU AND HAVE A NICE DAY");
                dataGridView1.DataSource = CreateDataTable(Storage.AvailabelInStock);
                dataGridView1.Refresh();
                selectedRow = new DataGridViewRow();
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string inputText = textBox1.Text;
            if (inputText != "")
            {
                try
                {
                    double value = double.Parse(inputText);
                    if ((value > 100 || value <= 0) && inputText != "")
                        throw new Exception();

                }
                catch
                {
                    MessageBox.Show("Enter only numbers between 1-100");
                    textBox1.Clear();
                }
            }
        }
    }
}
