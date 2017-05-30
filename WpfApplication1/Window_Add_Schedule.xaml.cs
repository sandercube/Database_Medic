using MahApps.Metro.Controls;
using System.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MahApps.Metro.Controls.Dialogs;
using System.Data.SqlClient;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для Window_Add_Schedule.xaml
    /// </summary>
    public partial class Window_Add_Schedule : MetroWindow
    {

        public Window_Add_Schedule()
        {
            InitializeComponent();
        }

        private void btn_Add_Schedule_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public string IDDoc
        {
            get { return txt_id_doctor.Text; }
        }
        public string TimeON
        {
            get { return txt_time_on.Text; }
        }
        public string TimeOFF
        {
            get { return txt_time_off.Text; }
        }
        public string DPDate
        {
            
            get { return dp_schedule.SelectedDate.ToString(); }
        }

        private void btn_Cancel_Schedule_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void txt_id_doctor_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Space))
            {
                e.Handled = true;
            }
        }

        private void txt_id_doctor_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox ctrl = sender as TextBox;
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
            ctrl.MaxLength = 10;
        }

        private void dp_schedule_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox ctrl = sender as TextBox;
            e.Handled = "0123456789.".IndexOf(e.Text) < 0;
        }

        private void txt_time_on_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox ctrl = sender as TextBox;
            e.Handled = "0123456789:".IndexOf(e.Text) < 0;
        }

        private void txt_time_off_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox ctrl = sender as TextBox;
            e.Handled = "0123456789:".IndexOf(e.Text) < 0;
        }
    }
}
