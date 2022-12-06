

using System.Security.Cryptography;

namespace tema1;

public partial class NewPage1 : ContentPage
{
	int my_number = RandomNumberGenerator.GetInt32(1,100);
	
	public NewPage1()
	{
		InitializeComponent();

	}

	private void OnGuessClicked(object sender, EventArgs e)
	{
        Info.Text = "";
        try
		{
			if ((Convert.ToInt32(numberEntry.Text) < 1 || Convert.ToInt32(numberEntry.Text) > 100) && numberEntry.Text != "") Info.Text = "You tried " + Convert.ToString(numberEntry.Text) + ". Try an integer number between 1 and 100";
			else
			{
				if (Convert.ToInt32(numberEntry.Text) < my_number) Info.Text = "You tried " + Convert.ToString(numberEntry.Text) + "\n" + "Try Higher";
				else if (Convert.ToInt32(numberEntry.Text) == my_number)
				{
                    Info.Text = "You guessed!";
					ReplayingBtn.IsVisible = true;
					GuessingBtn.IsEnabled = false;
                }
				else Info.Text = "You tried " + Convert.ToString(numberEntry.Text) + "\n" + "Try Lower";
			}
        }
		catch(System.FormatException ex)
		{
			if(numberEntry.Text != "") Info.Text = "You tried " + Convert.ToString(numberEntry.Text) + ". Try an integer number between 1 and 100";
		}
        SemanticScreenReader.Announce(Info.Text);
        numberEntry.Text = "";

    }

	private void OnReplayClicked(object sender, EventArgs e)
	{
        my_number = RandomNumberGenerator.GetInt32(1, 100);
		ReplayingBtn.IsVisible = false;
		GuessingBtn.IsEnabled = true;
		Info.Text = "";
		OnGuessClicked(sender, e);
    }
}