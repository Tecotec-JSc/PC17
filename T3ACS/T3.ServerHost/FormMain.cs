using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace T3.ServerHost
{
    public partial class FormMain : Form
    {
        private static readonly Dictionary<string, Assembly>
           _assemblies =
           new Dictionary<string, Assembly>();

        private static readonly Dictionary<string, object>
            _instances =
            new Dictionary<string, object>();
        public FormMain()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            var request = new InvokeRequest() { DllPath = "C:\\CTMT2025\\CTMT2025\\Micran\\Dll\\MicranModel.dll", ClassName = "MicranModel.VNAModel", MethodName = "Connect", Parameters = new object[] { "", "", "", "" } };
            Assembly assembly;

            if (!_assemblies.TryGetValue(
                request.DllPath,
                out assembly))
            {
                assembly =
                    Assembly.LoadFrom(
                        request.DllPath);

                _assemblies.Add(
                    request.DllPath,
                    assembly);
            }

            Type type =
                assembly.GetType(
                    request.ClassName);

            string key =
                request.DllPath +
                "|" +
                request.ClassName;

            object instance;

            if (!_instances.TryGetValue(
                key,
                out instance))
            {
                instance =
                    Activator.CreateInstance(
                        type);

                _instances.Add(
                    key,
                    instance);
            }

            MethodInfo method =
                type.GetMethod(
                    request.MethodName);

            object result =
                method.Invoke(
                    instance,
                        request.Parameters);


        }
    }
}

