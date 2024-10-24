namespace CalculatorApp;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    // Giri� yap butonuna t�klan�nca �al��acak metot
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        // Burada basit bir kullan�c� do�rulama yap�yoruz
        if (Preferences.ContainsKey("username") && Preferences.ContainsKey("password"))
        {
            string storedUsername = Preferences.Get("username", "");
            string storedPassword = Preferences.Get("password", "");

            if (username == storedUsername && password == storedPassword)
            {
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Hata", "Kullan�c� ad� veya �ifre hatal�", "Tamam");
            }
        }
        else
        {
            await DisplayAlert("Hata", "Kullan�c� bulunamad�. L�tfen kay�t olun.", "Tamam");
        }
    }

    // Kay�t ol sayfas�na y�nlendirme
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
}
