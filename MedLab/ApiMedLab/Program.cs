using ApiMedLab.Context;
using ApiMedLab.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;
using System.Threading.Tasks;

namespace ApiMedLab
{
    class Program
    {
        static void Main()
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://localhost:9786/");

            JsonSerializerOptions options = new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };
            server.Start();


            while(true)
            {
                //Запроса на получение данных
                HttpListenerContext context = server.GetContext();
                if(context.Request.HttpMethod == "GET")
                {
                    try
                    {
                        if (context.Request.RawUrl == "/api/patient")
                        {
                            var patientList = Data.me.Patient.ToList();
                            string response = JsonSerializer.Serialize(Data.me.Patient.ToList().ConvertAll(p => new ResponsePatient(p)), options);
                            byte[] data = Encoding.UTF8.GetBytes(response);
                            context.Response.ContentType = "application/json;charset=utd-8";
                            using (Stream stream = context.Response.OutputStream)
                            {
                                context.Response.StatusCode = 200;
                                stream.Write(data, 0, data.Length);
                            }

                        }
                        else
                            throw new Exception();
                    }
                    catch
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                    }
                }
                // Запрос на добавление данных
                else if (context.Request.HttpMethod == "POST")
                {
                    try
                    {
                        if (context.Request.RawUrl == "/api/patient")
                        {
                            if (context.Request.ContentType == "application/json")
                            {
                                string request = "";
                                byte[] data = new byte[context.Request.ContentLength64];
                                using (Stream stream = context.Request.InputStream)
                                {
                                    context.Response.StatusCode = 200;
                                    stream.Write(data, 0, data.Length);
                                }
                                request = System.Text.UTF8Encoding.UTF8.GetString(data);
                                var patientList = JsonSerializer.Deserialize<List<ResponsePatient>>(request);
                                foreach (var patient in patientList)
                                {
                                    Patient patients = new Patient();
                                    patients.ID = patient.ID;
                                    patients.FirstName = patient.FirstName;
                                    patients.LastName = patient.LastName;
                                    patients.Patronymic = patient.Patronymic;
                                    patients.DateOfBirth = patient.DateOfBirth;
                                    patients.PSerias = patient.PSerias;
                                    patients.PNumder = patient.PNumder;
                                    patients.Phone = patient.Phone;
                                    patients.Email = patient.Email;
                                    patients.PolicyNumber = patient.PolicyNumber;
                                    patients.IDPolicyType = patient.IDPolicyType;
                                    patients.IDInsuranceCompany = patient.IDInsuranceCompany;
                                    patients.IDRole = patient.IDRole;
                                    Data.me.Patient.Add(patients);
                                }
                                Data.me.SaveChanges();
                                context.Response.StatusCode = 200;
                                context.Response.Close();

                            }
                            else
                                throw new Exception();
                        }
                        else
                            throw new Exception();
                    }
                    catch
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                    }
                }
                // Запрос на удаление данных
                else
                {
                    try
                    {
                        if (context.Request.HttpMethod == "POST")
                        {
                            if (context.Request.QueryString.Count == 1)
                            {
                                if (context.Request.QueryString.Keys[0] == "id")
                                {
                                    int id = Convert.ToInt32(context.Request.QueryString.Get(0));
                                    var currentPatient = Data.me.Patient.FirstOrDefault(p => p.ID == id);
                                    if(currentPatient != null)
                                    {
                                        Data.me.Patient.Remove(currentPatient);
                                        Data.me.SaveChanges();
                                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                                        context.Response.Close();

                                    }
                                }
                                else
                                    throw new Exception();
                            }
                            else
                                throw new Exception();
                        }
                        else
                            throw new Exception();
                    }
                    catch
                    {
                        context.Response.StatusCode = 400;
                        context.Response.Close();
                    }
                }
            }
        }
    }
}
