namespace BoardgameSimulator.AdoNet
{
    using System;
    using System.Data;
    using System.Data.OleDb;
    using System.Data.SqlClient;
    using System.IO;
    using System.IO.Compression;
    using System.Text.RegularExpressions;

    public class ArmiesReportsSeeder
    {
        private const string ArmiesReportsPath = "ArmiesReports";

        private const string ExcelQuery = "SELECT * FROM [Sheet1$]";

        public ArmiesReportsSeeder()
            : this(".", "BoardgameSimulator", "Armies")
        {
        }

        public ArmiesReportsSeeder(string serverName, string databaseName, string tableName)
        {
            this.ServerName = serverName;
            this.DatabaseName = databaseName;
            this.TableName = tableName;
        }

        public string ServerName { get; set; }

        public string DatabaseName { get; set; }

        public string TableName { get; set; }

        public void SeedFromZip(string zipFilepath)
        {
            ZipFile.ExtractToDirectory(zipFilepath, ArmiesReportsPath);

            string armiesReportsFullPath = Path.GetFullPath(ArmiesReportsPath);
            foreach (var dir in Directory.GetDirectories(armiesReportsFullPath))
            {
                this.SeedReportsFromDirectory(dir);
            }

            Directory.Delete(armiesReportsFullPath, true);

            Console.WriteLine("Seeding armies reports from zip file completed!");
        }

        private void SeedReportsFromDirectory(string dir)
        {
            foreach (var file in Directory.GetFiles(dir))
            {
                this.ImportDataFromExcel(file);
            }
        }

        private void ImportDataFromExcel(string excelFilePath)
        {
            string excelConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + excelFilePath
                                           + ";Extended Properties=\"Excel 8.0;HDR=YES;\"";
            string sqlConnectionString = "Server=" + this.ServerName + "; Database=" + this.DatabaseName
                                         + "; Integrated Security=true";

            using (var oleDbConnection = new OleDbConnection(excelConnectionString))
            using (var sqlBulkCopy = new SqlBulkCopy(sqlConnectionString, SqlBulkCopyOptions.Default))
            {
                oleDbConnection.Open();

                var oleDbCommand = new OleDbCommand(ExcelQuery, oleDbConnection);
                var oleDbDataReader = oleDbCommand.ExecuteReader();

                var table = new DataTable();
                if (oleDbDataReader != null)
                {
                    table.Load(oleDbDataReader);
                }

                string directoryName = Path.GetDirectoryName(excelFilePath);
                string alignmentPerkIdString = Regex.Match(directoryName, @"\d+$").Value;

                table.Columns.Add("AlignmentPerkId", typeof(int));
                foreach (DataRow dataRow in table.Rows)
                {
                    dataRow["AlignmentPerkId"] = alignmentPerkIdString;
                }

                sqlBulkCopy.DestinationTableName = this.TableName;

                foreach (DataColumn col in table.Columns)
                {
                    sqlBulkCopy.ColumnMappings.Add(col.ColumnName, col.ColumnName);
                }

                try
                {
                    sqlBulkCopy.WriteToServer(table);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
