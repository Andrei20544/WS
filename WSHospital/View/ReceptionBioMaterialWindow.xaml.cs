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
using System.Windows.Shapes;

namespace WSHospital.View
{
    /// <summary>
    /// Логика взаимодействия для ReceptionBioMaterialWindow.xaml
    /// </summary>
    public partial class ReceptionBioMaterialWindow : Window
    {
        public ReceptionBioMaterialWindow(Users u, int age, BitmapImage ph)
        {
            InitializeComponent();

            UName.Text = u.FirstName;
            ULName.Text = u.LastName;
            UAge.Text = age.ToString();

            Phot.Source = ph;

            SetComboFio();
        }

        public void SetComboFio()
        {
            using (ModelDB md = new ModelDB())
            {
                Users users = new Users();
                var fio = from f in md.Patients
                          select new
                          {
                              FIO = f.FIO
                          };
                foreach (var fi in fio)
                {
                    ComboFIO.Items.Add(fi.FIO);
                }
            }
        }

        private void ComboFIO_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using(ModelDB md = new ModelDB())
            {
                var pat = md.Patients.FirstOrDefault(p => p.FIO.Contains(ComboFIO.SelectedItem.ToString()));

                if (ComboFIO.SelectedItem.ToString() == pat.FIO)
                {
                    PFIO.Text = pat.FIO;
                    DateOfBirth.Text = pat.DateOfBirth.ToString();
                    PPassportData.Text = pat.PassportData;
                    PEMAIL.Text = pat.Email;
                }

            }
        }

        public LabServices Serv; 
        private void Button_Click(object sender, RoutedEventArgs e)
        {         

            using (ModelDB md = new ModelDB())
            {
                try
                {
                    Serv = new LabServices
                    {
                        Name = ServiceName.Text,
                        Cost = int.Parse(CostServ.Text),
                        ServiceCode = long.Parse(BioCode.Text),
                        Period = DateTime.Parse(PeriodServ.Text),
                        MeanDeviation = MeanDeviationServ.Text
                    };

                    md.LabServices.Add(Serv);
                    md.SaveChanges();

                    MessageBox.Show("Данные успешно созранены в БД");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Что-то пошло не так!");
                }

            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddPatient addPatient = new AddPatient();
            addPatient.Show();

            ComboFIO.Items.Clear();
            SetComboFio();
        }
    }
}
