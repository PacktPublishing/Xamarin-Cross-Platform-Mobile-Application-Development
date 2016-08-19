using System.Collections.Generic;

namespace XamFormsCustomizingRows
{
    public class Character
    {
        public string Name { get; set; }
        public string Species { get; set; }
        public string ImageUrl { get; set; }

        public override string ToString()
        {
            return string.Format("{0}, {1}", Name, Species);
        }

        public static IList<Character> Characters
        {
            get
            {
                return new List<Character>
            {
                new Character
                {
                    Name = "Owen Lars",
                    Species = "Human",
                    ImageUrl = "http://vignette1.wikia.nocookie.net/starwars/images/9/91/OwenLarsHS-SWE.jpg/revision/latest?cb=20120428164235"
                },
                new Character
                {
                    Name = "C-3PO",
                    Species = "Droid",
                    ImageUrl = "http://www.tomopop.com/ul/20046-550x-C-3PO_Bust_Header.jpg"
                },
                new Character
                {
                    Name = "R2-D2",
                    Species = "Droid",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/en/3/39/R2-D2_Droid.png"
                },
                new Character
                {
                    Name = "Darth Vader",
                    Species = "Human",
                    ImageUrl = "http://cdn.bgr.com/2015/08/darth-vader.jpg"
                },
                new Character
                {
                    Name = "Luke Skywalker",
                    Species = "Human",
                    ImageUrl = "http://xsnet.co/images/luke-skywalker/luke-skywalker-shared-photo-ba91caf33f42207b67e1a1d64e96c7d5-smaller-85767.jpg"
                },
                new Character
                {
                    Name = "Obi-Wan Kenobi",
                    Species = "Human",
                    ImageUrl = "http://f.tqn.com/y/scifi/1/W/3/n/-/-/EP2-IA-60435_R_8x10.jpg"
                }
            };
            }
        }
    }
}
