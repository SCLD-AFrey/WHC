using DevExpress.Xpo;

namespace WHC.CommonLibrary.DataConn;

public interface IDatabaseInterface
{
    public IDataLayer DataLayer { get; set; }

    public UnitOfWork ProvisionUnitOfWork();
}