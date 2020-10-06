using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WSHospital.NewModel
{
    public class AddPat
    {
        public int ID { get; set; }

        public string Login { get; set; }
        public string Password { get; set; }

        public int IdComp { get; set; }

        public string PFIO { get; set; }
        public DateTime PDateOfBirth { get; set; }
        public string PEmail { get; set; }
        public string PPassportData { get; set; }
        public string PPhone { get; set; }
        public int PInsPolicy { get; set; }
        public string PTypePolicy { get; set; }

    //    public AddPat(string fIO, DateTime dateOfBirth, string email, string passportData, string phone, int insPolicy, string typePolicy)
    //    {
    //        PFIO = fIO;
    //        PDateOfBirth = dateOfBirth;
    //        PEmail = email;
    //        PPassportData = passportData;
    //        PPhone = phone;
    //        PInsPolicy = insPolicy;
    //        PTypePolicy = typePolicy;
    //    }
    }
}
