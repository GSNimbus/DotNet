using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NimbusApi.Migrations
{
    /// <inheritdoc />
    public partial class firstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_nimbus_localizacao",
                columns: table => new
                {
                    id_localizacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Longitude = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Latitude = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_nimbus_localizacao", x => x.id_localizacao);
                });

            migrationBuilder.CreateTable(
                name: "t_nimbus_pais",
                columns: table => new
                {
                    id_pais = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomePais = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_nimbus_pais", x => x.id_pais);
                });

            migrationBuilder.CreateTable(
                name: "Alerta",
                columns: table => new
                {
                    IdAlerta = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Risco = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "NVARCHAR2(200)", maxLength: 200, nullable: false),
                    Mensagem = table.Column<string>(type: "NVARCHAR2(500)", maxLength: 500, nullable: false),
                    DataHora = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    IdLocalizacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alerta", x => x.IdAlerta);
                    table.ForeignKey(
                        name: "FK_Alerta_t_nimbus_localizacao_IdLocalizacao",
                        column: x => x.IdLocalizacao,
                        principalTable: "t_nimbus_localizacao",
                        principalColumn: "id_localizacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_nimbus_usuario",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Nome = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Senha = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    idLocalizacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_nimbus_usuario", x => x.id_usuario);
                    table.ForeignKey(
                        name: "FK_t_nimbus_usuario_t_nimbus_localizacao_idLocalizacao",
                        column: x => x.idLocalizacao,
                        principalTable: "t_nimbus_localizacao",
                        principalColumn: "id_localizacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_nimbus_estado",
                columns: table => new
                {
                    id_estado = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeEstado = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    IdPais = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_nimbus_estado", x => x.id_estado);
                    table.ForeignKey(
                        name: "FK_t_nimbus_estado_t_nimbus_pais_IdPais",
                        column: x => x.IdPais,
                        principalTable: "t_nimbus_pais",
                        principalColumn: "id_pais",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_nimbus_cidade",
                columns: table => new
                {
                    id_cidade = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NomeCidade = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    IdEstado = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_nimbus_cidade", x => x.id_cidade);
                    table.ForeignKey(
                        name: "FK_t_nimbus_cidade_t_nimbus_estado_IdEstado",
                        column: x => x.IdEstado,
                        principalTable: "t_nimbus_estado",
                        principalColumn: "id_estado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_nimbus_bairro",
                columns: table => new
                {
                    id_bairro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    Logradouro = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    IdCidade = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdLocalizacao = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_nimbus_bairro", x => x.id_bairro);
                    table.ForeignKey(
                        name: "FK_t_nimbus_bairro_t_nimbus_cidade_IdCidade",
                        column: x => x.IdCidade,
                        principalTable: "t_nimbus_cidade",
                        principalColumn: "id_cidade",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_nimbus_bairro_t_nimbus_localizacao_IdLocalizacao",
                        column: x => x.IdLocalizacao,
                        principalTable: "t_nimbus_localizacao",
                        principalColumn: "id_localizacao",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    id_endereco = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    cep = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    id_bairro = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.id_endereco);
                    table.ForeignKey(
                        name: "FK_Endereco_t_nimbus_bairro_id_bairro",
                        column: x => x.id_bairro,
                        principalTable: "t_nimbus_bairro",
                        principalColumn: "id_bairro",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "t_nimbus_gp_endereco",
                columns: table => new
                {
                    id_gp_endereco = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NmGrupo = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    IdUsuario = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    IdEndereco = table.Column<int>(type: "NUMBER(10)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_nimbus_gp_endereco", x => x.id_gp_endereco);
                    table.ForeignKey(
                        name: "FK_t_nimbus_gp_endereco_Endereco_IdEndereco",
                        column: x => x.IdEndereco,
                        principalTable: "Endereco",
                        principalColumn: "id_endereco",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_t_nimbus_gp_endereco_t_nimbus_usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "t_nimbus_usuario",
                        principalColumn: "id_usuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Alerta_IdLocalizacao",
                table: "Alerta",
                column: "IdLocalizacao");

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_id_bairro",
                table: "Endereco",
                column: "id_bairro");

            migrationBuilder.CreateIndex(
                name: "IX_t_nimbus_bairro_IdCidade",
                table: "t_nimbus_bairro",
                column: "IdCidade");

            migrationBuilder.CreateIndex(
                name: "IX_t_nimbus_bairro_IdLocalizacao",
                table: "t_nimbus_bairro",
                column: "IdLocalizacao");

            migrationBuilder.CreateIndex(
                name: "IX_t_nimbus_cidade_IdEstado",
                table: "t_nimbus_cidade",
                column: "IdEstado");

            migrationBuilder.CreateIndex(
                name: "IX_t_nimbus_estado_IdPais",
                table: "t_nimbus_estado",
                column: "IdPais");

            migrationBuilder.CreateIndex(
                name: "IX_t_nimbus_gp_endereco_IdEndereco",
                table: "t_nimbus_gp_endereco",
                column: "IdEndereco");

            migrationBuilder.CreateIndex(
                name: "IX_t_nimbus_gp_endereco_IdUsuario",
                table: "t_nimbus_gp_endereco",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_t_nimbus_usuario_idLocalizacao",
                table: "t_nimbus_usuario",
                column: "idLocalizacao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Alerta");

            migrationBuilder.DropTable(
                name: "t_nimbus_gp_endereco");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropTable(
                name: "t_nimbus_usuario");

            migrationBuilder.DropTable(
                name: "t_nimbus_bairro");

            migrationBuilder.DropTable(
                name: "t_nimbus_cidade");

            migrationBuilder.DropTable(
                name: "t_nimbus_localizacao");

            migrationBuilder.DropTable(
                name: "t_nimbus_estado");

            migrationBuilder.DropTable(
                name: "t_nimbus_pais");
        }
    }
}
