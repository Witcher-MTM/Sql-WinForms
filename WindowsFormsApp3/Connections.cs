using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace WinFormsApp1
{
    public enum procAction
    {
        INSERT,
        DELETE,
        DROP,
        SELECT,
        CREATE
        
    }
    public class Connection
    {
        public string Server { get; set; }
        public string DataBase { get; set; }
        public string Name { get; set; }
        public procAction Action { get; set; }

        public Connection()
        {
            Server = "null";
            DataBase = "null";
            Name = "null";
        }

        public void SaveJson(Connection connection)
        {
            var json = JsonSerializer.Serialize<Connection>(connection);
            List<Connection> connections = new List<Connection>();
            if (File.Exists("Connections.json"))
            {
                foreach (var item in File.ReadAllLines("Connections.json"))
                {
                    connections.Add(JsonSerializer.Deserialize<Connection>(item));
                }
                foreach (var item in connections)
                {
                    if (item.Name != connection.Name)
                    {
                        File.AppendAllText("Connections.json", json + "\n");
                    }
                }
            }
            else
            {
                File.AppendAllText("Connections.json", json + "\n");
            }
            
          

        }
        public List<Connection> ReadJson()
        {
            List<Connection> conn = new List<Connection>();
            Connection connection;
            if (File.Exists("Connections.json"))
            {
                foreach (var item in File.ReadAllLines("Connections.json"))
                {
                    if (item != string.Empty)
                    {
                        try
                        {
                            connection = JsonSerializer.Deserialize<Connection>(item);
                            conn.Add(connection);
                        }
                        catch (Exception)
                        {
                            
                        }
                     
                    }
                  
                }
            }


            return conn;
        }
    }
}
