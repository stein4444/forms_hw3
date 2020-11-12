using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace forms_hw3
{
    public partial class Form1 : Form
    {
        public List<Worker> workers = new List<Worker>();
        string fileName = "workers.xml";
        public Form1()
        {
            InitializeComponent();
        }

        private void BtAdd_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(TbSurname.Text) &&
                  !String.IsNullOrEmpty(TbSallary.Text) &&
                  !String.IsNullOrEmpty(TbPoss.Text) &&
                  !String.IsNullOrEmpty(TbCity.Text) &&
                  !String.IsNullOrEmpty(TbStreet.Text) &&
                  !String.IsNullOrEmpty(TbNumber.Text))
            {
                LoadData();
                Worker wrk = new Worker(TbSurname.Text, int.Parse(TbSallary.Text), TbPoss.Text, TbCity.Text, TbStreet.Text,int.Parse(TbNumber.Text));
                workers.Add(wrk);
                File.Delete(fileName);
                if (File.Exists(fileName)) return;
                XmlSerializer serializer = new XmlSerializer(typeof(List<Worker>));
                using (FileStream fs = new FileStream(fileName, FileMode.Create))
                {
                    serializer.Serialize(fs, workers);
                    MessageBox.Show("Succsesfully");
                }
              
            }
            else
                MessageBox.Show("Bad Value, try again \n" + MessageBoxButtons.OK);
            ClearBoxes();
        }

        public void ClearBoxes()
        {
            this.TbSurname.Clear();
            this.TbSallary.Clear();
            this.TbPoss.Clear();
            this.TbCity.Clear();
            this.TbStreet.Clear();
            this.TbNumber.Clear();
        }
        private void LWorkers_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string a = LWorkers.GetItemText(LWorkers.SelectedItem.ToString());
            foreach (Worker item in workers)
            {
                if(a == item.surname)
                {
                    comboBox1.Items.Add(item.sallary);
                    comboBox1.Items.Add(item.poss);
                    comboBox1.Items.Add(item.city);
                    comboBox1.Items.Add(item.street);
                    comboBox1.Items.Add(item.number);
                }

              
            }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
            if (this.progressBar1.Value == 100)
            {
                MessageBox.Show("Loaded succsessfully " + MessageBoxButtons.OK);
                this.LWorkers.Items.Clear();
                XmlSerializer xml = new XmlSerializer(typeof(List<Worker>));
                using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
                {
                    workers = xml.Deserialize(fs) as List<Worker>;
                    this.LWorkers.Refresh();
                    foreach (Worker item in workers)
                    {
                        LWorkers.Items.Add(item.surname);
                    }
                }
            }
           
           
        }

        public void LoadData()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Worker>));
            using (FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read))
            {
                workers = xml.Deserialize(fs) as List<Worker>;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.progressBar1.Increment(10);
        }
    }

}
