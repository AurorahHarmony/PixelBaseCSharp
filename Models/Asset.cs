using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace PixelBase.Models;

public class Asset
{
  public int Id { get; set; }

  [Required]
  [MaxLength(50)]
  [RegularExpression(@"^[a-z0-9_]+$", ErrorMessage = "lowercase letters, numbers and underscores only")]
  public string Slug { get; set; } = null!;

  [Required]
  [MaxLength(100)]
  public string Title { get; set; } = null!;

  [Required]
  [DataType(DataType.Date)]
  public DateTime CreateDate { get; set; } = DateTime.Now;

  [StringLength(1000)]
  public string? Description { get; set; }

}