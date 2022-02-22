using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Buffers;
using System.Text.Json;
using ApiInventory.Context;
using ApiInventory.Model;
using System.Net;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.IO;

namespace ApiInventory
{
    class Program
    {
        static void Main()
        {
            HttpListener server = new HttpListener();
            server.Prefixes.Add("http://localhost:26738/");

            JsonSerializerOptions options = new JsonSerializerOptions() { Encoder = JavaScriptEncoder.Create(UnicodeRanges.All) };
            server.Start();

            while(true)
            {
                //Запроса на получение данных
                HttpListenerContext context =  server.GetContext();
                if (context.Request.HttpMethod == "GET")
                {
                    try
                    {
                        if (context.Request.RawUrl == "/api/inventoryObject")
                        {
                            var inventoryObjectList = Data.inv.InventoryObject.ToList();
                            string response = JsonSerializer.Serialize(Data.inv.InventoryObject.ToList().ConvertAll(o => new ResponseInventoryObject(o)), options);
                            context.Response.ContentType = "application/json;charset=utf-8";
                            byte[] data = Encoding.UTF8.GetBytes(response);
                            using (Stream stream = context.Response.OutputStream)
                            {
                                context.Response.StatusCode = 200;
                                stream.Read(data, 0, data.Length);
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
                else if(context.Request.HttpMethod == "POST")
                {
                    try
                    {
                        if (context.Request.RawUrl == "/api/inventoryObject")
                        {
                            if (context.Request.ContentType == "application/json")
                            {
                                string request = "";
                                byte[] data = new byte[context.Request.ContentLength64];
                                using (Stream stream = context.Request.InputStream)
                                {
                                    stream.Read(data, 0, data.Length);
                                }
                                request = System.Text.UTF8Encoding.UTF8.GetString(data);
                                var inventoryObjectList = JsonSerializer.Deserialize<List<ResponseInventoryObject>>(request);
                                foreach (var inventoryObject in inventoryObjectList)
                                {
                                    InventoryObject inventoryObjects = new InventoryObject();
                                    inventoryObjects.ID = inventoryObject.ID;
                                    inventoryObjects.Title = inventoryObject.Title;
                                    inventoryObjects.InventoryNumber = inventoryObject.InventoryNumber;
                                    inventoryObjects.CommissioningDate = inventoryObject.CommissioningDate;
                                    inventoryObjects.DocumentationPath = inventoryObject.DocumentationPath;
                                    inventoryObjects.IDType = inventoryObject.IDType;
                                    inventoryObjects.IDSubType = inventoryObject.IDSubType;
                                    inventoryObjects.LifeTime = inventoryObject.LifeTime;
                                    inventoryObjects.IDInvoce = inventoryObject.IDInvoce;
                                    inventoryObjects.IDCurrentStatus = inventoryObject.IDCurrentStatus;
                                    inventoryObjects.Amount = inventoryObject.Amount;
                                    inventoryObjects.IDEmployee = inventoryObject.IDEmployee;
                                    inventoryObjects.IDInventoryObjectDetail = inventoryObject.IDInventoryObjectDetail;
                                    Data.inv.InventoryObject.Add(inventoryObjects);
                                }
                                Data.inv.SaveChanges();
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
                        if (context.Request.HttpMethod == "DELETE")
                        {
                            if (context.Request.QueryString.Count == 1)
                            {
                                if (context.Request.QueryString.Keys[0] == "id")
                                {
                                    int id = Convert.ToInt32(context.Request.QueryString.Get(0));
                                    var currentinventoryObject = Data.inv.InventoryObject.FirstOrDefault(o => o.ID == id);
                                    if (currentinventoryObject != null)
                                    {
                                        Data.inv.InventoryObject.Remove(currentinventoryObject);
                                        Data.inv.SaveChanges();
                                        context.Response.StatusCode = (int)HttpStatusCode.OK;
                                        context.Response.Close();
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
