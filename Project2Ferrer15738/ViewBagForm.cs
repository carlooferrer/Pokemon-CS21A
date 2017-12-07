// FERRER, Carlo Ram M. 
// 151738
// December 5, 2016
// I have not discussed the C# language code in my program
// with anyone other than my instructor or the teaching assistants assigned to this
// course. I have not used C# language code obtained from
// another person, or any other unauthorized source, either modified or unmodified.
// Any C# language code or documentation used in my program
// that was obtained from another source, such as a text book, a web page,
// or another person, have been clearly noted with proper citation in the
// comments of my program.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DRAFT;
using WMPLib;

namespace Project2Ferrer15738
{
    public partial class ViewBagForm : Form
    {
        WMPLib.WindowsMediaPlayer transfer = new WMPLib.WindowsMediaPlayer();
        private Trainer trainer;
        private MyPokemon[] bag;
        public ViewBagForm(MyPokemon[] a, Trainer myTrainer)
        {
            InitializeComponent();
            trainer = myTrainer;
            bag = a;
            FillGrid();
            label1.Text = "";
            label3.Text = "Potions: " + trainer.GetPotions().ToString();
        }

        private void FillGrid()
        {
            int i = 1;
            foreach (MyPokemon a in bag)
            {
                if (a == null)
                {
                    dataGridView1.Rows.Add(i, null, null, null);
                    i++;
                }
                else
                {
                    dataGridView1.Rows.Add(i, a.GetPokemonName(), a.GetHealthPoints(), a.GetCombatPower());
                    i++;
                }
            }
        }

        private void ViewBagForm_Load(object sender, EventArgs e)
        {
                
        }

        public string CandiesText
        {
            get
            {
                return this.label2.Text;
            }
            set
            {
                this.label2.Text = value;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            transfer.URL = "transfer.mp3";
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            int i = r.Index;
            trainer.Transfer(i);
            dataGridView1.Rows.Clear();
            FillGrid();
            label1.Text = "Transfer successful! You got 1 candy.";
            label2.Text = "Candies: " + trainer.GetNumCandies();
            transfer.controls.play();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            transfer.URL = "evolve.mp3";
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            int i = r.Index;
            trainer.Evolve(i);
            dataGridView1.Rows.Clear();
            FillGrid();
            label1.Text = trainer.GetMessage();
            label2.Text = "Candies: " + trainer.GetNumCandies();
            transfer.controls.play();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            transfer.URL = "potion.mp3";
            Potions newPotions = new Potions();
            newPotions.ShowDialog();
            trainer.BuyPotions(newPotions.GetOrder());
            label1.Text = trainer.GetMessage();
            label3.Text = "Potions: " + trainer.GetPotions().ToString();
            label2.Text = "Candies: " + trainer.GetNumCandies();
            transfer.controls.play();
        }
    }
}
