namespace Lab1WinForms;

// Problem 2: Identify a mushroom by asking at most three yes/no questions.
//
// Decision tree:
//   Gills?
//     No  -> Cepe de Bordeaux                  (1 question)
//     Yes -> Forest?
//       No (meadow) -> Ring?
//         Yes -> Agaric jaunissant
//         No  -> Coprin chevelu
//       Yes -> Convex cup?
//         No  -> Girolle
//         Yes -> Ring?
//           Yes -> Amanite tue-mouches
//           No  -> Pied bleu
class MushroomForm : Form
{
    private const string Gills = "Does your mushroom have gills?";
    private const string Forest = "Does your mushroom grow in a forest?";
    private const string Ring = "Does your mushroom have a ring?";
    private const string Convex = "Does your mushroom have a convex cup?";

    private readonly Label lblQuestion = new() { Left = 15, Top = 15, Width = 320, Height = 40 };
    private readonly Button btnYes = new() { Text = "Yes", Left = 15, Top = 60, Width = 80 };
    private readonly Button btnNo = new() { Text = "No", Left = 105, Top = 60, Width = 80 };
    private readonly Button btnRestart = new() { Text = "Restart", Left = 195, Top = 60, Width = 80 };

    private string current = Gills;
    private bool forest;

    public MushroomForm()
    {
        Text = "Mushroom Identifier";
        Width = 370;
        Height = 140;

        btnYes.Click += (s, e) => Answer(true);
        btnNo.Click += (s, e) => Answer(false);
        btnRestart.Click += (s, e) => Restart();

        Controls.Add(lblQuestion);
        Controls.Add(btnYes);
        Controls.Add(btnNo);
        Controls.Add(btnRestart);

        Restart();
    }

    private void Restart()
    {
        current = Gills;
        lblQuestion.Text = "Think of one of the six mushrooms.\n" + Gills;
        btnYes.Enabled = btnNo.Enabled = true;
    }

    private void Ask(string question)
    {
        current = question;
        lblQuestion.Text = question;
    }

    private void Finish(string mushroom)
    {
        lblQuestion.Text = "Your mushroom is: " + mushroom;
        btnYes.Enabled = btnNo.Enabled = false;
    }

    private void Answer(bool yes)
    {
        switch (current)
        {
            case Gills:
                if (!yes) Finish("Cepe de Bordeaux");
                else Ask(Forest);
                break;

            case Forest:
                forest = yes;
                if (forest) Ask(Convex);
                else Ask(Ring);
                break;

            case Ring:
                if (!forest)
                    Finish(yes ? "Agaric jaunissant" : "Coprin chevelu");
                else
                    Finish(yes ? "Amanite tue-mouches" : "Pied bleu");
                break;

            case Convex:
                if (yes) Ask(Ring);   // Amanite or Pied bleu
                else Finish("Girolle");
                break;
        }
    }
}
