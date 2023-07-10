namespace Core.Entities
{
    public class Appsettings
    {
        public string Secret { get; set; }
        public string Key { get; set; }
    }
    public class LogPaths
    {
        public string TextFileLogPath { get; set; }
    }
    public class ExcelPaths
    {
        public string ZipPath { get; set; }
        public string AllRecordsExcelFilePath { get; set; }
        public string DetailReportExcelFilePath { get; set; }
        public string ZipStatus { get; set; }
        public string XlsStatus { get; set; }
    }
    public class ExcelLimit
    {
        public string RowCount { get; set; }
    }
    public interface CodeMessage
    {
        string code { get; set; }
        string Message { get; set; }
    }
    public class codeMessage : CodeMessage
    {
        public string code { get; set; }
        public string Message { get; set; }


    }

    public class codeMessageWithID : CodeMessage
    {
        public string code { get; set; }
        public string Message { get; set; }
        public string ID { get; set; }
    }

    public class codeMessageWithName : CodeMessage
    {
        public string code { get; set; }
        public string Message { get; set; }
        public string entryBy { get; set; }
        public string UserName { get; set; }
    }

    public class codeMessageWithData : CodeMessage
    {
        public string code { get; set; }
        public string Message { get; set; }
        public string secondEntryFormID { get; set; }
        public string columnName { get; set; }
        public string labelTag { get; set; }
    }

    public class ImagesConfig
    {
        public string RootImageFoler { get; set; }
        public bool Enabled { get; set; }
    }
    public class MongoDatabaseConfigs
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
        public string ImagesCollectionName { get; set; }
        public string OWICDatabaseName { get; set; }
        public string OWICImagesCollectionName { get; set; }
        public string CIConnectionString { get; set; }
        public string OWICConnectionString { get; set; }

    }

    public class TokenLifeTime
    {
        public int Time { get; set; }
    }

    public class CryptoKey
    {
        public string Key { get; set; }
    }

    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
