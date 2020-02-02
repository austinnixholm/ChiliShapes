using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chili_Environment_UI.IO
{
    public class PipelineServer
    {
        public static bool Ready { get; set; } = true;

        public static async void SendData(string rawData)
        {
            Ready = false;
            try
            {
                using (NamedPipeServerStream pipeServer = new NamedPipeServerStream("CHILICOM", PipeDirection.InOut,
                    NamedPipeServerStream.MaxAllowedServerInstances, PipeTransmissionMode.Message, PipeOptions.Asynchronous, 512, 512))
                {
                    await Task.Run(delegate { pipeServer.WaitForConnection(); });
                    if (!pipeServer.IsConnected)
                        return;

                    using (StreamWriter writer = new StreamWriter(pipeServer))
                    {
                        writer.AutoFlush = true;
                        Configuration.CurrentMessages.Add("COMMAND: \"" + rawData + "\"");
                        writer.Write(rawData + "\0");
                    }
                }
            }
            catch
            {
                Configuration.CurrentMessages.Add("Error occurred sending data through pipeline.");
                Ready = true;
            }

            Ready = true;
        }
        
    }


}