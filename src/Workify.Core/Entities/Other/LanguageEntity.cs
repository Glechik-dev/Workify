namespace Workify.Core.Entities.Other
{
    public class LanguageEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<LanguageSkillEntity> LanguageSkills { get; set; }
    }
}
