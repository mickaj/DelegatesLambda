using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Events
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow :Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        {
            Wallet thisWallet = this.Resources["myWallet"] as Wallet;
            Button buttonClicked = sender as Button;
            thisWallet.Money += int.Parse(buttonClicked.Content.ToString());
            walletMoney.Text = thisWallet.Money.ToString();
        }

        private void initializeOwner_Click(object sender, RoutedEventArgs e)
        {
            if(ownerName.Text != "")
            {
                Wallet thisWallet = this.Resources["myWallet"] as Wallet;
                thisWallet.Owner = ownerName.Text;
                //adding method from MainWindow class that will execute when the event occurs
                thisWallet.OnGotSomeMoney += ThisWallet_OnGotSomeMoney;
                List<Button> buttons = new List<Button> { Add1, Add2, Add5, Add10, Add20, Add50, Add100, Add200 };
                foreach(Button btn in buttons)
                {
                    btn.IsEnabled = true;
                }
                ownerName.IsEnabled = false;
                initializeOwner.IsEnabled = false;
            }
            else
            {
                MessageBox.Show("Provide owner name!","Missing owner name");
            }

        }

        private void ThisWallet_OnGotSomeMoney(object sender, EventArgs e)
        {
            Wallet thisWallet = sender as Wallet;
            MoneyEventArgs args = e as MoneyEventArgs;
            string _name = thisWallet.Owner;
            int _cash = args.Money;
            int _crossed = args.ValueCrossed;
            MessageBox.Show("You have reached "+_crossed+" in your wallet!\nTotal amount in your wallet is "+_cash+"!", "Kudos " + _name+"!");
        }

        private void ownerName_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox thisTextBox = sender as TextBox;
            if(thisTextBox.Text != "")
            {
                initializeOwner.IsEnabled = true;
            }
            else
            {
                initializeOwner.IsEnabled = false;
            }
        }
    }
}
