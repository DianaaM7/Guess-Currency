
namespace tema1;

public partial class MainPage : ContentPage
{
    decimal amount_euro = 0.00m;
    decimal amount_lei = 0.00m;

	public MainPage()
	{
		InitializeComponent();
	}

    private void OnConverterClicked(object sender, EventArgs e)
	{
        try
        {
            if (Convert.ToDecimal(amountEntry.Text) < 0)
            {
                Result.Text = "Please enter a positive decimal number";
            }
            else
            {

                amount_euro = Convert.ToDecimal(amountEntry.Text);
                amount_lei = (amount_euro * Convert.ToDecimal(4.92));
                amount_lei = Decimal.Round(amount_lei, 2);
                string rez = Convert.ToString(amount_euro) + " Euro  -  " + amount_lei.ToString() + " Lei";
                Result.Text = rez;


            }
        }
        catch (System.FormatException ex)
        {
            Result.Text = "Please enter a decimal number";
        }
        SemanticScreenReader.Announce(Result.Text);
    }
	private async void OnNextPageClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync("NewPage1");
	}
}

