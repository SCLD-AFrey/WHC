using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace WHC.CommonLibrary.DataConn;

public class DatabaseUtilities
{
    private readonly CommonFilesService m_fileService;

    public DatabaseUtilities(CommonFilesService p_fileService)
    {
        m_fileService = p_fileService;
    }

    public IDataLayer GetDataLayer()
    {
        var connectionString = SQLiteConnectionProvider.GetConnectionString(m_fileService.DataPath);
        return new SimpleDataLayer(
            XpoDefault.GetConnectionProvider(connectionString, AutoCreateOption.DatabaseAndSchema));
    }
}