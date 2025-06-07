using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NimbusApi.Migrations
{
    /// <inheritdoc />
    public partial class retiradacolunaendereco : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_nimbus_endereco_t_nimbus_bairro_id_bairro",
                table: "t_nimbus_endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_t_nimbus_usuario_t_nimbus_localizacao_LocalizacaoIdLocalizacao",
                table: "t_nimbus_usuario");

            migrationBuilder.DropIndex(
                name: "IX_t_nimbus_usuario_LocalizacaoIdLocalizacao",
                table: "t_nimbus_usuario");

            migrationBuilder.DropColumn(
                name: "LocalizacaoIdLocalizacao",
                table: "t_nimbus_usuario");

            migrationBuilder.DropColumn(
                name: "idLocalizacao",
                table: "t_nimbus_usuario");

            migrationBuilder.RenameColumn(
                name: "id_bairro",
                table: "t_nimbus_endereco",
                newName: "IdBairro");

            migrationBuilder.RenameIndex(
                name: "IX_t_nimbus_endereco_id_bairro",
                table: "t_nimbus_endereco",
                newName: "IX_t_nimbus_endereco_IdBairro");

            migrationBuilder.AddForeignKey(
                name: "FK_t_nimbus_endereco_t_nimbus_bairro_IdBairro",
                table: "t_nimbus_endereco",
                column: "IdBairro",
                principalTable: "t_nimbus_bairro",
                principalColumn: "id_bairro",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_nimbus_endereco_t_nimbus_bairro_IdBairro",
                table: "t_nimbus_endereco");

            migrationBuilder.RenameColumn(
                name: "IdBairro",
                table: "t_nimbus_endereco",
                newName: "id_bairro");

            migrationBuilder.RenameIndex(
                name: "IX_t_nimbus_endereco_IdBairro",
                table: "t_nimbus_endereco",
                newName: "IX_t_nimbus_endereco_id_bairro");

            migrationBuilder.AddColumn<int>(
                name: "LocalizacaoIdLocalizacao",
                table: "t_nimbus_usuario",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "idLocalizacao",
                table: "t_nimbus_usuario",
                type: "NUMBER(10)",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_t_nimbus_usuario_LocalizacaoIdLocalizacao",
                table: "t_nimbus_usuario",
                column: "LocalizacaoIdLocalizacao");

            migrationBuilder.AddForeignKey(
                name: "FK_t_nimbus_endereco_t_nimbus_bairro_id_bairro",
                table: "t_nimbus_endereco",
                column: "id_bairro",
                principalTable: "t_nimbus_bairro",
                principalColumn: "id_bairro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_nimbus_usuario_t_nimbus_localizacao_LocalizacaoIdLocalizacao",
                table: "t_nimbus_usuario",
                column: "LocalizacaoIdLocalizacao",
                principalTable: "t_nimbus_localizacao",
                principalColumn: "id_localizacao");
        }
    }
}
