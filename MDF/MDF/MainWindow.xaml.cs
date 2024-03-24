using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace WpfTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

            var clickedCheckBox = (CheckBox)sender;

            if (clickedCheckBox == ToDotcheckBox)
            {


                if (ToSlashcheckBox != null)
                {
                    ToSlashcheckBox.IsChecked = false;
                }
            }
            else if (clickedCheckBox == ToSlashcheckBox)
            {
                ToDotcheckBox.IsChecked = false;
            }
        }

        private void BrowseFileButton(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "fr3 files (*.fr3)|*.fr3";
            if (openFileDialog.ShowDialog() == true)
            {
                PathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void submitClicked(object sender, RoutedEventArgs e)
        {
            ManageFiles manageFiles = new ManageFiles();
            bool toDot;

            // check if TextBox empty
            if (PathTextBox.Text == "")
            {
                warningMsgBox("It can't be empty!");
                PathTextBox.Text = "";
                return;
            }


            // Check if filename don't ends with fr3
            if (!PathTextBox.Text.EndsWith(".fr3"))
            {
                warningMsgBox("It should be fr3 format!");
                PathTextBox.Text = "";
                return;
            }

            // Checking checkbox item select or not
            if (ToDotcheckBox.IsChecked == true)
            {
                toDot = true;

            }
            else if (ToSlashcheckBox.IsChecked == true)
            {
                toDot = false;
            }
            else
            {
                warningMsgBox("Choose the item you want!");
                PathTextBox.Text = "";
                return;
            }

            try
            {
                manageFiles.ReplaceInDesignFile(PathTextBox.Text, toDot);
                successMsgBox();
            }
            catch (Exception ex)
            {
                // handle other exceptions
                errorMsgBox(ex.Message);
            }
            PathTextBox.Text = "";

        }

        private void successMsgBox()
        {
            MessageBox.Show("Operation was successful!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void errorMsgBox(string deteal)
        {
            MessageBox.Show(this, deteal, "An error occurred!", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void warningMsgBox(string deteal)
        {
            MessageBox.Show(this, deteal, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

    }
}
