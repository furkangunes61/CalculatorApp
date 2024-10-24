namespace CalculatorApp;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    // Giriþ yap butonuna týklanýnca çalýþacak metot
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        // Burada basit bir kullanýcý doðrulama yapýyoruz
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
                await DisplayAlert("Hata", "Kullanýcý adý veya þifre hatalý", "Tamam");
            }
        }
        else
        {
            await DisplayAlert("Hata", "Kullanýcý bulunamadý. Lütfen kayýt olun.", "Tamam");
        }
    }

    // Kayýt ol sayfasýna yönlendirme
    private async void OnRegisterClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
}
