using Microsoft.Extensions.Logging;
using WHC.CommonLibrary.DataConn;
using WHC.CommonLibrary.Interfaces;
using WHC.CommonLibrary.Models.UserInfo;

namespace WHC.CommonLibrary.Services;

public class RolesService : IRolesService
{
    private readonly ILogger<RolesService> m_logger;
    private readonly ApplicationContext m_appContext;
    
    public Role GetRole(int p_id)
    {
        return m_appContext.Roles.FirstOrDefault(p_x => p_x.Oid == p_id);
    }

    public List<Role> GetRoles()
    {
        return m_appContext.Roles.ToList();
    }

    public void AddRole(Role p_role)
    {
        m_appContext.Roles.Add(p_role);
    }

    public void AddRole(string p_name, string p_desc)
    {
        AddRole(new Role()
        {
            Name = p_name,
            Description = p_desc,
        });
    }

    public void RemoveRole(int Oid)
    {
        m_appContext.Roles.Remove(GetRole(Oid));
    }

    public void RemoveRole(Role p_role)
    {
        m_appContext.Roles.Remove(p_role);
    }
}