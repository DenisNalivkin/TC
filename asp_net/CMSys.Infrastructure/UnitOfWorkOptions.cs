namespace CMSys.Infrastructure
{
    public sealed class UnitOfWorkOptions
    {
        public string ConnectionString { get; set; } = "Data Source=(local);Initial Catalog=CMSys;Integrated Security=True";
        public int? CommandTimeout { get; set; }
    }
}