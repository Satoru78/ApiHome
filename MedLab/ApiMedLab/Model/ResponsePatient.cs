using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiMedLab.Model
{
    public class ResponsePatient
    {
        public ResponsePatient (Patient patient)
        {
            this.ID = patient.ID;
            this.FirstName = patient.   FirstName;
            this.LastName = patient.LastName;
            this.Patronymic = patient.Patronymic;
            this.DateOfBirth = patient.DateOfBirth;
            this.PSerias = patient.PSerias;
            this.PNumder = patient.PNumder;
            this.Phone = patient.Phone;
            this.Email = patient.Email;
            this.PolicyNumber = patient.PolicyNumber;
            this.IDPolicyType = patient.IDPolicyType;
            this.IDInsuranceCompany = patient.IDInsuranceCompany;
            this.IDRole = patient.IDRole;
        }
        public ResponsePatient () { }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public int PSerias { get; set; }
        public int PNumder { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int PolicyNumber { get; set; }
        public int IDPolicyType { get; set; }
        public int IDInsuranceCompany { get; set; }
        public string IDRole { get; set; }
    }
}
