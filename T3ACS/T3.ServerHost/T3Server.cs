using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Reflection;
using System.Threading.Tasks;

namespace T3.ServerHost
{


    public static class T3Server
    {
        private static readonly Dictionary<string, Assembly>
            _assemblies =
            new Dictionary<string, Assembly>();

        private static readonly Dictionary<string, object>
            _instances =
            new Dictionary<string, object>();

        public static void Start()
        {
            Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        using (var pipe =
                            new NamedPipeServerStream(
                                "T3.ServerHost",
                                PipeDirection.InOut))
                        {
                            pipe.WaitForConnection();
                            using (var reader =
                           new StreamReader(pipe))
                            using (var writer =
                                new StreamWriter(pipe))
                            {
                                writer.AutoFlush = true;

                                string json =
                                    reader.ReadLine();

                                string result =
                                    ProcessRequest(json);

                                writer.WriteLine(result);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    File.WriteAllText(
                        @"D:\T3Error.txt",
                        ex.ToString());
                }
            });




        }

        public static string ProcessRequest(
            string json)
        {
            try
            {
                var request =
                    JsonConvert.DeserializeObject
                    <InvokeRequest>(json);

                var response =
                    Execute(request);

                return JsonConvert.SerializeObject(
                    response);
            }
            catch (Exception ex)
            {
                return JsonConvert.SerializeObject(
                    new InvokeResponse
                    {
                        Success = false,
                        Error = ex.ToString()
                    });
            }
        }

        private static InvokeResponse Execute(
            InvokeRequest request)
        {
            try
            {
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

                return new InvokeResponse
                {
                    Success = true,
                    ResultJson = result == null
          ? null
          : JsonConvert.SerializeObject(result)
                };
            }
            catch (Exception ex)
            {
                return new InvokeResponse
                {
                    Success = false,
                    Error = ex.ToString()
                };
            }
        }
    }
}
