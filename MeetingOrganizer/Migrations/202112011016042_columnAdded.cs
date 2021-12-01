namespace MeetingOrganizer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class columnAdded : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Participants", "Meeting_Id", "dbo.Meetings");
            DropIndex("dbo.Participants", new[] { "Meeting_Id" });
            RenameColumn(table: "dbo.Participants", name: "Meeting_Id", newName: "MeetingId");
            AddColumn("dbo.Meetings", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Participants", "MeetingId", c => c.Int(nullable: false));
            CreateIndex("dbo.Participants", "MeetingId");
            AddForeignKey("dbo.Participants", "MeetingId", "dbo.Meetings", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Participants", "MeetingId", "dbo.Meetings");
            DropIndex("dbo.Participants", new[] { "MeetingId" });
            AlterColumn("dbo.Participants", "MeetingId", c => c.Int());
            DropColumn("dbo.Meetings", "IsActive");
            RenameColumn(table: "dbo.Participants", name: "MeetingId", newName: "Meeting_Id");
            CreateIndex("dbo.Participants", "Meeting_Id");
            AddForeignKey("dbo.Participants", "Meeting_Id", "dbo.Meetings", "Id");
        }
    }
}
