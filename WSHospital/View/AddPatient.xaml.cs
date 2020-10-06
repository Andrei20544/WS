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
    /// Логика взаимодействия для AddPatient.xaml
    /// </summary>
    public partial class AddPatient : Window
    {
        public AddPatient()
        {
            InitializeComponent();
        }

        public Patients pat;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(ModelDB md = new ModelDB())
            {
                try
                {
                    pat = new Patients
                    {
                        FIO = pFIO.Text,
                        DateOfBirth = DateTime.Parse(pDateOfBirth.Text),
                        Email = pEmail.Text,
                        PassportData = pPassportData.Text,
                        Phone = int.Parse(pPhone.Text),
                        InsurancePolicy = int.Parse(pInsPolicy.Text),
                        TypeOfPolicy = pTypePolicy.Text,
                        IDCompany = 4
                    };

                    md.Patients.Add(pat);
                    md.SaveChanges();

                    MessageBox.Show("Данные успешно созранены в БД");
                }
                catch(Exception ex)
                {
                    MessageBox.Show("Что-то пошло не так!");
                }

            }
        }
    }
}
