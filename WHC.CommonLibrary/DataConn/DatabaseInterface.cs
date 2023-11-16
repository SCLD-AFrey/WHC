using DevExpress.Xpo;

namespace WHC.CommonLibrary.DataConn;

public class DatabaseInterface : IDatabaseInterface
{
    public DatabaseInterface(DatabaseUtilities p_utilities)
    {
        DataLayer = p_utilities.GetDataLayer();
    }

    public IDataLayer DataLayer { get; set; }

    public UnitOfWork ProvisionUnitOfWork()
    {
        return new UnitOfWork(DataLayer);
    }
}