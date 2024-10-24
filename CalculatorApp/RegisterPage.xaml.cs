namespace CalculatorApp;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    // Kay�t ol butonuna t�klan�nca �al��acak metot
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string username = NewUsernameEntry.Text;
        string password = NewPasswordEntry.Text;

        // Kullan�c� bilgilerini kaydet
        Preferences.Set("username", username);
        Preferences.Set("password", password);

        await DisplayAlert("Ba�ar�l�", "Kay�t ba�ar�yla tamamland�", "Tamam");
        await Navigation.PopAsync(); // Login sayfas�na d�n
    }
}
