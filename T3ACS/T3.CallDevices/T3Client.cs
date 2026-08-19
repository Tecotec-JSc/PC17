using System.IO;
using System.IO.Pipes;
using System.Text.Json;

namespace T3.CallDevices
{


    /// <summary>
    /// Client gọi thiết bị OUT-OF-PROCESS qua named-pipe tới tiến trình T3.ServerHost.
    /// Đây là cơ chế DỰ PHÒNG (hiện app T3ACS gọi thiết bị in-process qua T3Call).
    /// Giữ lại cho tình huống cần nạp DLL thiết bị .NET Framework cũ ngoài tiến trình.
    /// </summary>
    public static class T3Client
    {
        // Tên pipe phải khớp với NamedPipeServerStream trong T3.ServerHost.T3Server.
        private const string PipeName = "T3.ServerHost";

        // Thời gian chờ kết nối tới server (ms).
        private const int ConnectTimeoutMs = 3000;

        public static T Invoke<T>(
            string dllPath,
            string className,
            string methodName,
            params object[] parameters)
        {
            var request = new InvokeRequest
            {
                DllPath = dllPath,
                ClassName = className,
                MethodName = methodName,
                Parameters = parameters
            };

            string json =
                JsonSerializer.Serialize(request);

            using var pipe =
                new NamedPipeClientStream(
                    ".",
                    PipeName,
                    PipeDirection.InOut);

            pipe.Connect(ConnectTimeoutMs);

            using var reader =
                new StreamReader(pipe);

            using var writer =
                new StreamWriter(pipe);

            writer.AutoFlush = true;

            writer.WriteLine(json);

            string responseJson =
                reader.ReadLine();

            var response =
                JsonSerializer.Deserialize<InvokeResponse>(
                    responseJson);

            if (!response.Success)
            {
                throw new Exception(response.Error);
            }

            // Trường hợp trả về string
            if (typeof(T) == typeof(string))
            {
                return (T)(object)response.ResultJson;
            }

            // Trường hợp trả về object khác
            return JsonSerializer.Deserialize<T>(
                response.ResultJson);
        }
    }
}
