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
        public ReceptionBioMaterialWindow(Users u, int age)
        {
            InitializeComponent();

            UName.Text = u.FirstName;
            ULName.Text = u.LastName;
            UAge.Text = age.ToString();

            //if (BCode.Text == "")
            //{
            //    MessageBox.Show("Поле для ввода не может быть пустым");
            //}
            //else
            //{
            //    using (Model md = new Model())
            //    {
            //        try
            //        {
            //            var Code = md.LabServices.FirstOrDefault(p => p.ServiceCode.Equals(BCode.Text));

            //            if (Code != null)
            //            {
            //                var BioCode = md.LabServices.Where(p => p.ServiceCode.Equals(BCode.Text)).FirstOrDefault();
                            
            //            }
            //            else
            //            {
            //                MessageBox.Show("Неправильный код. Или же такого кода не существует вовсе!");
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            MessageBox.Show(ex.Message);
            //        }

            //    }
            //}

            using(ModelDB md = new ModelDB())
            {
                var fio = from f in md.Patients
                          select new
                          {
                              FIO = f.FIO
                          };
                foreach(var fi in fio)
                {
                    ComboFIO.Items.Add(fi.FIO);
                }
            }

        }

    }
}
