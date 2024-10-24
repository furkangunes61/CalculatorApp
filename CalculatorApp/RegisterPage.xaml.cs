namespace CalculatorApp;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    // Kayýt ol butonuna týklanýnca çalýþacak metot
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        string username = NewUsernameEntry.Text;
        string password = NewPasswordEntry.Text;

        // Kullanýcý bilgilerini kaydet
        Preferences.Set("username", username);
        Preferences.Set("password", password);

        await DisplayAlert("Baþarýlý", "Kayýt baþarýyla tamamlandý", "Tamam");
        await Navigation.PopAsync(); // Login sayfasýna dön
    }
}
