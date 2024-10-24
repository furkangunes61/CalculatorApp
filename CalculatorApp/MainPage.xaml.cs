namespace CalculatorApp;

public partial class MainPage : ContentPage
{
    string currentEntry = "";
    string operatorUsed = "";
    double firstNumber = 0;
    bool isSecondNumber = false;

    public MainPage()
    {
        InitializeComponent();
    }

    // Sayı butonuna tıklama işlemi
    void OnNumberClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var number = button.Text;

        if (ResultLabel.Text == "0" || isSecondNumber)
        {
            ResultLabel.Text = "";
            isSecondNumber = false;
        }

        currentEntry += number;
        ResultLabel.Text += number;
    }

    // Operatör butonuna tıklama işlemi
    void OnOperatorClicked(object sender, EventArgs e)
    {
        var button = sender as Button;
        var op = button.Text;

        if (double.TryParse(ResultLabel.Text, out firstNumber))
        {
            operatorUsed = op;
            isSecondNumber = true;
            currentEntry = "";
        }
    }

    // Sonuç hesaplama işlemi
    void OnCalculateClicked(object sender, EventArgs e)
    {
        double secondNumber;
        if (double.TryParse(ResultLabel.Text, out secondNumber))
        {
            double result = 0;

            switch (operatorUsed)
            {
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber != 0)
                        result = firstNumber / secondNumber;
                    else
                        DisplayAlert("Hata", "Bölme işlemi için ikinci sayı 0 olamaz.", "Tamam");
                    break;
            }

            ResultLabel.Text = result.ToString();
            currentEntry = result.ToString();
            firstNumber = result;
            isSecondNumber = true;
        }
    }

    // Hesap makinesini temizleme işlemi
    void OnClearClicked(object sender, EventArgs e)
    {
        ResultLabel.Text = "0";
        currentEntry = "";
        firstNumber = 0;
        operatorUsed = "";
        isSecondNumber = false;
    }
}
