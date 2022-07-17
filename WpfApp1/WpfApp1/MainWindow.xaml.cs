using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private double? SalarioBruto { get; set; }
        private int? Meses { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        // Calculando o salario liquido
        private double CalcSalario(double a)
        {
            if (a <= 1212.00)
            {
                double result = a - (a * 0.075);
                return result;
            }

            if (a > 1212.00 && a <= 2427.35)
            {
                double result = a - (a * 0.09);
                return result;
            }
            if (a > 2427.35 &&  a <= 3641.03)
            {
                double result = a - (a * 0.12);
                return result;
            }
            else
            {
                double result = a - (a * 0.14);
                return result;
            }
        }

        // Calculando 13º
        private double CalcDecimo(double a, int meses)
        {
            double result = meses * (a / 12);
            result = CalcSalario(result);
            return result;
        }

        // Obtendo o salario bruto do usuário
        private void Salario_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(Salario?.Text))
            {
                SalarioBruto = null;
                return;
            }

            if (double.TryParse(Salario?.Text, out double parsedResult))
            {
                SalarioBruto = parsedResult;
            }
            else
            {
                Salario.Text = Salario.Text.TrimEnd(Salario.Text.LastOrDefault());
            }
        }

        // Obtendo quantos meses trabalhados
        private void MesesTrabalhado_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(MesesTrabalhado?.Text))
            {
                Meses = null;
                return;
            }

            if (int.TryParse(MesesTrabalhado?.Text, out int parsedResult))
            {
                Meses = parsedResult;
            }

            else
            {
                MesesTrabalhado.Text = MesesTrabalhado.Text.TrimEnd(MesesTrabalhado.Text.LastOrDefault());
            }
        }

        // Evento de clicar no botão Calcular
        private void CalcularButton_OnClick(object sender, RoutedEventArgs e)
        {
            if (SalarioBruto == null || Meses == null)
            {
                MessageBox.Show("Você precisa informa o salário e os meses para calcular!");
            }
            else
            {
                ResultSalarioLiquido.Text = $"{CalcSalario((double)SalarioBruto):N2}";
                ResultDecimoTerceiro.Text = $"{CalcDecimo((double)SalarioBruto, (int)Meses):N2}";
            }

        }
    }
}
