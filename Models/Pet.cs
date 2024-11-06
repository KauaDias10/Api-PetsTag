using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PetApi.Models
{
    [Table("cadastro")]
    public class Pet
    {
        [Key]
        public int Id { get; set; }
        
        [Column("nome_pet")]  // Mapear para a coluna 'nome_pet' no banco
        public string? NomePet { get; set; }
        
        [Column("nome_resp")]  // Mapear para a coluna 'nome_resp' no banco
        public string? NomeResp { get; set; }
        
        [Column("telefone")]  // Mapear para a coluna 'telefone' no banco
        public long? Telefone { get; set; }
    }
}
