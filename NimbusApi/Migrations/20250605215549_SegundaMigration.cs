using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NimbusApi.Migrations
{
    /// <inheritdoc />
    public partial class SegundaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Alerta_t_nimbus_localizacao_IdLocalizacao",
                table: "Alerta");

            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_t_nimbus_bairro_id_bairro",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_t_nimbus_gp_endereco_Endereco_IdEndereco",
                table: "t_nimbus_gp_endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_t_nimbus_usuario_t_nimbus_localizacao_idLocalizacao",
                table: "t_nimbus_usuario");

            migrationBuilder.DropIndex(
                name: "IX_t_nimbus_usuario_idLocalizacao",
                table: "t_nimbus_usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Alerta",
                table: "Alerta");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "t_nimbus_endereco");

            migrationBuilder.RenameTable(
                name: "Alerta",
                newName: "t_nimbus_alerta");

            migrationBuilder.RenameIndex(
                name: "IX_Endereco_id_bairro",
                table: "t_nimbus_endereco",
                newName: "IX_t_nimbus_endereco_id_bairro");

            migrationBuilder.RenameColumn(
                name: "IdLocalizacao",
                table: "t_nimbus_alerta",
                newName: "IdBairro");

            migrationBuilder.RenameIndex(
                name: "IX_Alerta_IdLocalizacao",
                table: "t_nimbus_alerta",
                newName: "IX_t_nimbus_alerta_IdBairro");

            migrationBuilder.AddColumn<int>(
                name: "LocalizacaoIdLocalizacao",
                table: "t_nimbus_usuario",
                type: "NUMBER(10)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_nimbus_endereco",
                table: "t_nimbus_endereco",
                column: "id_endereco");

            migrationBuilder.AddPrimaryKey(
                name: "PK_t_nimbus_alerta",
                table: "t_nimbus_alerta",
                column: "IdAlerta");

            migrationBuilder.CreateTable(
                name: "t_nimbus_previsao",
                columns: table => new
                {
                    id_previsao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    data_hora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    temperatura = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    chuva = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    codigo_chuva = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    velocidade_vento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    rajada_vento = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    umidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdBairro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_nimbus_previsao", x => x.id_previsao);
                    table.ForeignKey(
                        name: "FK_t_nimbus_previsao_t_nimbus_bairro_IdBairro",
                        column: x => x.IdBairro,
                        principalTable: "t_nimbus_bairro",
                        principalColumn: "id_bairro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_t_nimbus_usuario_LocalizacaoIdLocalizacao",
                table: "t_nimbus_usuario",
                column: "LocalizacaoIdLocalizacao");

            migrationBuilder.CreateIndex(
                name: "IX_t_nimbus_previsao_IdBairro",
                table: "t_nimbus_previsao",
                column: "IdBairro");

            migrationBuilder.AddForeignKey(
                name: "FK_t_nimbus_alerta_t_nimbus_bairro_IdBairro",
                table: "t_nimbus_alerta",
                column: "IdBairro",
                principalTable: "t_nimbus_bairro",
                principalColumn: "id_bairro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_nimbus_endereco_t_nimbus_bairro_id_bairro",
                table: "t_nimbus_endereco",
                column: "id_bairro",
                principalTable: "t_nimbus_bairro",
                principalColumn: "id_bairro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_nimbus_gp_endereco_t_nimbus_endereco_IdEndereco",
                table: "t_nimbus_gp_endereco",
                column: "IdEndereco",
                principalTable: "t_nimbus_endereco",
                principalColumn: "id_endereco",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_nimbus_usuario_t_nimbus_localizacao_LocalizacaoIdLocalizacao",
                table: "t_nimbus_usuario",
                column: "LocalizacaoIdLocalizacao",
                principalTable: "t_nimbus_localizacao",
                principalColumn: "id_localizacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_t_nimbus_alerta_t_nimbus_bairro_IdBairro",
                table: "t_nimbus_alerta");

            migrationBuilder.DropForeignKey(
                name: "FK_t_nimbus_endereco_t_nimbus_bairro_id_bairro",
                table: "t_nimbus_endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_t_nimbus_gp_endereco_t_nimbus_endereco_IdEndereco",
                table: "t_nimbus_gp_endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_t_nimbus_usuario_t_nimbus_localizacao_LocalizacaoIdLocalizacao",
                table: "t_nimbus_usuario");

            migrationBuilder.DropTable(
                name: "t_nimbus_previsao");

            migrationBuilder.DropIndex(
                name: "IX_t_nimbus_usuario_LocalizacaoIdLocalizacao",
                table: "t_nimbus_usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_nimbus_endereco",
                table: "t_nimbus_endereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_t_nimbus_alerta",
                table: "t_nimbus_alerta");

            migrationBuilder.DropColumn(
                name: "LocalizacaoIdLocalizacao",
                table: "t_nimbus_usuario");

            migrationBuilder.RenameTable(
                name: "t_nimbus_endereco",
                newName: "Endereco");

            migrationBuilder.RenameTable(
                name: "t_nimbus_alerta",
                newName: "Alerta");

            migrationBuilder.RenameIndex(
                name: "IX_t_nimbus_endereco_id_bairro",
                table: "Endereco",
                newName: "IX_Endereco_id_bairro");

            migrationBuilder.RenameColumn(
                name: "IdBairro",
                table: "Alerta",
                newName: "IdLocalizacao");

            migrationBuilder.RenameIndex(
                name: "IX_t_nimbus_alerta_IdBairro",
                table: "Alerta",
                newName: "IX_Alerta_IdLocalizacao");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "id_endereco");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Alerta",
                table: "Alerta",
                column: "IdAlerta");

            migrationBuilder.CreateIndex(
                name: "IX_t_nimbus_usuario_idLocalizacao",
                table: "t_nimbus_usuario",
                column: "idLocalizacao");

            migrationBuilder.AddForeignKey(
                name: "FK_Alerta_t_nimbus_localizacao_IdLocalizacao",
                table: "Alerta",
                column: "IdLocalizacao",
                principalTable: "t_nimbus_localizacao",
                principalColumn: "id_localizacao",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_t_nimbus_bairro_id_bairro",
                table: "Endereco",
                column: "id_bairro",
                principalTable: "t_nimbus_bairro",
                principalColumn: "id_bairro",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_nimbus_gp_endereco_Endereco_IdEndereco",
                table: "t_nimbus_gp_endereco",
                column: "IdEndereco",
                principalTable: "Endereco",
                principalColumn: "id_endereco",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_t_nimbus_usuario_t_nimbus_localizacao_idLocalizacao",
                table: "t_nimbus_usuario",
                column: "idLocalizacao",
                principalTable: "t_nimbus_localizacao",
                principalColumn: "id_localizacao",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
