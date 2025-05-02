namespace MotoFindrAPI.Domain.Entities
{
    public class AdministradorEntity
    {
        public AdministradorEntity() { }
        public bool AutoridadeMoto()
        {
            return true;
        }
        public bool AutoridadeMotoqueiro()
        {
            return true;
        }

        public bool AutoridadePatio()
        {
            return true;
        }
    }
}
