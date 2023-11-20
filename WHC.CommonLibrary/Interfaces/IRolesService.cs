using WHC.CommonLibrary.Models.UserInfo;

namespace WHC.CommonLibrary.Interfaces;

public interface IRolesService
{
    public Role GetRole(int p_id);
    public List<Role> GetRoles();
    public void AddRole(Role p_role);
    public void AddRole(string p_name, string p_description);
    public void RemoveRole(int Oid);
    public void RemoveRole(Role p_role);
}