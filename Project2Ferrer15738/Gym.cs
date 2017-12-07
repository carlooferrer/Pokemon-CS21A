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
    public partial class Gym : Form
    {
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        WMPLib.WindowsMediaPlayer attack = new WMPLib.WindowsMediaPlayer();
        private Trainer trainer;
        private MyPokemon[] bag;
        int pikachuhp = 1000;
        int cpuser;
        int hpuser;
        string chosenpokemon;
        public Gym(MyPokemon[] a, Trainer myTrainer)
        {
            InitializeComponent();
            trainer = myTrainer;
            bag = a;
            FillGrid();
            player.URL = "gym.mp3";
            player.controls.play();
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

        private void Gym_Load(object sender, EventArgs e)
        {
            label4.Text = "HP: " + pikachuhp;
            label5.Text = "";
            label6.Text = "";
        }

        private void choosebuttno_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = dataGridView1.SelectedRows[0];
            int i = r.Index;

            label1.Text = "User (" + bag[i].GetPokemonName() + ")";
            label3.Text = "HP: " + bag[i].GetHealthPoints() ;
            hpuser = bag[i].GetHealthPoints();
            cpuser = bag[i].GetCombatPower();
            chosenpokemon = bag[i].GetPokemonName();
            dataGridView1.ReadOnly = true;
            pictureBox5.Visible = true;
            button3.Visible = true;
            button1.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            player.controls.stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (hpuser <= 0)
            {
                Close();
                player.controls.stop();
            }
            else if (pikachuhp <= 0)
            {
                Close();
                trainer.AddBadge();
                player.controls.stop();
                MessageBox.Show("Congratulations you earned a badge! All your pokemons have been healed.");
            }
            else
            {
                attack.URL = "attack.mp3";
                attack.controls.play();
                Random pikacp = new Random();
                int damage = pikacp.Next(50, 100);
                hpuser -= damage;
                pikachuhp -= cpuser;
                if (hpuser <= 0)
                {
                    label3.Text = "Dead.";
                    button1.Text = "Exit.";
                }
                else if (pikachuhp <= 0)
                {
                    label4.Text = "Dead.";
                    button1.Text = "Exit.";
                }
                else
                {
                    label3.Text = "HP: " + hpuser;
                    label4.Text = "HP: " + pikachuhp;
                    label5.Text = chosenpokemon + " dealt " + cpuser + " damage";
                    label6.Text = "Pikachu dealt " + damage + " damage";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            if (trainer.GetPotions() > 0)
            {
                attack.URL = "potion.mp3";
                attack.controls.play();
                hpuser += 20;
                label5.Text = "You used a potion. Your pokemon regenrated 20 HP back.";
                label3.Text = "HP: " + hpuser;
                trainer.UsePotions();
            }

            else
            {
                MessageBox.Show("You do not have any potions.", "", buttons);
            }
        }
    }
}
