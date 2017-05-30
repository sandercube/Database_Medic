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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Windows.Media.Animation;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading;
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        bool rightpanelAdd, rightpanelEdit, rightpaneladdcard,rightpaneleditcard, rightpaneladddoc, rightpaneleditdoc, rightpanelTer, btn = false;
        bool datagridPacients, datagridCards, datagridDoctors = false;
        public string DBConnectionString = "Data Source=DESKTOP-GC5KRS2\\SQLEXPRESS;Initial Catalog=Clinic_Base;User ID=sa; Password=123456789";
        public SqlDataAdapter da;
        public MainWindow()
        {
            InitializeComponent();
        }
        public async void LoadDataGrid(DataGrid dataGridName, string command)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con = new SqlConnection(DBConnectionString);
                con.Open();
                da = new SqlDataAdapter(command, con);
                DataTable dt = new DataTable();
                //DataSet ds = new DataSet();
                da.Fill(dt);
                dataGridName.ItemsSource = dt.DefaultView;
                //dataGridName.ItemsSource = ds.Tables[0].DefaultView;
                con.Close();
            }
            catch(Exception ex)
            {
                MessageDialogResult result = await this.ShowMessageAsync("Ошибка!", "Программе не удалось подключиться к базе данных.\nПроверьте наличие файла базы данных, либо установите необходимые сервисы", MessageDialogStyle.Affirmative);
                if (result == MessageDialogResult.Affirmative)
                {
                    Application.Current.Shutdown();
                }
            }
        }
        protected void LoadCombobox(ComboBox comboBoxName, string command)
        {
            using (SqlConnection con = new SqlConnection(DBConnectionString))
            {
                con.Open();
                SqlDataAdapter da = new SqlDataAdapter(command, con);
                DataSet ds = new DataSet();
                da.Fill(ds/*, "City_List"*/);
                comboBoxName.ItemsSource = ds.Tables[0].DefaultView;
                comboBoxName.DisplayMemberPath = ds.Tables[0].Columns[1].ToString();
                comboBoxName.SelectedValuePath = ds.Tables[0].Columns[0].ToString();
                con.Close();
                comboBoxName.SelectedIndex = 0;
            }
        }
        /*-------------------------------ЗАГРУЗКА ВСЕХ ДАТАГРИД---------------------------------------*/
        private async void metroWindow_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                LoadDataGrid(Grid_Pacient, "SELECT * FROM View_Pacients");
                LoadDataGrid(Grid_Cards, "SELECT * FROM Card_Patient");
                LoadDataGrid(Grid_Doctors, "SELECT * FROM View_Doctors");
                LoadDataGrid(Grid_Pacient_Visit, "SELECT * FROM View_Visit_Patients");
                LoadDataGrid(Grid_Schedule, "SELECT * FROM View_Schedule_Doc");
                LoadDataGrid(Grid_Talons, "SELECT * FROM View_Free_Talons");
                LoadCombobox(cmbcityp, "SELECT ID_City, City FROM City_List");
                LoadCombobox(cmb_cityp, "SELECT ID_City, City FROM City_List");
                LoadCombobox(cmbspec, "SELECT ID_Occupation, Occupation_Name FROM Occupation");
                LoadCombobox(cmb_spec, "SELECT ID_Occupation, Occupation_Name FROM Occupation");
                /*LoadCombobox(doctor_list, "SELECT * FROM Doctors");
                LoadCombobox(palate_list, "SELECT * FROM Palats");
                LoadCombobox(departament_list1, "SELECT * FROM Departament");
                LoadCombobox(doctor_list1, "SELECT * FROM Doctors");
                LoadCombobox(txtpalatep, "SELECT * FROM Doctors");*/
            }
            catch (Exception ex)
            {
                MessageDialogResult result = await this.ShowMessageAsync("Ошибка!", "Программе не удалось загрузить данные с базы данных.\nПроверьте соотвествующее подключение, либо установите необходимые сервисы", MessageDialogStyle.Affirmative);
                if (result == MessageDialogResult.Affirmative)
                {
                    Application.Current.Shutdown();
                }
            } 
        }
        /*-------------------------------!!!!!!!!!!!!!!!!!!!!---------------------------------------*/

        private void Button_Click_Terapy(object sender, RoutedEventArgs e)
        {
            rightpanelTer = PanelAnimation("RightPanelTerOpen", "RightPanelTerClose", rightpanelTer);
        }
        /*-------------------------------------------ОТКРЫТИЕ/ЗАКРЫТИЕ ДОП МЕНЮ----------------------------------------------*/
        private void LeftPanelIconOpen(object sender, MouseButtonEventArgs e)
        {
            if (metroTabControl.SelectedIndex == 0)
            {
                datagridPacients = PanelAnimation("GridPacientsOpen", "GridPacientsClose", datagridPacients); 
            }
            if (metroTabControl.SelectedIndex == 1)
            {
                datagridCards = PanelAnimation("GridCardsOpen", "GridCardsClose", datagridCards);
            }
        }
        /*-------------------------------------------!!!!!!!!!!!!!!!!!!!!!!!!!!----------------------------------------------*/

        /*|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||*/
        /*----------------------------------SQL-Добавление / Изменение / Удаление Пациентов--------------------------*/
        /*|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||*/
        private async void RightPanelDeletePacient(object sender, MouseButtonEventArgs e)
        {
            /*bottompanelDelete = PanelAnimation("BotPanelDelOpen", "BotPanelDelClose", bottompanelDelete);
            if (rightpanelAdd)
                rightpanelAdd = PanelAnimation("RightPanelOpen", "RightPanelClose", rightpanelAdd);
            else
                if (rightpanelEdit)
                    rightpanelEdit = PanelAnimation("RightPanelEditOpen", "RightPanelEditClose", rightpanelEdit);*/
            DataRowView rowView = Grid_Pacient.SelectedValue as DataRowView;
            if (Grid_Pacient.SelectedIndex > -1)
            {
                var res = await this.ShowMessageAsync("Подтверждение", "Действительно ли Вы хотите удалить!", MessageDialogStyle.AffirmativeAndNegative);
                if (res == MessageDialogResult.Affirmative)
                {
                    using (SqlConnection con = new SqlConnection(DBConnectionString))
                    {
                        string SQLString = string.Format("DELETE FROM Pacient WHERE ID_Pacient=" + rowView[0].ToString() + ";");
                        con.Open();
                        using (SqlCommand command = new SqlCommand(SQLString, con))
                        {
                            command.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                    string command1 = "SELECT * FROM View_Pacients";
                    LoadDataGrid(Grid_Pacient, command1);
                }
            }
        }
        private async void btn_addP_Click(object sender, RoutedEventArgs e)
        {
            
            if ((txtfamp.Text =="") || (txtnamep.Text =="") || (txtotchp.Text =="") || (txtadressp.Text =="") || (txtphonep.Text =="") ||
                (cmbpolp.SelectedIndex == -1) || (cmbcityp.SelectedIndex == -1) || (dpbirth.SelectedDate == null))
            {
                await this.ShowMessageAsync("Неверные данные", "Пожалуйста, заполните ВСЕ поля!");
            }
            else
            {
                var controller = await this.ShowProgressAsync("Подождите...", "Идёт добавление...");
                try
                {    
                    await Task.Delay(500);
                    controller.SetCancelable(false);
                    using (SqlConnection con = new SqlConnection(DBConnectionString))
                    {
                        string SQLString = string.Format("INSERT INTO Pacient" +
                           "(LastName_PT, Name_PT, MiddleName_PT, Pol, Date_of_Birth_PT, Phone_PT, City_PT, Adress) VALUES(@FamiliyaP, @NameP, @OtchestvoP, @Pol, @DateBirth, @Phone, @City, @Adress)");
                        con.Open();

                        using (SqlCommand command = new SqlCommand(SQLString, con))
                        {
                            command.Parameters.AddWithValue("@FamiliyaP", txtfamp.Text);
                            command.Parameters.AddWithValue("@NameP", txtnamep.Text);
                            command.Parameters.AddWithValue("@OtchestvoP", txtotchp.Text);
                            command.Parameters.AddWithValue("@Pol", cmbpolp.SelectionBoxItem);
                            command.Parameters.AddWithValue("@DateBirth", dpbirth.SelectedDate);
                            command.Parameters.AddWithValue("@Phone", txtphonep.Text);
                            command.Parameters.AddWithValue("@City", cmbcityp.SelectedValue);
                            command.Parameters.AddWithValue("@Adress", txtadressp.Text);
                            command.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                    string command1 = "SELECT * FROM View_Pacients";
                    LoadDataGrid(Grid_Pacient, command1);
                    btn_addP_Cancel(sender, e);

                    /*controller.SetProgress(.400);
                    controller.SetMessage("Подождите...");
                    await Task.Delay(500);*/

                    await controller.CloseAsync();
                    await this.ShowMessageAsync("Успешно!", "Данные успешно добавлены!");
                }
                catch (Exception ex)
                {
                    await controller.CloseAsync();
                    await this.ShowMessageAsync("Неудача!", ex.ToString());
                }
            }
        }
        private async void btn_editP_Click(object sender, RoutedEventArgs e)
        {
            if ((txt_famp.Text == "") || (txt_namep.Text == "") || (txt_otchp.Text == "") || (txt_adressp.Text == "") || (txt_phonep.Text == "") ||
                (cmb_polp.SelectedIndex == -1) || (cmb_cityp.SelectedIndex == -1) || (dp_birth.SelectedDate == null))
            {
                await this.ShowMessageAsync("Неверные данные", "Пожалуйста, заполните ВСЕ поля!");
            }
            else
            {
                var controller = await this.ShowProgressAsync("Подождите...", "Идёт добавление...");
                try
                {
                    await Task.Delay(500);
                    controller.SetCancelable(false);
                    DataRowView rowView = Grid_Pacient.SelectedValue as DataRowView;
                    if (Grid_Pacient.SelectedIndex > -1)
                    {
                        using (SqlConnection con = new SqlConnection(DBConnectionString))
                        {
                            string SQLString = string.Format("UPDATE Pacient SET LastName_PT = @FamiliyaP, Name_PT = @NameP, MiddleName_PT = @OtchestvoP, Pol = @Pol, Date_of_Birth_PT = @DateBirth, Phone_PT = @Phone, City_PT = @City, Adress = @Adress WHERE ID_Pacient = " + rowView[0].ToString() + ";");
                            con.Open();
                            using (SqlCommand command = new SqlCommand(SQLString, con))
                            {
                                command.Parameters.AddWithValue("@FamiliyaP", txt_famp.Text);
                                command.Parameters.AddWithValue("@NameP", txt_namep.Text);
                                command.Parameters.AddWithValue("@OtchestvoP", txt_otchp.Text);
                                command.Parameters.AddWithValue("@Pol", cmb_polp.SelectionBoxItem);
                                command.Parameters.AddWithValue("@DateBirth", dp_birth.SelectedDate);
                                command.Parameters.AddWithValue("@Phone", txt_phonep.Text);
                                command.Parameters.AddWithValue("@City", cmb_cityp.SelectedValue);
                                command.Parameters.AddWithValue("@Adress", txt_adressp.Text);
                                command.ExecuteNonQuery();
                            }
                            con.Close();
                            string command1 = "SELECT * FROM View_Pacients";
                            LoadDataGrid(Grid_Pacient, command1);
                            btn_editP_Cancel(sender, e);

                            await controller.CloseAsync();
                            await this.ShowMessageAsync("Успешно!", "Данные успешно обновлены!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    await controller.CloseAsync();
                    await this.ShowMessageAsync("Неудача!", ex.ToString());
                }
            }
        }
        private async void btn_addTer_Click(object sender, RoutedEventArgs e)
        {
            if ((txt_idcardter.Text == "") || (txt_timeter.Text == ""))
            {
                await this.ShowMessageAsync("Не верные данные", "Пожалуйста, заполните ВСЕ поля!");
            }
            else
            {
                string OleDbstring = string.Format("INSERT INTO Terapy" +
                       "(Id_Card, TimeTerapy, DateTerapy, ProcedureTer, Analiz, Report) VALUES(@Id_Card, @TimeTerapy, @DateTerapy, @ProcedureTer, @Analiz, @Report)");
                /*using (OleDbCommand command = new OleDbCommand(OleDbstring, con))
                {
                    con.Open();
                    command.Parameters.AddWithValue("@Id_Card", Convert.ToInt32(txt_idcardter.Text.ToString()));
                    command.Parameters.AddWithValue("@TimeTerapy", txt_timeter.Text);
                    command.Parameters.AddWithValue("@DateTerapy", dp_dateter.SelectedDate);
                    command.Parameters.AddWithValue("@ProcedureTer", txt_procedter.Text);
                    command.Parameters.AddWithValue("@Analiz", txt_analiz.Text);
                    command.Parameters.AddWithValue("@Report", txt_report.Text);
                    command.ExecuteNonQuery();
                    con.Close();
                }
                string command1 = "SELECT * FROM Terapy";
                LoadDataGrid(Grid_Terapy, command1);*/
            }
        }
        /*|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||*/
        /*----------------------------------!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!-------------------------------*/
        /*|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||*/


        /*|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||*/
        /*----------------------------------SQL-Добавление / Изменение / Удаление Карт-------------------------------*/
        /*|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||*/
        private async void btn_addC_Click(object sender, RoutedEventArgs e)
        {
            if ((txt_idp.Text == "") || (txt_diagnosis.Text == "") || (txt_annot.Text == "") || (txt_inoc.Text == ""))
            {
                await this.ShowMessageAsync("Неверные данные", "Пожалуйста, заполните ВСЕ поля!");
            }
            else
            {
                var controller = await this.ShowProgressAsync("Подождите...", "Идёт добавление...");
                try
                {
                    await Task.Delay(500);
                    controller.SetCancelable(false);
                    using (SqlConnection con = new SqlConnection(DBConnectionString))
                    {
                        string SQLString = string.Format("INSERT INTO Card_Patient" +
                           "(ID_PatientCD, Diagnosis, Annotation, Inoculations) VALUES(@IDPatient, @Diagnosis, @Annotation, @Inoculations)");
                        con.Open();
                        using (SqlCommand command = new SqlCommand(SQLString, con))
                        {
                            command.Parameters.AddWithValue("@IDPatient", txt_idp.Text);
                            command.Parameters.AddWithValue("@Diagnosis", txt_diagnosis.Text);
                            command.Parameters.AddWithValue("@Annotation", txt_annot.Text);
                            command.Parameters.AddWithValue("@Inoculations", txt_inoc.Text);
                            command.ExecuteNonQuery();
                        }
                        con.Close();
                        string command1 = "SELECT * FROM Card_Patient";
                        LoadDataGrid(Grid_Cards, command1);
                        btn_addC_Cancel(sender, e);

                        await controller.CloseAsync();
                        await this.ShowMessageAsync("Успешно!", "Данные успешно добавлены!");
                    }
                }
                catch (Exception ex)
                {
                    await controller.CloseAsync();
                    await this.ShowMessageAsync("Неудача!", ex.ToString());
                }
            }
        }
        private async void btn_editC_Click(object sender, RoutedEventArgs e)
        {
            if ((txt_idp_edit.Text == "") || (txt_diagnosis_edit.Text == "") || (txt_annot_edit.Text == "") || (txt_inoc_edit.Text == ""))
            {
                await this.ShowMessageAsync("Неверные данные", "Пожалуйста, заполните ВСЕ поля!");
            }
            else
            {
                var controller = await this.ShowProgressAsync("Подождите...", "Идёт добавление...");
                try
                {
                    await Task.Delay(500);
                    controller.SetCancelable(false);
                    DataRowView rowView = Grid_Cards.SelectedValue as DataRowView;
                    if (Grid_Cards.SelectedIndex > -1)
                    {
                        using (SqlConnection con = new SqlConnection(DBConnectionString))
                        {
                            string SQLString = string.Format("UPDATE Card_Patient SET ID_PatientCD = @IDPatient, Diagnosis = @Diagnosis, Annotation = @Annotation, Inoculations = @Inoculations WHERE ID_Card = " + rowView[0].ToString() + ";");
                            con.Open();
                            using (SqlCommand command = new SqlCommand(SQLString, con))
                            {
                                command.Parameters.AddWithValue("@IDPatient", txt_idp_edit.Text);
                                command.Parameters.AddWithValue("@Diagnosis", txt_diagnosis_edit.Text);
                                command.Parameters.AddWithValue("@Annotation", txt_annot_edit.Text);
                                command.Parameters.AddWithValue("@Inoculations", txt_inoc_edit.Text);
                                command.ExecuteNonQuery();
                            }
                            con.Close();
                            string command1 = "SELECT * FROM Card_Patient";
                            LoadDataGrid(Grid_Cards, command1);

                            await controller.CloseAsync();
                            await this.ShowMessageAsync("Успешно!", "Данные успешно обновлены!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    await controller.CloseAsync();
                    await this.ShowMessageAsync("Неудача!", ex.ToString());
                }
            }
        }
        private async void RightPanelDeleteCard(object sender, MouseButtonEventArgs e)
        {
            DataRowView rowView = Grid_Cards.SelectedValue as DataRowView;
            if (Grid_Cards.SelectedIndex > -1)
            {
                var res = await this.ShowMessageAsync("Подтверждение", "Действительно ли Вы хотите удалить!", MessageDialogStyle.AffirmativeAndNegative);
                if (res == MessageDialogResult.Affirmative)
                {
                    using (SqlConnection con = new SqlConnection(DBConnectionString))
                    {
                        string SQLString = string.Format("DELETE FROM Card_Patient WHERE ID_Card=" + rowView[0].ToString() + ";");
                        con.Open();
                        using (SqlCommand command = new SqlCommand(SQLString, con))
                        {
                            command.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                    string command1 = "SELECT * FROM Card_Patient";
                    LoadDataGrid(Grid_Cards, command1);
                }
            }
        }
        /*|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||*/
        /*----------------------------------!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!-------------------------------*/
        /*|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||*/

        /*|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||*/
        /*----------------------------------SQL-Добавление / Изменение / Удаление Врачей-------------------------------*/
        /*|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||*/
        private async void btn_addD_Click(object sender, RoutedEventArgs e)
        {
            if ((txtfam_doc.Text == "") || (txtname_doc.Text == "") || (txtotch_doc.Text == "") || (txtadress_doc.Text == "") || (txtphone_doc.Text == "") || (txtcabinet.Text == "") ||
                (cmbpol_doc.SelectedIndex == -1) || (cmbspec.SelectedIndex == -1) || (dpbirth_doc.SelectedDate == null))
            {
                await this.ShowMessageAsync("Неверные данные", "Пожалуйста, заполните ВСЕ поля!");
            }
            else
            {
                var controller = await this.ShowProgressAsync("Подождите...", "Идёт добавление...");
                try
                {
                    await Task.Delay(500);
                    controller.SetCancelable(false);
                    using (SqlConnection con = new SqlConnection(DBConnectionString))
                    {
                        string SQLString = string.Format("INSERT INTO Doctors" +
                           "(LastName_Doc, Name_Doc, MiddleName_Doc, Pol_Doc, Date_Birth_Doc, Adress_Doc, Phone_Doc, ID_Occupation_Doc, Cabinet) VALUES(@FamiliyaP, @NameP, @OtchestvoP, @Pol, @DateBirth, @Adress, @Phone, @Occupation, @Cabinet)");
                        con.Open();
                        using (SqlCommand command = new SqlCommand(SQLString, con))
                        {
                            command.Parameters.AddWithValue("@FamiliyaP", txtfam_doc.Text);
                            command.Parameters.AddWithValue("@NameP", txtname_doc.Text);
                            command.Parameters.AddWithValue("@OtchestvoP", txtotch_doc.Text);
                            command.Parameters.AddWithValue("@Pol", cmbpol_doc.SelectionBoxItem);
                            command.Parameters.AddWithValue("@DateBirth", dpbirth_doc.SelectedDate);
                            command.Parameters.AddWithValue("@Adress", txtadress_doc.Text);
                            command.Parameters.AddWithValue("@Phone", txtphone_doc.Text);
                            command.Parameters.AddWithValue("@Occupation", cmbspec.SelectedValue);
                            command.Parameters.AddWithValue("@Cabinet", txtcabinet.Text);
                            command.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                    string command1 = "SELECT * FROM View_Doctors";
                    LoadDataGrid(Grid_Doctors, command1);
                    btn_add_doc_Cancel(sender, e);

                    await controller.CloseAsync();
                    await this.ShowMessageAsync("Успешно!", "Данные успешно добавлены!");
                }
                catch (Exception ex)
                {
                    await controller.CloseAsync();
                    await this.ShowMessageAsync("Неудача!", ex.ToString());
                }
            }
        }
        private async void btn_editD_Click(object sender, RoutedEventArgs e)
        {

            if ((txt_famd_edit.Text == "") || (txt_named_edit.Text == "") || (txt_otchd_edit.Text == "") || (txt_adressd_edit.Text == "") || (txt_phoned_edit.Text == "") || (txt_cabinet.Text == "") ||
                (cmb_pold_edit.SelectedIndex == -1) || (cmb_spec.SelectedIndex == -1))
            {
                await this.ShowMessageAsync("Неверные данные", "Пожалуйста, заполните ВСЕ поля!");
            }
            else
            {
                var controller = await this.ShowProgressAsync("Подождите...", "Идёт добавление...");
                try
                {
                    await Task.Delay(500);
                    controller.SetCancelable(false);
                    DataRowView rowView = Grid_Doctors.SelectedValue as DataRowView;
                    if (Grid_Doctors.SelectedIndex > -1)
                    {
                        using (SqlConnection con = new SqlConnection(DBConnectionString))
                        {
                            string SQLString = string.Format("UPDATE Doctors SET LastName_Doc =  @FamiliyaP, Name_Doc = @NameP, MiddleName_Doc = @OtchestvoP, Pol_Doc = @Pol, Date_Birth_Doc = @DateBirth, Adress_Doc = @Adress, Phone_Doc = @Phone, ID_Occupation_Doc = @Occupation, Cabinet = @Cabinet WHERE ID_Doctor = " + rowView[0].ToString() + ";");
                            con.Open();

                            using (SqlCommand command = new SqlCommand(SQLString, con))
                            {
                                command.Parameters.AddWithValue("@FamiliyaP", txt_famd_edit.Text);
                                command.Parameters.AddWithValue("@NameP", txt_named_edit.Text);
                                command.Parameters.AddWithValue("@OtchestvoP", txt_otchd_edit.Text);
                                command.Parameters.AddWithValue("@Pol", cmb_pold_edit.SelectionBoxItem);
                                command.Parameters.AddWithValue("@DateBirth", dp_birth_edit.SelectedDate);
                                command.Parameters.AddWithValue("@Adress", txt_adressd_edit.Text);
                                command.Parameters.AddWithValue("@Phone", txt_phoned_edit.Text);
                                command.Parameters.AddWithValue("@Occupation", cmb_spec.SelectedValue);
                                command.Parameters.AddWithValue("@Cabinet", txt_cabinet.Text);
                                command.ExecuteNonQuery();
                            }
                            con.Close();
                        }
                        string command1 = "SELECT * FROM View_Doctors";
                        LoadDataGrid(Grid_Doctors, command1);
                        btn_edit_doc_Cancel(sender, e);

                        await controller.CloseAsync();
                        await this.ShowMessageAsync("Успешно!", "Данные успешно обновлены!");
                    }
                }
                catch (Exception ex)
                {
                    await controller.CloseAsync();
                    await this.ShowMessageAsync("Неудача!", ex.ToString());
                }
            }
        }
        private async void RightPanelDeleteDoctors(object sender, MouseButtonEventArgs e)
        {
            DataRowView rowView = Grid_Doctors.SelectedValue as DataRowView;
            if (Grid_Doctors.SelectedIndex > -1)
            {
                var res = await this.ShowMessageAsync("Подтверждение", "Действительно ли Вы хотите удалить!", MessageDialogStyle.AffirmativeAndNegative);
                if (res == MessageDialogResult.Affirmative)
                /*MessageBoxResult result = MessageBox.Show("Действительно ли Вы хотите удалить!", "Удаление врача", MessageBoxButton.OKCancel, MessageBoxImage.Question);
                if (result == MessageBoxResult.OK)*/
                {
                    using (SqlConnection con = new SqlConnection(DBConnectionString))
                    {
                        string SQLString = string.Format("DELETE FROM Doctors WHERE ID_Doctor=" + rowView[0].ToString() + ";");
                        con.Open();
                        using (SqlCommand command = new SqlCommand(SQLString, con))
                        {
                            command.ExecuteNonQuery();
                        }
                        con.Close();
                    }
                    string command1 = "SELECT * FROM View_Doctors";
                    LoadDataGrid(Grid_Doctors, command1);
                }
            }
        }
        /*|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||*/
        /*----------------------------------!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!-------------------------------*/
        /*|||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||||*/

        private void metroWindow_Closed(object sender, EventArgs e)
        {
            Application.Current.Shutdown();
        }
        /*---------------------------------------Очистка компонентов-------------------------------------------------*/
        private void btn_addP_Cancel(object sender, RoutedEventArgs e)
        {
            rightpanelAdd = PanelAnimation("RightPanelOpen", "RightPanelClose", rightpanelAdd);
            txtfamp.Text = "";
            txtnamep.Text = "";
            txtotchp.Text = "";
            cmbpolp.SelectedIndex = 0;
            txtadressp.Text = "";
            cmbcityp.SelectedIndex = 0;
            txtphonep.Text = "";
            dpbirth.SelectedDate = null;
            Grid_Pacient.SelectedIndex = -1;
        }
        private void btn_editP_Cancel(object sender, RoutedEventArgs e)
        {
            rightpanelEdit = PanelAnimation("RightPanelEditOpen", "RightPanelEditClose", rightpanelEdit);
            txt_famp.Clear();
            txt_namep.Clear();
            txt_otchp.Clear();
            txt_adressp.Clear();
            txt_phonep.Clear();
            cmb_polp.SelectedIndex = 0;
            cmb_cityp.SelectedIndex = 0;
            dp_birth.SelectedDate = null;
            Grid_Pacient.SelectedIndex = -1;
        }
        private void btn_addC_Cancel(object sender, RoutedEventArgs e)
        {
            rightpaneladdcard = PanelAnimation("RightPanelCardOpen", "RightPanelCardClose", rightpaneladdcard);
            txt_idp.Clear();
            txt_diagnosis.Clear();
            txt_annot.Clear();
            txt_inoc.Clear();
            Grid_Cards.SelectedIndex = -1;
        }
        private void btn_editC_Cancel(object sender, RoutedEventArgs e)
        {
            rightpaneleditcard = PanelAnimation("RightPanelCardEditOpen", "RightPanelCardEditClose", rightpaneleditcard);
            txt_idp_edit.Clear();
            txt_diagnosis_edit.Clear();
            txt_annot_edit.Clear();
            txt_inoc_edit.Clear();
            Grid_Cards.SelectedIndex = -1;
        }
        private void btn_add_doc_Cancel(object sender, RoutedEventArgs e)
        {
            rightpaneladddoc = PanelAnimation("PanelAddDoctorOpen", "PanelAddDoctorClose", rightpaneladddoc);
            txtfam_doc.Clear();
            txtname_doc.Clear();
            txtotch_doc.Clear();
            cmbpol_doc.SelectedIndex = 0;
            txtadress_doc.Clear();
            txtphone_doc.Clear();
            txtcabinet.Clear();
            cmbspec.SelectedIndex = 0;
            Grid_Doctors.SelectedIndex = -1;
        }
        private void btn_edit_doc_Cancel(object sender, RoutedEventArgs e)
        {
            rightpaneleditdoc = PanelAnimation("PanelEditDoctorOpen", "PanelEditDoctorClose", rightpaneleditdoc);
            txt_famd_edit.Clear();
            txt_named_edit.Clear();
            txt_otchd_edit.Clear();
            cmb_pold_edit.SelectedIndex = 0;
            dp_birth_edit.SelectedDate = null;
            txt_adressd_edit.Clear();
            txt_phoned_edit.Clear();
            txt_cabinet.Clear();
            cmb_spec.SelectedIndex = 0;
            Grid_Doctors.SelectedIndex = -1;
        }
        /*---------------------------------------!!!!!!!!!!!!!!!!!!!-------------------------------------------------*/

        /*---------------------------------------Поиск-Header------------------------!!!!!!!-------------------------*/
        private void btn_search(object sender, RoutedEventArgs e)
        {
            
            {
                if (metroTabControl.SelectedIndex == 0)
                    LoadDataGrid(Grid_Pacient, "SELECT * FROM View_Pacients WHERE LastName_PT LIKE N'%" + txt_search.Text + "%';");
                else if (metroTabControl.SelectedIndex == 1)
                    LoadDataGrid(Grid_Cards, "SELECT * FROM Card_Patient WHERE ID_Card LIKE N'%" + txt_search.Text + "%';");
                else if (metroTabControl.SelectedIndex == 2)
                    LoadDataGrid(Grid_Doctors, "SELECT * FROM View_Doctors WHERE LastName_Doc LIKE N'%" + txt_search.Text + "%';");
                else if (metroTabControl.SelectedIndex == 3)
                    LoadDataGrid(Grid_Talons, "SELECT * FROM Test WHERE Name LIKE '%" + txt_search.Text + "%';");
            }
        }

        private void txt_search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (metroTabControl.SelectedIndex == 0)
                LoadDataGrid(Grid_Pacient, "SELECT * FROM View_Pacients WHERE LastName_PT LIKE N'%" + txt_search.Text + "%';");
        }

        private void RightPanelViewVisit(object sender, MouseButtonEventArgs e)
        {
            if (Grid_Pacient_Visit.IsVisible == false)
            {
                Grid_Pacient_Visit.Visibility = Visibility.Visible;
                Grid_Pacient.Visibility = Visibility.Hidden;
            }
            else if (Grid_Pacient_Visit.IsVisible == true)
            {
                Grid_Pacient_Visit.Visibility = Visibility.Hidden;
                Grid_Pacient.Visibility = Visibility.Visible;
            }
        }

        private void rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            btn = PanelAnimation("Btn_ADD", "Btn_ADD_Close", btn);
        }

        private void Btn_Search_Visit_MouseUp(object sender, MouseButtonEventArgs e)
        {
            ModalWindow passwordWindow = new ModalWindow();

            if (passwordWindow.ShowDialog() == true)
            {
                DataSet dataSet = null;
                using (SqlConnection con = new SqlConnection(DBConnectionString))
                {
                    try
                    {
                        using (SqlCommand cmd = new SqlCommand("[dbo.Procedure_Search_Visit_Patient]", con))
                        {
                            con.Open();
                            cmd.Connection = con;
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.CommandText = "Procedure_Search_Visit_Patient";
                            SqlParameter param = new SqlParameter();
                            param.ParameterName = "@ID_Pacient";
                            param.Value = passwordWindow.Password;
                            param.SqlDbType = SqlDbType.Int;
                            param.Direction = ParameterDirection.Input;
                            cmd.Parameters.Add(param);
                            cmd.ExecuteNonQuery();
                            try
                            {
                                SqlDataAdapter adapter = new SqlDataAdapter();
                                adapter.SelectCommand = cmd;
                                DataTable dt = new DataTable();
                                dataSet = new DataSet();
                                adapter.Fill(dt);
                                Grid_Pacient_Visit.ItemsSource = dt.DefaultView;
                            }
                            catch (SqlException x)
                            {
                                // messages.Text += x.Message;
                            }
                            con.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Неверные данные!");
                    }
                }
            }
        }
        /*--------------------------------ИЗМЕНЕНИЕ ЦВЕТА ПРИ НАВЕДЕНИИ------------------------------------------*/
        private void Panel_ADD_Patient_MouseEnter(object sender, MouseEventArgs e)
        {
            Panel_ADD_Patient.Background = new SolidColorBrush(Color.FromRgb(59, 144, 145));

        }
        private void Panel_ADD_Patient_MouseLeave(object sender, MouseEventArgs e)
        {
            Panel_ADD_Patient.Background = new SolidColorBrush(Color.FromRgb(73, 167, 168));
        }

        private void Panel_Edit_Patient_MouseEnter(object sender, MouseEventArgs e)
        {
            Panel_Edit_Patient.Background = new SolidColorBrush(Color.FromRgb(59, 144, 145));
        }
        private void Panel_Edit_Patient_MouseLeave(object sender, MouseEventArgs e)
        {
            Panel_Edit_Patient.Background = new SolidColorBrush(Color.FromRgb(73, 167, 168));
        }

        private void Panel_Del_Patient_MouseEnter(object sender, MouseEventArgs e)
        {
            Panel_Del_Patient.Background = new SolidColorBrush(Color.FromRgb(59, 144, 145));
        }
        private void Panel_Del_Patient_MouseLeave(object sender, MouseEventArgs e)
        {
            Panel_Del_Patient.Background = new SolidColorBrush(Color.FromRgb(73, 167, 168));
        }

        private void Panel_View_Patient_MouseEnter(object sender, MouseEventArgs e)
        {
            Panel_View_Patient.Background = new SolidColorBrush(Color.FromRgb(59, 144, 145));
        }

        private void Panel_View_Patient_MouseLeave(object sender, MouseEventArgs e)
        {
            Panel_View_Patient.Background = new SolidColorBrush(Color.FromRgb(73, 167, 168));
        }

        private void Panel_ADD_Card_MouseEnter(object sender, MouseEventArgs e)
        {
            Panel_ADD_Card.Background = new SolidColorBrush(Color.FromRgb(59, 144, 145));
        }

        private void Panel_ADD_Card_MouseLeave(object sender, MouseEventArgs e)
        {
            Panel_ADD_Card.Background = new SolidColorBrush(Color.FromRgb(73, 167, 168));
        }

        private void Panel_Edit_Card_MouseEnter(object sender, MouseEventArgs e)
        {
            Panel_Edit_Card.Background = new SolidColorBrush(Color.FromRgb(59, 144, 145));
        }

        private void Panel_Edit_Card_MouseLeave(object sender, MouseEventArgs e)
        {
            Panel_Edit_Card.Background = new SolidColorBrush(Color.FromRgb(73, 167, 168));
        }

        private void Panel_Del_Card_MouseEnter(object sender, MouseEventArgs e)
        {
            Panel_Del_Card.Background = new SolidColorBrush(Color.FromRgb(59, 144, 145));
        }

        private void Panel_Del_Card_MouseLeave(object sender, MouseEventArgs e)
        {
            Panel_Del_Card.Background = new SolidColorBrush(Color.FromRgb(73, 167, 168));
        }

        private void Panel_View_Therapy_MouseEnter(object sender, MouseEventArgs e)
        {
            Panel_View_Therapy.Background = new SolidColorBrush(Color.FromRgb(59, 144, 145));
        }

        private void Panel_View_Therapy_MouseLeave(object sender, MouseEventArgs e)
        {
            Panel_View_Therapy.Background = new SolidColorBrush(Color.FromRgb(73, 167, 168));
        }

        private void Panel_ADD_Doc_MouseEnter(object sender, MouseEventArgs e)
        {
            Panel_ADD_Doc.Background = new SolidColorBrush(Color.FromRgb(59, 144, 145));
        }

        private void Panel_ADD_Doc_MouseLeave(object sender, MouseEventArgs e)
        {
            Panel_ADD_Doc.Background = new SolidColorBrush(Color.FromRgb(73, 167, 168));
        }

        private void Panel_Edit_Doc_MouseEnter(object sender, MouseEventArgs e)
        {
            Panel_Edit_Doc.Background = new SolidColorBrush(Color.FromRgb(59, 144, 145));
        }

        private void Panel_Edit_Doc_MouseLeave(object sender, MouseEventArgs e)
        {
            Panel_Edit_Doc.Background = new SolidColorBrush(Color.FromRgb(73, 167, 168));
        }

        private void Panel_Del_Doc_MouseEnter(object sender, MouseEventArgs e)
        {
            Panel_Del_Doc.Background = new SolidColorBrush(Color.FromRgb(59, 144, 145));
        }

        private void Panel_Del_Doc_MouseLeave(object sender, MouseEventArgs e)
        {
            Panel_Del_Doc.Background = new SolidColorBrush(Color.FromRgb(73, 167, 168));
        }

        private void Panel_View_Sched_MouseEnter(object sender, MouseEventArgs e)
        {
            Panel_View_Sched.Background = new SolidColorBrush(Color.FromRgb(59, 144, 145));
        }

        private void Panel_View_Sched_MouseLeave(object sender, MouseEventArgs e)
        {
            Panel_View_Sched.Background = new SolidColorBrush(Color.FromRgb(73, 167, 168));
        }

        /*-----------------------------------------!!!!!!!!!!!!!!!!!!!!!!!-----------------------------------------------*/
        private void Grid_Pacient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = Grid_Pacient.SelectedValue as DataRowView;
            if (Grid_Pacient.SelectedIndex > -1)
            {
                txt_famp.Text = rowView[1].ToString();
                txt_namep.Text = rowView[2].ToString();
                txt_otchp.Text = rowView[3].ToString();
                cmb_polp.Text = rowView[4].ToString();
                dp_birth.SelectedDate = Convert.ToDateTime(rowView[5].ToString());
                txt_phonep.Text = rowView[6].ToString();
                cmb_cityp.Text = rowView[7].ToString();
                txt_adressp.Text = rowView[8].ToString();
            }
        }
        private void Grid_Cards_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = Grid_Cards.SelectedValue as DataRowView;
            if (Grid_Cards.SelectedIndex > -1)
            {
                txt_idp_edit.Text = rowView[1].ToString();
                txt_diagnosis_edit.Text = rowView[2].ToString();
                txt_annot_edit.Text = rowView[3].ToString();
                txt_inoc_edit.Text = rowView[4].ToString();
            }
        }
        private void Grid_Doctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataRowView rowView = Grid_Doctors.SelectedValue as DataRowView;
            if (Grid_Doctors.SelectedIndex > -1)
            {
                txt_famd_edit.Text = rowView[1].ToString();
                txt_named_edit.Text = rowView[2].ToString();
                txt_otchd_edit.Text = rowView[3].ToString();
                cmb_pold_edit.Text = rowView[4].ToString();
                dp_birth_edit.Text = rowView[5].ToString();
                txt_adressd_edit.Text = rowView[6].ToString();
                txt_phoned_edit.Text = rowView[7].ToString();
                cmb_spec.Text = rowView[8].ToString();
                txt_cabinet.Text = rowView[9].ToString();
            }
        }

        private void txtcabinet_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            TextBox ctrl = sender as TextBox;
            e.Handled = "0123456789".IndexOf(e.Text) < 0;
            ctrl.MaxLength = 4;
        }

        private void txtcabinet_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Space))
            {
                e.Handled = true;
            }
        }

        private void RightPanelViewSchedule(object sender, MouseButtonEventArgs e)
        {
            if (Grid_Schedule.IsVisible == false)
            {
                Grid_Schedule.Visibility = Visibility.Visible;
                Grid_Doctors.Visibility = Visibility.Hidden;
            }
            else if (Grid_Schedule.IsVisible == true)
            {
                Grid_Schedule.Visibility = Visibility.Hidden;
                Grid_Doctors.Visibility = Visibility.Visible;
            }
            /*if (metroTabControl.SelectedIndex == 2)
            {
                Grid_Schedule.Visibility = Visibility.Hidden;
            }
            Grid_Schedule.Visibility = Visibility;*/
        }

        private void Doctors_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Doctors.IsSelected == false && Grid_Doctors.IsVisible == false)
            {
                rightpaneladddoc = PanelAnimationClose("PanelAddDoctorClose", rightpaneladddoc);
                Grid_Schedule.Visibility = Visibility.Hidden;
                Grid_Doctors.Visibility = Visibility.Visible;
            }
        }

        private void metroWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Grid_Pacient.SelectedIndex = -1;
                Grid_Doctors.SelectedIndex = -1;
                Grid_Cards.SelectedIndex = -1;
            }
        }

        private void Patient_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (Patient.IsSelected == false && Grid_Pacient.IsVisible == false)
            {
                Grid_Pacient_Visit.Visibility = Visibility.Hidden;
                Grid_Pacient.Visibility = Visibility.Visible;
            }
        }

        private async void Btn_ADD_Schedule_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Window_Add_Schedule ScheduleWindow = new Window_Add_Schedule();
            if (ScheduleWindow.ShowDialog() == true)
            {
                if ((ScheduleWindow.txt_id_doctor.Text == "") || (ScheduleWindow.txt_time_on.Text == "") || (ScheduleWindow.txt_time_off.Text == "") ||
                (ScheduleWindow.dp_schedule.SelectedDate == null))
                {
                    await this.ShowMessageAsync("Неверные данные", "Пожалуйста, заполните ВСЕ поля!");
                }
                else
                {
                    var controller = await this.ShowProgressAsync("Подождите...", "Идёт добавление...");
                    try
                    {
                        await Task.Delay(500);
                        controller.SetCancelable(false);
                        using (SqlConnection con = new SqlConnection(DBConnectionString))
                        {
                            string SQLString = string.Format("INSERT INTO Schedule_Doc" +
                               "(ID_Doc, Date_of_Appointment_Doc, Time_ON_Doc, Time_OFF_Doc) VALUES(@IDDoc, @Date, @TimeON, @TimeOFF)");
                            con.Open();
                            using (SqlCommand command = new SqlCommand(SQLString, con))
                            {
                                command.Parameters.AddWithValue("@IDDoc", ScheduleWindow.IDDoc);
                                command.Parameters.AddWithValue("@TimeON", ScheduleWindow.TimeON);
                                command.Parameters.AddWithValue("@TimeOFF", ScheduleWindow.TimeOFF);
                                command.Parameters.AddWithValue("@Date", ScheduleWindow.DPDate);
                                command.ExecuteNonQuery();
                            }
                            con.Close();
                        }
                        string command1 = "SELECT * FROM View_Schedule_Doc";
                        LoadDataGrid(Grid_Schedule, command1);

                        await controller.CloseAsync();
                        await this.ShowMessageAsync("Успешно!", "Данные успешно добавлены!");
                    }
                    catch (Exception ex)
                    {
                        await controller.CloseAsync();
                        await this.ShowMessageAsync("Неудача!", ex.ToString());
                    }
                }
            }
        }

        /*---------------------------АНИМАЦИЯ БАЗОВЫЙ МЕТОД---------------------------------------------*/
        public bool PanelAnimation(string storyboardNameOpen, string storyboardNameClose, bool active)
        {
            if (active)
            {
                Storyboard storyboard = this.FindResource(storyboardNameClose) as Storyboard;
                storyboard.Begin();
                active = !active;
            }
            else
            {
                Storyboard storyboard = this.FindResource(storyboardNameOpen) as Storyboard;
                storyboard.Begin();
                active = !active;
            }
            return active;
        }
        public bool PanelAnimationClose(string storyboardNameClose, bool active)
        {
            if (active)
            {
                Storyboard storyboard = this.FindResource(storyboardNameClose) as Storyboard;
                storyboard.Begin();
                active = !active;
            }
            return active;
        }
        /*---------------------------!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!----------------------------------*/
        /*---------------------------АНИМАЦИЯ ОТКРЫТИЯ САЙДБАРОВ-----------------------------------------*/
        public void RightPanelAddPacient(object sender, MouseButtonEventArgs e)
        {
            if (metroTabControl.SelectedIndex == 0)
            {
                rightpanelAdd = PanelAnimation("RightPanelOpen", "RightPanelClose", rightpanelAdd);
                if (rightpanelEdit)
                    rightpanelEdit = PanelAnimation("RightPanelEditOpen", "RightPanelEditClose", rightpanelEdit);
                else
                    if (rightpanelTer)
                    rightpanelTer = PanelAnimation("RightPanelTerOpen", "RightPanelTerClose", rightpanelTer);
                else
                        if (rightpaneladdcard)
                    rightpaneladdcard = PanelAnimation("RightPanelCardOpen", "RightPanelCardClose", rightpaneladdcard);
                else
                            if (rightpaneleditcard)
                    rightpaneleditcard = PanelAnimation("RightPanelCardEditOpen", "RightPanelCardEditClose", rightpaneleditcard);
                else
                                if (rightpaneladddoc)
                    rightpaneladddoc = PanelAnimation("PanelAddDoctorOpen", "PanelAddDoctorClose", rightpaneladddoc);
                else
                                    if (rightpaneleditdoc)
                        rightpaneleditdoc = PanelAnimation("PanelEditDoctorOpen", "PanelEditDoctorClose", rightpaneleditdoc);
            }
        }
        public void RightPanelEditPacient(object sender, MouseButtonEventArgs e)
        {
            rightpanelEdit = PanelAnimation("RightPanelEditOpen", "RightPanelEditClose", rightpanelEdit);
            if (rightpanelAdd)
                rightpanelAdd = PanelAnimation("RightPanelOpen", "RightPanelClose", rightpanelAdd);
            else
                if (rightpanelTer)
                rightpanelTer = PanelAnimation("RightPanelTerOpen", "RightPanelTerClose", rightpanelTer);
            else
                    if (rightpaneladdcard)
                rightpaneladdcard = PanelAnimation("RightPanelCardOpen", "RightPanelCardClose", rightpaneladdcard);
            else
                        if (rightpaneleditcard)
                rightpaneleditcard = PanelAnimation("RightPanelCardEditOpen", "RightPanelCardEditClose", rightpaneleditcard);
            else
                                if (rightpaneladddoc)
                rightpaneladddoc = PanelAnimation("PanelAddDoctorOpen", "PanelAddDoctorClose", rightpaneladddoc);
            else
                                    if (rightpaneleditdoc)
                rightpaneleditdoc = PanelAnimation("PanelEditDoctorOpen", "PanelEditDoctorClose", rightpaneleditdoc);
        }
        public void RightPanelAddCard(object sender, MouseButtonEventArgs e)
        {
            rightpaneladdcard = PanelAnimation("RightPanelCardOpen", "RightPanelCardClose", rightpaneladdcard);
            if (rightpanelAdd)
                rightpanelAdd = PanelAnimation("RightPanelOpen", "RightPanelClose", rightpanelAdd);
            else
                if (rightpanelEdit)
                rightpanelEdit = PanelAnimation("RightPanelEditOpen", "RightPanelEditClose", rightpanelEdit);
            else
                    if (rightpanelTer)
                rightpanelTer = PanelAnimation("RightPanelTerOpen", "RightPanelTerClose", rightpanelTer);
            else
                        if (rightpaneleditcard)
                rightpaneleditcard = PanelAnimation("RightPanelCardEditOpen", "RightPanelCardEditClose", rightpaneleditcard);
            else
                                if (rightpaneladddoc)
                rightpaneladddoc = PanelAnimation("PanelAddDoctorOpen", "PanelAddDoctorClose", rightpaneladddoc);
            else
                                    if (rightpaneleditdoc)
                rightpaneleditdoc = PanelAnimation("PanelEditDoctorOpen", "PanelEditDoctorClose", rightpaneleditdoc);
        }
        public void RightPanelEditCards(object sender, MouseButtonEventArgs e)
        {
            rightpaneleditcard = PanelAnimation("RightPanelCardEditOpen", "RightPanelCardEditClose", rightpaneleditcard);
            if (rightpanelAdd)
                rightpanelAdd = PanelAnimation("RightPanelOpen", "RightPanelClose", rightpanelAdd);
            else
                if (rightpanelEdit)
                rightpanelEdit = PanelAnimation("RightPanelEditOpen", "RightPanelEditClose", rightpanelEdit);
            else
                    if (rightpanelTer)
                rightpanelTer = PanelAnimation("RightPanelTerOpen", "RightPanelTerClose", rightpanelTer);
            else
                        if (rightpaneladdcard)
                rightpaneladdcard = PanelAnimation("RightPanelCardOpen", "RightPanelCardClose", rightpaneladdcard);
            else
                                if (rightpaneladddoc)
                rightpaneladddoc = PanelAnimation("PanelAddDoctorOpen", "PanelAddDoctorClose", rightpaneladddoc);
            else
                                    if (rightpaneleditdoc)
                    rightpaneleditdoc = PanelAnimation("PanelEditDoctorOpen", "PanelEditDoctorClose", rightpaneleditdoc);
        }
        public void RightPanelAddDoctor(object sender, MouseButtonEventArgs e)
        {
            rightpaneladddoc = PanelAnimation("PanelAddDoctorOpen", "PanelAddDoctorClose", rightpaneladddoc);
            if (rightpanelAdd)
                rightpanelAdd = PanelAnimation("RightPanelOpen", "RightPanelClose", rightpanelAdd);
            else
                if (rightpanelEdit)
                rightpanelEdit = PanelAnimation("RightPanelEditOpen", "RightPanelEditClose", rightpanelEdit);
            else
                    if (rightpanelTer)
                rightpanelTer = PanelAnimation("RightPanelTerOpen", "RightPanelTerClose", rightpanelTer);
            else
                        if (rightpaneladdcard)
                rightpaneladdcard = PanelAnimation("RightPanelCardOpen", "RightPanelCardOpen", rightpaneladdcard);
            else
                            if (rightpaneleditcard)
                rightpaneleditcard = PanelAnimation("RightPanelCardEditOpen", "RightPanelCardEditClose", rightpaneleditcard);
            else
                                if (rightpaneleditdoc)
                rightpaneleditdoc = PanelAnimation("PanelEditDoctorOpen", "PanelEditDoctorClose", rightpaneleditdoc);
        }
        public void RightPanelEditDoctor(object sender, MouseButtonEventArgs e)
        {
            rightpaneleditdoc = PanelAnimation("PanelEditDoctorOpen", "PanelEditDoctorClose", rightpaneleditdoc);
            if (rightpanelAdd)
                rightpanelAdd = PanelAnimation("RightPanelOpen", "RightPanelClose", rightpanelAdd);
            else
                if (rightpanelEdit)
                rightpanelEdit = PanelAnimation("RightPanelEditOpen", "RightPanelEditClose", rightpanelEdit);
            else
                    if (rightpanelTer)
                rightpanelTer = PanelAnimation("RightPanelTerOpen", "RightPanelTerClose", rightpanelTer);
            else
                        if (rightpaneladdcard)
                rightpaneladdcard = PanelAnimation("RightPanelCardOpen", "RightPanelCardOpen", rightpaneladdcard);
            else
                            if (rightpaneleditcard)
                rightpaneleditcard = PanelAnimation("RightPanelCardEditOpen", "RightPanelCardEditClose", rightpaneleditcard);
            else
                                if (rightpaneladddoc)
                rightpaneladddoc = PanelAnimation("PanelAddDoctorOpen", "PanelAddDoctorClose", rightpaneladddoc);

        }
        public void RightPanelAddTer(object sender, MouseButtonEventArgs e)
        {
            rightpanelTer = PanelAnimation("RightPanelTerOpen", "RightPanelTerClose", rightpanelTer);
            if (rightpanelAdd)
                rightpanelAdd = PanelAnimation("RightPanelOpen", "RightPanelClose", rightpanelAdd);
            else
                if (rightpanelEdit)
                rightpanelEdit = PanelAnimation("RightPanelEditOpen", "RightPanelEditClose", rightpanelEdit);
            else
                    if (rightpaneladdcard)
                rightpaneladdcard = PanelAnimation("RightPanelCardOpen", "RightPanelCardClose", rightpaneladdcard);
            else
                        if (rightpaneleditcard)
                rightpaneleditcard = PanelAnimation("RightPanelCardEditOpen", "RightPanelCardEditClose", rightpaneleditcard);
        }
        /*-------------------------------!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!----------------------------------*/
    }
}
