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
using WSHospital.NewModel;

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using(ModelDB md = new ModelDB())
            {
                AddPat addPat = new AddPat
                {
                    Login = null,
                    Password = null,

                    PFIO = FIO.Text,
                    PDateOfBirth = DateTime.Parse(DateOfBirth.Text),
                    PEmail = Email.Text,
                    PPassportData = PassportData.Text,
                    PPhone = Phone.Text,
                    PInsPolicy = int.Parse(InsPolicy.Text),
                    PTypePolicy = TypePolicy.Text,

                    IdComp = 4
                };

                //var NewPat = from P in md.Patients
                //             select new
                //             {
                //                 pFIO = FIO.Text,
                //                 pDateOfBirth = DateOfBirth.Text,
                //                 pEmail = Email.Text,
                //                 pPassportData = PassportData.Text,
                //                 pPhone = Phone.Text,
                //                 pInsPolicy = InsPolicy.Text,
                //                 pTypePolicy = TypePolicy.Text,
                //                 pIdCompany = 4
                //             };

                md.Entry(NewPat).State = System.Data.Entity.EntityState.Modified;
                md.Patients.Add(NewPat);
                md.SaveChanges();

            }
        }
    }
}
