using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SourDictionary.Infrastructure.Persistence.Migrations
{
    public partial class ChangeTableName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_entry_user_CreatedById",
                schema: "dbo",
                table: "entry");

            migrationBuilder.DropForeignKey(
                name: "FK_entrycomment_entry_EntryId",
                schema: "dbo",
                table: "entrycomment");

            migrationBuilder.DropForeignKey(
                name: "FK_entrycomment_user_CreatedById",
                schema: "dbo",
                table: "entrycomment");

            migrationBuilder.DropForeignKey(
                name: "FK_entrycommentfavorite_entrycomment_EntryCommentId",
                schema: "dbo",
                table: "entrycommentfavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_entrycommentfavorite_user_CreatedById",
                schema: "dbo",
                table: "entrycommentfavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_entrycommentvote_entrycomment_EntryCommentId",
                schema: "dbo",
                table: "entrycommentvote");

            migrationBuilder.DropForeignKey(
                name: "FK_entryfavorite_entry_EntryId",
                schema: "dbo",
                table: "entryfavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_entryfavorite_user_CreatedById",
                schema: "dbo",
                table: "entryfavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_entryvote_entry_EntryId",
                schema: "dbo",
                table: "entryvote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user",
                schema: "dbo",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "PK_entryvote",
                schema: "dbo",
                table: "entryvote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_entryfavorite",
                schema: "dbo",
                table: "entryfavorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_entrycommentvote",
                schema: "dbo",
                table: "entrycommentvote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_entrycommentfavorite",
                schema: "dbo",
                table: "entrycommentfavorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_entrycomment",
                schema: "dbo",
                table: "entrycomment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_entry",
                schema: "dbo",
                table: "entry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_emailconfirmation",
                schema: "dbo",
                table: "emailconfirmation");

            migrationBuilder.RenameTable(
                name: "user",
                schema: "dbo",
                newName: "User",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "entryvote",
                schema: "dbo",
                newName: "EntryVote",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "entryfavorite",
                schema: "dbo",
                newName: "EntryFavorite",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "entrycommentvote",
                schema: "dbo",
                newName: "EntryCommentVote",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "entrycommentfavorite",
                schema: "dbo",
                newName: "EntryCommentFavorite",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "entrycomment",
                schema: "dbo",
                newName: "EntryComment",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "entry",
                schema: "dbo",
                newName: "Entry",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "emailconfirmation",
                schema: "dbo",
                newName: "EmailConfirmation",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_entryvote_EntryId",
                schema: "dbo",
                table: "EntryVote",
                newName: "IX_EntryVote_EntryId");

            migrationBuilder.RenameIndex(
                name: "IX_entryfavorite_EntryId",
                schema: "dbo",
                table: "EntryFavorite",
                newName: "IX_EntryFavorite_EntryId");

            migrationBuilder.RenameIndex(
                name: "IX_entryfavorite_CreatedById",
                schema: "dbo",
                table: "EntryFavorite",
                newName: "IX_EntryFavorite_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_entrycommentvote_EntryCommentId",
                schema: "dbo",
                table: "EntryCommentVote",
                newName: "IX_EntryCommentVote_EntryCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_entrycommentfavorite_EntryCommentId",
                schema: "dbo",
                table: "EntryCommentFavorite",
                newName: "IX_EntryCommentFavorite_EntryCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_entrycommentfavorite_CreatedById",
                schema: "dbo",
                table: "EntryCommentFavorite",
                newName: "IX_EntryCommentFavorite_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_entrycomment_EntryId",
                schema: "dbo",
                table: "EntryComment",
                newName: "IX_EntryComment_EntryId");

            migrationBuilder.RenameIndex(
                name: "IX_entrycomment_CreatedById",
                schema: "dbo",
                table: "EntryComment",
                newName: "IX_EntryComment_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_entry_CreatedById",
                schema: "dbo",
                table: "Entry",
                newName: "IX_Entry_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                schema: "dbo",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntryVote",
                schema: "dbo",
                table: "EntryVote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntryFavorite",
                schema: "dbo",
                table: "EntryFavorite",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntryCommentVote",
                schema: "dbo",
                table: "EntryCommentVote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntryCommentFavorite",
                schema: "dbo",
                table: "EntryCommentFavorite",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EntryComment",
                schema: "dbo",
                table: "EntryComment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entry",
                schema: "dbo",
                table: "Entry",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmailConfirmation",
                schema: "dbo",
                table: "EmailConfirmation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Entry_User_CreatedById",
                schema: "dbo",
                table: "Entry",
                column: "CreatedById",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntryComment_Entry_EntryId",
                schema: "dbo",
                table: "EntryComment",
                column: "EntryId",
                principalSchema: "dbo",
                principalTable: "Entry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntryComment_User_CreatedById",
                schema: "dbo",
                table: "EntryComment",
                column: "CreatedById",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntryCommentFavorite_EntryComment_EntryCommentId",
                schema: "dbo",
                table: "EntryCommentFavorite",
                column: "EntryCommentId",
                principalSchema: "dbo",
                principalTable: "EntryComment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntryCommentFavorite_User_CreatedById",
                schema: "dbo",
                table: "EntryCommentFavorite",
                column: "CreatedById",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntryCommentVote_EntryComment_EntryCommentId",
                schema: "dbo",
                table: "EntryCommentVote",
                column: "EntryCommentId",
                principalSchema: "dbo",
                principalTable: "EntryComment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntryFavorite_Entry_EntryId",
                schema: "dbo",
                table: "EntryFavorite",
                column: "EntryId",
                principalSchema: "dbo",
                principalTable: "Entry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EntryFavorite_User_CreatedById",
                schema: "dbo",
                table: "EntryFavorite",
                column: "CreatedById",
                principalSchema: "dbo",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EntryVote_Entry_EntryId",
                schema: "dbo",
                table: "EntryVote",
                column: "EntryId",
                principalSchema: "dbo",
                principalTable: "Entry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entry_User_CreatedById",
                schema: "dbo",
                table: "Entry");

            migrationBuilder.DropForeignKey(
                name: "FK_EntryComment_Entry_EntryId",
                schema: "dbo",
                table: "EntryComment");

            migrationBuilder.DropForeignKey(
                name: "FK_EntryComment_User_CreatedById",
                schema: "dbo",
                table: "EntryComment");

            migrationBuilder.DropForeignKey(
                name: "FK_EntryCommentFavorite_EntryComment_EntryCommentId",
                schema: "dbo",
                table: "EntryCommentFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_EntryCommentFavorite_User_CreatedById",
                schema: "dbo",
                table: "EntryCommentFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_EntryCommentVote_EntryComment_EntryCommentId",
                schema: "dbo",
                table: "EntryCommentVote");

            migrationBuilder.DropForeignKey(
                name: "FK_EntryFavorite_Entry_EntryId",
                schema: "dbo",
                table: "EntryFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_EntryFavorite_User_CreatedById",
                schema: "dbo",
                table: "EntryFavorite");

            migrationBuilder.DropForeignKey(
                name: "FK_EntryVote_Entry_EntryId",
                schema: "dbo",
                table: "EntryVote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                schema: "dbo",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntryVote",
                schema: "dbo",
                table: "EntryVote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntryFavorite",
                schema: "dbo",
                table: "EntryFavorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntryCommentVote",
                schema: "dbo",
                table: "EntryCommentVote");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntryCommentFavorite",
                schema: "dbo",
                table: "EntryCommentFavorite");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EntryComment",
                schema: "dbo",
                table: "EntryComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Entry",
                schema: "dbo",
                table: "Entry");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmailConfirmation",
                schema: "dbo",
                table: "EmailConfirmation");

            migrationBuilder.RenameTable(
                name: "User",
                schema: "dbo",
                newName: "user",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EntryVote",
                schema: "dbo",
                newName: "entryvote",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EntryFavorite",
                schema: "dbo",
                newName: "entryfavorite",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EntryCommentVote",
                schema: "dbo",
                newName: "entrycommentvote",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EntryCommentFavorite",
                schema: "dbo",
                newName: "entrycommentfavorite",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EntryComment",
                schema: "dbo",
                newName: "entrycomment",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "Entry",
                schema: "dbo",
                newName: "entry",
                newSchema: "dbo");

            migrationBuilder.RenameTable(
                name: "EmailConfirmation",
                schema: "dbo",
                newName: "emailconfirmation",
                newSchema: "dbo");

            migrationBuilder.RenameIndex(
                name: "IX_EntryVote_EntryId",
                schema: "dbo",
                table: "entryvote",
                newName: "IX_entryvote_EntryId");

            migrationBuilder.RenameIndex(
                name: "IX_EntryFavorite_EntryId",
                schema: "dbo",
                table: "entryfavorite",
                newName: "IX_entryfavorite_EntryId");

            migrationBuilder.RenameIndex(
                name: "IX_EntryFavorite_CreatedById",
                schema: "dbo",
                table: "entryfavorite",
                newName: "IX_entryfavorite_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_EntryCommentVote_EntryCommentId",
                schema: "dbo",
                table: "entrycommentvote",
                newName: "IX_entrycommentvote_EntryCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_EntryCommentFavorite_EntryCommentId",
                schema: "dbo",
                table: "entrycommentfavorite",
                newName: "IX_entrycommentfavorite_EntryCommentId");

            migrationBuilder.RenameIndex(
                name: "IX_EntryCommentFavorite_CreatedById",
                schema: "dbo",
                table: "entrycommentfavorite",
                newName: "IX_entrycommentfavorite_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_EntryComment_EntryId",
                schema: "dbo",
                table: "entrycomment",
                newName: "IX_entrycomment_EntryId");

            migrationBuilder.RenameIndex(
                name: "IX_EntryComment_CreatedById",
                schema: "dbo",
                table: "entrycomment",
                newName: "IX_entrycomment_CreatedById");

            migrationBuilder.RenameIndex(
                name: "IX_Entry_CreatedById",
                schema: "dbo",
                table: "entry",
                newName: "IX_entry_CreatedById");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user",
                schema: "dbo",
                table: "user",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_entryvote",
                schema: "dbo",
                table: "entryvote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_entryfavorite",
                schema: "dbo",
                table: "entryfavorite",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_entrycommentvote",
                schema: "dbo",
                table: "entrycommentvote",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_entrycommentfavorite",
                schema: "dbo",
                table: "entrycommentfavorite",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_entrycomment",
                schema: "dbo",
                table: "entrycomment",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_entry",
                schema: "dbo",
                table: "entry",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_emailconfirmation",
                schema: "dbo",
                table: "emailconfirmation",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_entry_user_CreatedById",
                schema: "dbo",
                table: "entry",
                column: "CreatedById",
                principalSchema: "dbo",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_entrycomment_entry_EntryId",
                schema: "dbo",
                table: "entrycomment",
                column: "EntryId",
                principalSchema: "dbo",
                principalTable: "entry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_entrycomment_user_CreatedById",
                schema: "dbo",
                table: "entrycomment",
                column: "CreatedById",
                principalSchema: "dbo",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_entrycommentfavorite_entrycomment_EntryCommentId",
                schema: "dbo",
                table: "entrycommentfavorite",
                column: "EntryCommentId",
                principalSchema: "dbo",
                principalTable: "entrycomment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_entrycommentfavorite_user_CreatedById",
                schema: "dbo",
                table: "entrycommentfavorite",
                column: "CreatedById",
                principalSchema: "dbo",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_entrycommentvote_entrycomment_EntryCommentId",
                schema: "dbo",
                table: "entrycommentvote",
                column: "EntryCommentId",
                principalSchema: "dbo",
                principalTable: "entrycomment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_entryfavorite_entry_EntryId",
                schema: "dbo",
                table: "entryfavorite",
                column: "EntryId",
                principalSchema: "dbo",
                principalTable: "entry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_entryfavorite_user_CreatedById",
                schema: "dbo",
                table: "entryfavorite",
                column: "CreatedById",
                principalSchema: "dbo",
                principalTable: "user",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_entryvote_entry_EntryId",
                schema: "dbo",
                table: "entryvote",
                column: "EntryId",
                principalSchema: "dbo",
                principalTable: "entry",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
