using System.ComponentModel;
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

  // Preview image

  [DisplayName("Image Name")]
  public string? ImageName { get; set; }
  [NotMapped]
  [DisplayName("Upload File")]
  public IFormFile? ImageFile { get; set; }

  // Downloadable Zip
  [DisplayName("Zip Name")]
  public string? ZipName { get; set; }
  [NotMapped]
  [DisplayName("Zip File")]
  public IFormFile? ZipFile { get; set; }

}