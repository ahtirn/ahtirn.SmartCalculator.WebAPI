using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ahtirn.Domain.Models
{
    public class User
    {
        /// <summary>
        /// <param name="Age">Возраст</param>
        /// </summary>
        public byte Age { get; set; } 
        
        /// <summary>
        /// <param name="Weight">Вес</param>
        /// </summary>
        public float Weight { get; set; }

        /// <summary>
        ///<param name="Height">Рост</param>
        /// </summary>
        public short Height { get; set; }

        /// <summary>
        /// <param name="Gender">Пол</param>
        /// </summary>
        [Required]
        public Gender Gender { get; set; }
    }
    
    public enum Gender
    {
        [Description("Мужской")] Male,
        [Description("Женский")] Female
    }
}