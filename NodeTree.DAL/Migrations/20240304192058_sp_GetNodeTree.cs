using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NodeTree.DAL.Migrations
{
    /// <inheritdoc />
    public partial class sp_GetNodeTree : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp_GetNodeTree = @"CREATE PROCEDURE [dbo].[spGetNodeTree]
                        (
                            @RootName nvarchar(256) = NULL
                        )
                        AS
                        BEGIN
                            SET NOCOUNT ON;
                        
                            WITH child_parent_cte AS (
                                SELECT
                                  Id,
                                  [Name],
                                  ParentNodeId,
			            		  CreatedDate,
			            		  ModifiedDate,
			            		  DeletedDate,
                                  1 AS level
                                FROM TreeNodes
                                WHERE [Name] = @RootName AND ParentNodeId IS NULL
                                UNION ALL
                                SELECT
                                  e.Id,
                                  e.[Name],
                                  e.ParentNodeId,
			            		  e.CreatedDate,
			            		  e.ModifiedDate,
			            		  e.DeletedDate,
                                  level + 1
                                FROM TreeNodes e
			            		
                                INNER JOIN child_parent_cte r
                                  ON e.ParentNodeId = r.id
			            		  WHERE e.DeletedDate IS NULL
                              )
                              SELECT *
                              FROM child_parent_cte;
                        END
                        GO";

            migrationBuilder.Sql(sp_GetNodeTree);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
