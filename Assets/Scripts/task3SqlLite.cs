using UnityEngine;
using UnityEngine.Networking;
using Mono.Data.Sqlite;
using System.Data;
using System.IO;
using System.Collections.Generic;

public class task3SqlLite : MonoBehaviour
{
    const string filename = "database.db";
    private List<object> references = new List<object>();
    private List<object> materials = new List<object>();
    private List<object> resources = new List<object>();

    void Start()
    {

        string DBload = Path.Combine(Application.streamingAssetsPath, filename);
        
        SqliteConnection connection = new SqliteConnection("Data Source=" + DBload);
        connection.Open();
        string query = "SELECT * FROM `_catalogues_materials_references` WHERE `dim_x`=0.6 OR `dim_y`=0.6";
        DoQuery(connection, query, references);
        query = "SELECT * FROM `_catalogues_materials_references` A LEFT JOIN `_catalogues_materials` B ON A.reference_uniq=B.uniq WHERE A.dim_x=0.6 OR A.dim_y=0.6";
        DoQuery(connection, query, materials);
        query = "SELECT * FROM `_catalogues_materials_references` A LEFT JOIN `_catalogues_resources` B ON A.reference_uniq=B.uniq WHERE A.dim_x=0.6 OR A.dim_y=0.6";
        DoQuery(connection, query, resources);


    }        

    void DoQuery(SqliteConnection connection,string query,List<object> dblist)
    {
        SqliteCommand command = new SqliteCommand(connection);

        
        Debug.Log("<color=blue><b> " + query + "</b></color>");
        command.CommandText = query;
        SqliteDataReader sqlReader = command.ExecuteReader();
       
        while (sqlReader.Read())
        {
            dblist.Add(sqlReader);
            
        }
        sqlReader.Close();
        Debug.Log("<color=green>Найдено записей: " + dblist.Count + "</color>");
    }

    // SELECT * FROM `_catalogues_materials_references` A LEFT JOIN `_catalogues_materials` B ON A.reference_uniq=B.uniq WHERE A.dim_x=0.6 OR A.dim_y=0.6

    void Update()
    {
        
    }
}
