using AutoMapper;
using System.Data;

namespace SimpleFeatures.AutoMapper
{
    internal class AutoMapperExampleUse : ISolution
    {
        public void Execute()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Source, Target>()
                .ForMember(dest => dest.Id, act => act.MapFrom(src => int.Parse(src.Id)))
                .ForMember(dest => dest.Key, act => act.MapFrom(src => src.Pref + src.Key))
                .ForMember(dest => dest.FullName, act => act.MapFrom(src => src.Name));
                cfg.ReplaceMemberName("Location", "Address");
                cfg.ReplaceMemberName("Some", string.Empty);
            });

            Source item = new Source
            {
                Id = "001",
                Pref = "A",
                Key = "10001",
                Name = "Robberto",
                Location = "str.Polu, 11, Szulczyw",
                SomeDate = DateTime.Now
            };

            var mapper = new Mapper(config);

            var target = mapper.Map<Target>(item);

            Output(target);
        }

        private void Output(Target item)
        {
            Console.WriteLine($"{item.Id} - {item.Key} - {item.FullName} - {item.Address} - {item.Date}");
        }
    }
}