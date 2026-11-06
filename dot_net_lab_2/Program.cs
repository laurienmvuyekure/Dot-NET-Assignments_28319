namespace Lab1WinForms;

static class Program
{
    [STAThread]
    static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}

// Simple launcher: one button per problem.
class MainForm : Form
{
    public MainForm()
    {
        Text = "Lab 1";
        Width = 260;
        Height = 150;

        var btnRental = new Button { Text = "Problem 1: Bicycle Rental", Left = 20, Top = 15, Width = 200 };
        var btnMushroom = new Button { Text = "Problem 2: Mushroom", Left = 20, Top = 50, Width = 200 };

        btnRental.Click += (s, e) => new BicycleRentalForm().ShowDialog();
        btnMushroom.Click += (s, e) => new MushroomForm().ShowDialog();

        Controls.Add(btnRental);
        Controls.Add(btnMushroom);
    }
}
