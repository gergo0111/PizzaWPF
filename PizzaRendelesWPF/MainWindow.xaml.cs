using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace PizzaRendelesWPF
{
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}

		private void OrderButton_Click(object sender, RoutedEventArgs e)
		{
			var vastagsag = (CrustListBox.SelectedItem as ListBoxItem)?.Content?.ToString() ?? "nincs kiválasztva";

			var meret = (SizeComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "nincs kiválasztva";

			var extraFeltetek = ToppingsPanel.Children
				.OfType<CheckBox>()
				.Where(cb => cb.IsChecked == true)
				.Select(cb => cb.Content?.ToString())
				.Where(s => !string.IsNullOrEmpty(s))
				.ToList();
			var feltetekText = extraFeltetek.Any() ? string.Join(", ", extraFeltetek) : "nincsenek extra feltétek";

			var szallitasiMod = DeliveryPanel.Children
				.OfType<RadioButton>()
				.FirstOrDefault(rb => rb.IsChecked == true)?
				.Content?.ToString() ?? "nincs kiválasztva";

			var kiiratas =
				$"Rendelés összefoglaló:\n" +
				$"- Tészta: {vastagsag}\n" +
				$"- Méret: {meret}\n" +
				$"- Feltétek: {feltetekText}\n" +
				$"- Átvétel: {szallitasiMod}";

			MessageBox.Show(kiiratas, "Rendelés összefoglaló", MessageBoxButton.OK, MessageBoxImage.Information);
		}
	}
}