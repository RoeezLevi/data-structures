using BoxDelivery.Classes;
using System;
using System.Windows.Forms;

namespace WindowsFormsBoxShop
{
    public partial class MainPage : Form
    {
        public MainPage()
        {
            InitializeComponent();

            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void MainPage_Load(object sender, EventArgs e)
        {
            if (Storage.sortedBoxList.IsEmpty() == true)
                StartApp.StartRun();
        }

        private void EXITbutton_Click(object sender, EventArgs e)
        {
            StorageActions.Exit();
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Customer cust = new Customer();
            cust.Show();
            this.Hide();
        }

        private void ManagerButton_Click(object sender, EventArgs e)
        {
            Manager man = new Manager();
            man.Show();
            this.Hide();
        }
    }
}
