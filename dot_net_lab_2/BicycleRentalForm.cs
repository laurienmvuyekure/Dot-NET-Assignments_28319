namespace Lab1WinForms;

// Problem 1: Bicycle rental cost calculator.
class BicycleRentalForm : Form
{
    private readonly TextBox txtStart = new() { Left = 120, Top = 15, Width = 100 };
    private readonly TextBox txtEnd = new() { Left = 120, Top = 45, Width = 100 };
    private readonly Label lblResult = new() { Left = 15, Top = 110, Width = 300, Height = 40 };

    public BicycleRentalForm()
    {
        Text = "Bicycle Rental";
        Width = 350;
        Height = 200;

        var btnCalc = new Button { Text = "Calculate", Left = 120, Top = 75, Width = 100 };
        btnCalc.Click += BtnCalc_Click;

        Controls.Add(new Label { Text = "Start hour (0-23):", Left = 15, Top = 18, Width = 105 });
        Controls.Add(txtStart);
        Controls.Add(new Label { Text = "End hour (1-24):", Left = 15, Top = 48, Width = 105 });
        Controls.Add(txtEnd);
        Controls.Add(btnCalc);
        Controls.Add(lblResult);
        AcceptButton = btnCalc;
    }

    private void BtnCalc_Click(object? sender, EventArgs e)
    {
        // int.TryParse rejects decimal numbers like "7.5".
        if (!int.TryParse(txtStart.Text, out int start) || !int.TryParse(txtEnd.Text, out int end))
        {
            lblResult.Text = "Please enter whole numbers only.";
            return;
        }
        if (start < 0 || start > 23)
        {
            lblResult.Text = "Start hour must be between 0 and 23.";
            return;
        }
        if (end < 1 || end > 24)
        {
            lblResult.Text = "End hour must be between 1 and 24.";
            return;
        }
        if (start >= end)
        {
            lblResult.Text = "Start hour must be less than end hour.";
            return;
        }

        int total = 0;
        // Charge each hour [h, h+1) at the rate of the range it falls in.
        for (int h = start; h < end; h++)
        {
            total += RateForHour(h);
        }

        lblResult.Text = $"Hours: {end - start}\nTotal to pay: {total} RWF";
    }

    private static int RateForHour(int hour)
    {
        if (hour < 7 || hour >= 21) return 500;    // 0-7 and 21-24
        if (hour >= 14 && hour < 19) return 1500;  // 14-19
        return 1000;                               // 7-14 and 19-21
    }
}
