using System.Diagnostics;

namespace Backend.Infrastructure
{
    public static class ResourceManager
    {
        public static void RunSetUpScript()
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "Powershell",
                Arguments = "-ExecutionPolicy Bypass -File ./Add-Environment.ps1",
                WorkingDirectory = Path.Combine(Directory.GetCurrentDirectory(), "Infrastructure"),
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = Process.Start(processInfo);
            var output = process!.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("Error executing script: " + error);
            }
        }

        public static void cleanUpScript()
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = "pwsh",
                Arguments = "./Remove-Environment.ps1",
                RedirectStandardInput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var process = Process.Start(processInfo);

            var output = process!.StandardOutput.ReadToEnd();
            var error = process.StandardError.ReadToEnd();
            process.WaitForExit();

            if (!string.IsNullOrEmpty(error))
            {
                Console.WriteLine("Error executing script: " + error);
            }
        }
    }
}
