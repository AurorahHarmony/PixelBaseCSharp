using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PixelBase.Models;

public class Asset
{
  public int Id { get; set; }
  [Required]
  [MaxLength(100)]
  public string? Title { get; set; }


}