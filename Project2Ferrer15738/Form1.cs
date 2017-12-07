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
using System.IO;
using WMPLib;

namespace Project2Ferrer15738
{
    public partial class MainForm : Form
    {
        WMPLib.WindowsMediaPlayer player = new WMPLib.WindowsMediaPlayer();
        private Trainer myTrainer;
        public MainForm()
        {
            InitializeComponent();
            myTrainer = new Trainer();
            player.URL = "mainmenu.mp3";
            ReadFromFile();
            BagReadFromFile();
            BadgesReadFromFile();
            PotionsReadFromFile();
            CandiesReadFromFile();
            LevelReadFromFile();
        }

        private void ReadFromFile()
        {
            try
            {
                FileStream fs = new FileStream(@"pokedex.txt", FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] info = line.Split(',');
                    myTrainer.Register(info[0], info[1], info[2], int.Parse(info[3]), int.Parse(info[4]));
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void CandiesReadFromFile()
        {
            try
            {
                FileStream fs = new FileStream(@"candies.txt", FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    myTrainer.AddCandies(int.Parse(line));
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void BagReadFromFile()
        {
            try
            {
                FileStream fs = new FileStream(@"bag.txt", FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] info = line.Split(',');
                    myTrainer.Catch(info[0], info[1], int.Parse(info[2]), int.Parse(info[3]),info[4], int.Parse(info[5]), int.Parse(info[6]));
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void PotionsReadFromFile()
        {
            try
            {
                FileStream fs = new FileStream(@"potions.txt", FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    myTrainer.LoadPotions(int.Parse(line));
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void LevelReadFromFile()
        {
            try
            {
                FileStream fs = new FileStream(@"level.txt", FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    myTrainer.LoadLevel(double.Parse(line));
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void BadgesReadFromFile()
        {
            try
            {
                FileStream fs = new FileStream(@"badges.txt", FileMode.OpenOrCreate);
                StreamReader sr = new StreamReader(fs);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    myTrainer.LoadBadges(int.Parse(line));
                }
                sr.Close();
                fs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void WriteToFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"pokedex.txt", false);
                foreach (PokemonRegInfo b in myTrainer.GetPokemons())
                {
                    sw.WriteLine("{0},{1},{2},{3},{4}", b.GetPokemonName(), b.GetPokemonType(), b.GetPokemonEvolution(), b.GetEvolutionCost(), b.GetEvolutionMultiplier());
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void BagWriteToFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"bag.txt", false);
                foreach (MyPokemon b in myTrainer.GetBag())
                {
                    if (b == null)
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", null,null,null,null,null,null,null);
                    else
                        sw.WriteLine("{0},{1},{2},{3},{4},{5},{6}", b.GetPokemonName(), b.GetType(), b.GetHealthPoints(), b.GetCombatPower(), b.GetEvolution(), b.GetEvolutionMultiplier(), b.GetEvolutionCost());
                }
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void CandiesWriteToFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"candies.txt", false);
                sw.WriteLine(myTrainer.GetNumCandies());
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void LevelWriteToFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"level.txt", false);
                sw.WriteLine(myTrainer.GetLevel());
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void BadgesWriteToFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"badges.txt", false);
                sw.WriteLine(myTrainer.GetBadges());
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void PotionsWriteToFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter(@"potions.txt", false);
                sw.WriteLine(myTrainer.GetPotions());
                sw.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            WriteToFile();
            BagWriteToFile();
            CandiesWriteToFile();
            BadgesWriteToFile();
            PotionsWriteToFile();
            LevelWriteToFile();
            Close();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            label1.Text = "";
            int multiplier = -1;
            int cost = -1;
            RegisterForm newRegister = new RegisterForm();
            newRegister.ShowDialog();
            if (newRegister.GetEvolutionContent() == "none" || newRegister.GetEvolutionContent() == "None")
            {
                myTrainer.Register(newRegister.GetNameTboxContent(), newRegister.GetEvolutionTypeContent(), newRegister.GetEvolutionContent(), cost, multiplier);
            }
            else
                myTrainer.Register(newRegister.GetNameTboxContent(), newRegister.GetEvolutionTypeContent(), newRegister.GetEvolutionContent(), newRegister.GetCostContent(), newRegister.GetMultiplierContent());

            label1.Text = myTrainer.GetMessage();
        }

        private void ViewPokedexButton_Click(object sender, EventArgs e)
        {
            ViewPokedex newPokedex = new ViewPokedex(myTrainer.GetPokemons());
            newPokedex.ShowDialog();
        }

        private void CatchButton_Click(object sender, EventArgs e)
        {
            CatchForm newCatch = new CatchForm();
            newCatch.ShowDialog();
            if (myTrainer.FindInPokedex(newCatch.GetNameContent()) == null)
                label1.Text = newCatch.GetNameContent() + " does not exist in Pokedex.";
            else
            {
                myTrainer.Catch(newCatch.GetNameContent(), myTrainer.FindInPokedex(newCatch.GetNameContent()).GetPokemonType(), newCatch.GetHPContent(), newCatch.GetCPContent(), myTrainer.FindInPokedex(newCatch.GetNameContent()).GetPokemonEvolution(), myTrainer.FindInPokedex(newCatch.GetNameContent()).GetEvolutionCost(), myTrainer.FindInPokedex(newCatch.GetNameContent()).GetEvolutionMultiplier());
                label1.Text = myTrainer.GetMessage();
            }
        }

        private void ViewBagButton_Click(object sender, EventArgs e)
        {
            ViewBagForm newBag = new ViewBagForm(myTrainer.GetBag(), myTrainer);
            int candies = myTrainer.GetNumCandies();
            newBag.CandiesText = "Candies: " + candies.ToString();
            newBag.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewProfile newProfile = new ViewProfile();
            int bdgs = myTrainer.GetBadges();
            newProfile.BadgesText = bdgs.ToString();
            double lvl = Math.Floor(1 + myTrainer.GetLevel());
            newProfile.LevelText = lvl.ToString();
            int cndy = myTrainer.GetNumCandies();
            newProfile.CandiesText = cndy.ToString();
            newProfile.ShowDialog();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gym newGym = new Gym(myTrainer.GetBag(), myTrainer);
            newGym.ShowDialog();
            player.controls.stop();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            player.controls.play();
        }
    }
}
