using FluentMigrator;

namespace Identity.Migrations.Migrations
{
    [Migration(2022019092100)]
    public class _2022019092100_Initial : Migration
    {
        private readonly ScriptResourceManager _sourceManager;

        public _2022019092100_Initial(ScriptResourceManager sourceManager)
        {
            _sourceManager = sourceManager;
        }

        public override void Up()
        {
            var script = _sourceManager.Read("application-user.sql");
            Execute.Sql(script);
        }

        public override void Down()
        {
            Delete.Table("ApplicationUserRoles");
            Delete.Table("ApplicationUserLogins");
            Delete.Table("ApplicationUserClaims");
            Delete.Table("ApplicationRoleClaims");
            Delete.Table("ApplicationRoles");
            Delete.Table("ApplicationUserTokens");
            Delete.Table("ApplicationUsers");
        }
    }
}
