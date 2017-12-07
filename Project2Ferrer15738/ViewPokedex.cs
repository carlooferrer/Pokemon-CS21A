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

namespace Project2Ferrer15738
{
    public partial class ViewPokedex : Form
    {
        private List<PokemonRegInfo> pokedex;
        public ViewPokedex(List<PokemonRegInfo> a)
        {
            InitializeComponent();
            pokedex = a;
            FillGrid();
        }

        private void FillGrid()
        {
            int i = 1;
            foreach (PokemonRegInfo a in pokedex)
            {
                if (a.GetPokemonEvolution() == null || a.GetPokemonEvolution() == "None" || a.GetPokemonEvolution() == "none")
                {
                    pokedexGridView.Rows.Add(i, a.GetPokemonName(), a.GetPokemonType(), "---", "---", "---");
                    i++;
                }
                else
                {
                    pokedexGridView.Rows.Add(i, a.GetPokemonName(), a.GetPokemonType(), a.GetPokemonEvolution(), a.GetEvolutionCost(), a.GetEvolutionMultiplier());
                    i++;
                }
            }
        }

        private void ViewPokedex_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditCMForm editcm = new EditCMForm();
            editcm.ShowDialog();
            DataGridViewRow r = pokedexGridView.SelectedRows[0];
            int i = r.Index;

            int n = editcm.GetCost();
            pokedex[i].SetCost(n);
            int j = editcm.GetMultiplier();
            pokedex[i].SetMultiplier(j);
            r.Cells[4].Value = n;
            r.Cells[5].Value = j;
        }
    }
}
