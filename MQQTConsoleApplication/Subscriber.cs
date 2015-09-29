using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

namespace MQQTConsoleApplication
{
    class Subscriber
    {
        static string MQTT_BROKER_ADDRESS = "localhost";
        public static void Main(string[] args)
        {
            MqttClient client = new MqttClient(MQTT_BROKER_ADDRESS);

            // register to message received
            client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

            string clientId = Guid.NewGuid().ToString();
            client.Connect(clientId);

            client.Subscribe(new string[] { "/testit/now" }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
        }

        static void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            Console.WriteLine("Received");
            //  Console.WriteLine(e.Message.);
            string msg = Encoding.UTF8.GetString(e.Message);
            Console.WriteLine(msg);
            Mapper.buildDictionary();
        }

        static void registerSubscriber(MqttMsgPublishReceived publishReceived)
        {

        }

    }
}
