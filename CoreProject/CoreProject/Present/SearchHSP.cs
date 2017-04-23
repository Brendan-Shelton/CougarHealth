using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoreProject.Controller.EnrolleeControllers;
using CoreProject.Data.Enrollee;

namespace CoreProject.Present
{
    public partial class SearchHSP : Form
    {
        SearchController searchCntrl = new SearchController();
        public SearchHSP()
        {
            InitializeComponent();
            List<Service> service = searchCntrl.GetServices();
            populateBenefitList(service);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click_2(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dentalPlan_CheckedChanged(object sender, EventArgs e)
        {

            if (dentalCheck.Checked)
            {
                //benefitListBox.Items.Clear();
                List<Service> service = new List<Service>();

                Service ser1 = new Service();
                ser1.Name = "Dental Benefit 1";
                Service ser2 = new Service();
                ser2.Name = "Dental Benefit 2";
                Service ser3 = new Service();
                ser3.Name = "Dental Benefit 3";

                service.Add(ser1);
                service.Add(ser2);
                service.Add(ser3);

                populateBenefitList(service);
            }
            else if (!dentalCheck.Checked)
            {
                //benefitListBox.Items.Clear();
                List<Service> service = searchCntrl.GetServices();
                populateBenefitList(service);
            }
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void populateBenefitList(List<Service> service)
        {
            ((ListBox)benefitListBox).DataSource = null;
            benefitListBox.Items.Clear();

            ((ListBox)benefitListBox).DataSource = service;
            ((ListBox)benefitListBox).DisplayMember = "Name";
            //foreach (var item in service)
            //{
            //    benefitListBox.Items.Add(item);

                


            //}
        }


        private void searchButton_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < benefitListBox.CheckedIndices.Count; i++)
            {
                int index = benefitListBox.CheckedIndices[i];

                string aaa = benefitListBox.CheckedItems[index].ToString();
            }
        }
    }
}
