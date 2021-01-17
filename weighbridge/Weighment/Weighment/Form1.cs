using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Net.Http;
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json.Linq;
using System.Net.NetworkInformation;
using System.IO.Ports;
using System.Net.Security;
using System.Text.RegularExpressions;

namespace Weighment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();    
        }
        private string gURL = null;
        private SerialPort _serialPort;         //<-- declares a SerialPort Variable to be used throughout the form
        private const int BaudRate = 9600;      //<-- BaudRate Constant. 9600 seems to be the scale-units default value

        private System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
        public void InitTimer()
        {
            timer1.Tick += new EventHandler(btnconnect_Click);
            timer1.Interval = 100; // in miliseconds
            timer1.Start();
        }

        private void GetVehicle()
        {
          /* bool inpStatus = CheckForInternetConnection();
           if (inpStatus == true)
           {*/
            if (txtuname.Text != "" && txtpwd.Text != "")
            {
                String url = lblurl.Text;
                String tenantid = lbltenantId.Text;
                gURL = "https://" + url + "/rest/getMilkreceiptsVehiclesData/json?login.username=" + txtuname.Text + "&login.password=" + txtpwd.Text + "&tenantId=" + tenantid;

                //   gURL = "https://aavin-uat.milkosoft.in/rest/getMilkreceiptsVehiclesData/json?login.username=wbintegration&login.password=weight&tenantId=" + txttenantid.Text;
                //  gURL = "https://aavin-uat.milkosoft.in/rest/getMilkreceiptsVehiclesData/json?login.username=gopi&login.password=Gopinath&tenantId=" + txttenantid.Text;
                HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(gURL);
                ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                http.Method = "GET";
                System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(gURL);
                try
                {
                    request.ContentType = "application/json; charset=utf-8";
                    string text;
                    var response = (HttpWebResponse)request.GetResponse();

                    using (var sr = new StreamReader(response.GetResponseStream()))
                    {
                        text = sr.ReadToEnd();
                        JObject results = JObject.Parse(text);
                        JArray jArray = JArray.Parse(results["vehicles"].ToString());
                        List<string> ac = new List<string>();
                        AutoCompleteStringCollection MyCollection = new AutoCompleteStringCollection();
                        foreach (var item in jArray)
                        {
                            MyCollection.Add(item.ToString());
                            string name = item.ToString();
                            ac.Add(name);
                        }
                        txtvehno.AutoCompleteMode = AutoCompleteMode.Suggest;
                        txtvehno.AutoCompleteSource = AutoCompleteSource.CustomSource;
                        txtvehno.AutoCompleteCustomSource = MyCollection;
                    }
                }
                catch (WebException ex)
                {
                    WebResponse errorResponse = ex.Response;
                    using (Stream responseStream = errorResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                        String errorText = reader.ReadToEnd(); // log errorText 
                        MessageBox.Show(errorText);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter Username and Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtuname.Focus();
            }
          /* }
           else
           {
               MessageBox.Show("No Internet Connection", "Network Connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }*/
        }

      /*  public static bool CheckForInternetConnection()
        {
            try
            {
                Ping myPing = new Ping();
                String host = "aavin-pilot.milkosoft.in";
                byte[] buffer = new byte[32];
                int timeout = 1500;
                PingOptions pingOptions = new PingOptions();
                PingReply reply = myPing.Send(host, timeout, buffer, pingOptions);
                return (reply.Status == IPStatus.Success);
            }
            catch (Exception)
            {
                return false;
            }
        }*/

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] portNames = SerialPort.GetPortNames();     //<-- Reads all available comPorts
            foreach (var portName in portNames)
            {
                cmbport.Items.Add(portName);                  //<-- Adds Ports to combobox
            }
            txtuname.Focus();
        }

        private void btnconnect_Click(object sender, EventArgs e)
        {
            lblstat.Text = "STATUS";            
            //<-- This block ensures that no exceptions happen
            if (cmbport.Text == "")
            {
                MessageBox.Show("Please select Port Number", "INFORMATION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cmbport.Focus();
               // btnsubmit.Visible = false;
            }
            else
            {
                //btnsubmit.Visible = true;
                txtweight.Clear();
                if (_serialPort != null && _serialPort.IsOpen)
                {
                    _serialPort.Close();
                }
                if (_serialPort != null)
                {
                    _serialPort.Dispose();                //<-- End of Block
                }
                _serialPort = new SerialPort(cmbport.Text, BaudRate, Parity.None, 8, StopBits.One);       //<-- Creates new SerialPort using the name selected in the combobox
                _serialPort.Open();       //<-- make the comport listen
                if (_serialPort.IsOpen == true)
                {
                    lblstat.Text = "CONNECTED";
                    _serialPort.DataReceived += SerialPortOnDataReceived;       //<-- this event happens everytime when new data is received by the ComPort                    
                }
                else
                {
                    lblstat.Text = "NOT CONNECTED";
                    MessageBox.Show("Check PORT Connection", "PORT CONNECTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }           
        }

        private delegate void Closure();
        private void SerialPortOnDataReceived(object sender, SerialDataReceivedEventArgs serialDataReceivedEventArgs)
        {
            if (_serialPort.IsOpen == true && txtweight.Text == "")
            {
                try
                {
                    if (InvokeRequired)     //<-- Makes sure the function is invoked to work properly in the UI-Thread
                        BeginInvoke(new Closure(() => { SerialPortOnDataReceived(sender, serialDataReceivedEventArgs); }));     //<-- Function invokes itself
                    else
                    {
                        if (_serialPort.BytesToRead > 0)
                        {
                            String readstring = _serialPort.ReadLine();
                            readstring = Regex.Replace(readstring, "[^0-9.]", "");
                            readstring = readstring.Trim();
                            txtweight.Text = readstring;
                            _serialPort.Close();
                            lblstat.Text = "DISCONNECTED...";
                        }
                        //if (_serialPort.BytesToRead == 0)
                        //{
                        //    MessageBox.Show("Check Connection \nRun the Scan Again", "CHECK", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //}
                    }
                }
                catch (SystemException ex)
                {
                    //MessageBox.Show(ex.Message, "Data Received Event");
                    lblstat.Text = ex.Message;
                }
            }
        }
       
        //System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
        private void btnsubmit_Click(object sender, EventArgs e)
        {
            timer1.Stop();
           /* bool netStatus = CheckForInternetConnection();
            if (netStatus == true)
            {*/
            if (txtvehno.Text != "" && txtuname.Text != "" && txtpwd.Text != "")
            {
                try
                {
                    string URL = null;
                    String name = lblurl.Text;
                    String tid = lbltenantId.Text;
                    // btnconnect.Visible = false;
                    String iweight = txtweight.Text;
                    String ivehicleno = txtvehno.Text;
                    iweight = iweight.Trim();

                    URL = "https://" + name + "/rest/createWeighBridgeData?login.username=" + txtuname.Text + "&login.password=" + txtpwd.Text + "&tenantId=" + tid + "&weight=" + iweight + "&vehicleNumber=" + ivehicleno;
                    // URL = "https://aavin-uat.milkosoft.in/rest/createWeighBridgeData?login.username=wbintegration&login.password=weight&tenantId="+ tid + "&weight=" + iweight + "&vehicleNumber=" + ivehicleno;
                    // URL = "https://aavin-uat.milkosoft.in/rest/createWeighBridgeData?login.username=gopi&login.password=Gopinath&tenantId=" + tid + "&weight=" + iweight + "&vehicleNumber=" + ivehicleno;

                    HttpWebRequest http = (HttpWebRequest)HttpWebRequest.Create(URL);
                    ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
                    http.Method = "POST";
                    System.Net.ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
                    //StreamReader objReader = null;
                    //Stream objStream = http.GetResponse().GetResponseStream();
                    //objReader = new StreamReader(objStream);
                    //objReader.Close();
                    //string result = objStream.ToString();                    
                    HttpWebResponse response = (HttpWebResponse)http.GetResponse();
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        MessageBox.Show("Values Submited Successfully", "Important", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtweight.Clear();
                        txtvehno.Clear();
                        // btnconnect.Visible = true;
                        // btnsubmit.Visible = false;
                        txtvehno.Focus();
                    }
                    else
                    {
                        /* var rsp = new StreamReader(response.GetResponseStream());
                         String text = rsp.ReadToEnd();*/
                        var statuscode = response.StatusCode;
                        MessageBox.Show(statuscode.ToString() + "Check you Network Connection \n and Enter Details Correctly", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (WebException ex)
                {
                    WebResponse errorResponse = ex.Response;
                    using (Stream responseStream = errorResponse.GetResponseStream())
                    {
                        StreamReader reader = new StreamReader(responseStream, Encoding.GetEncoding("utf-8"));
                        String errorText = reader.ReadToEnd(); // log errorText 
                        MessageBox.Show(errorText, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtvehno.Focus();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please enter details correct","Error Message",MessageBoxButtons.OK,MessageBoxIcon.Error);
                txtvehno.Focus();
            }
          /*  }
            else
            {
                MessageBox.Show("Check Internet Connection", "Connection Problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }

        private void txtvehno_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.KeyChar = char.ToUpper(e.KeyChar);
        }

        private void txtpwd_Leave(object sender, EventArgs e)
        {
            if (txtuname.Text == "")
            {
                MessageBox.Show("Please Enter Username", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtuname.Focus();
            }
            else if (txtpwd.Text == "")
            {
                MessageBox.Show("Please Enter Password", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpwd.Focus();
            }
            else
            {
                GetVehicle();
            }
        }
        
        private void txtvehno_Leave(object sender, EventArgs e)
        {
           // InitTimer();
        }

        Control ctrl;
        private void txtvehno_KeyDown(object sender, KeyEventArgs e)
        {
            if (txtvehno.Text != "")
            {
                ctrl = (Control)sender;
                if (e.KeyCode == Keys.Enter)
                {
                    this.SelectNextControl(ctrl, true, true, true, true);
                }
                else
                {
                    return;
                }
            }
        }

        private void txtpwd_KeyDown(object sender, KeyEventArgs e)
        {
            ctrl = (Control)sender;
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl(ctrl, true, true, true, true);
            }
            else
            {
                return;
            }
        }

    }
}