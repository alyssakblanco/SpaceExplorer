using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{

    // each planet has 3 facts in an array
    // all facts from https://nineplanets.org/kids/
    private string[] Sun = {"The Sun is located in the center of the Solar System. It is a nearly perfect sphere of hot plasma, essentially, a hot ball of glowing gases.",
                            "The connection and interactions between the Sun and Earth drive the seasons, ocean currents, weather, climate, radiation belts, and aurorae.",
                            "The Sun has a diameter of around 1.39 million kilometers / 864,000 miles. This is 109 times greater than the diameter of our planet."};
    private string[] Mercury = {"Despite being so small, Mercury is the second-densest planet in the Solar System after Earth. This means it is very compact.",
                                "During the day, Mercury's average surface temperatures can reach up to 800 degrees Fahrenheit / 430 degrees Celsius.",
                                "Mercury's changes in temperature are the most drastic in the Solar System."};
    private string[] Venus = {"One day on Venus lasts for about 243 Earth days. This is the slowest rotation of any planet making it the most spherical object in the Solar System, after the Sun.",
                            "Venus has montains, valleys, and tens of thousands of volcanoes. The highest mountain on Venus, Maxwell Montes, is 20,000 feet / 8.8 kilometers high - very similar to the highest mountain on Earth, Everest.",
                            "Venus is the second brightest object in the sky after the Moon, and the Sun."};
    private string[] Earth = {"The atmosphere of Earth is divided into 6 layers - the troposphere, stratosphere, mesosphere, thermosphere, exosphere, and ionosphere.",
                            "Earth has the greatest density out of all the planets in our Solar System. This means it is very compact.",
                            "Scientists have researched and estimated that our Earth is around 4.5 billion years old."};
    private string[] Mars = {"The tallest volcano/mountain in the Solar System is located on Mars. It is named Olympus Mons and it seems to have a height of 21 km / 13 mi.",
                            "The average temperatures on Mars is -80 degrees Fahrenheit / -60 degrees Celsius.",
                            "The first person to observe Mars with the use of a telescope was Galileo Galilei. He observed the Red Planet in 1610."};
    private string[] Jupiter = {"Jupiter is the fifth planet from the Sun and the biggest planet of our Solar System. Some consider it a failed star since it is made out of swirling gases and liquids such as 90% hydrogen, and 10% helium - very similar to the Sun.",
                                "Through the observations of Jupiter's moons, the belief that everything revolved around the Earth ended.",
                                "Jupiter's mass is almost twice of all the Solar System's planets combined. It is 318 times more massive than Earth."};
    private string[] Saturn = {"Saturn is the King of the Moons, having a total of 82 confirmed moons. There are probably more out there.",
                                "Saturn is the most oblate planet in the Solar System. Its equatorial diameter is greater than the planet's polar diameter. If you look at Saturn through a telescope, it would appear flattened.",
                                "Saturn doesn't have a solid surface. It is enveloped by swirling gases and liquids the further down you go."};
    private string[] Uranus = {"Uranus rotates in the opposite direction than most planets, from East to West. It is also the only planet known to rotate on its side.",
                                "Uranus has 13 known rings surrounding it but they are difficult to observe.",
                                "The reason why Uranus is blue is due to the presence of methane."};
    private string[] Neptune = {"Neptune is the first planet to be discovered by the use of mathematical calculations and predictions.",
                                "Neptune has a powerful magnetic field. It is 27 times stronger than Earth's.",
                                "Wind speeds on Neptune are among the fastest recorded in the Solar System. Some may reach up to 2.160 km / 1.324 mi per hour.  They are five times stronger than the strongest winds on Earth."};
    private string[] Pluto = {"Pluto was declassified from the status of planet to that of a dwarf planet in 2006 after another dwarf planet, Eris was discovered.",
                            "Pluto has an unusual orbit that takes it closer to the Sun than the farthest planet Neptune, but also, it takes it farther from the Sun than Neptune's position.",
                            "Pluto is primarily made out of ice and rock. It is relatively small even when compared to Earth's Moon, being one-sixth of the moon's mass, and one-third of its volume."};
    
    // public
    public string currentPlanet;
    public string nextPlanet;
    public TextMeshProUGUI DialogueText;
    public float DialogueSpeed;
    public string nextScene;
    
    // private
    private string finalString;
    private string Fact;
    private int randFact;

    // assigning the correct array to current planet to make this script resuable
    // doing it this way to appease C# assignment rules
    void DetermineFactPool()
    {
        if (currentPlanet == "Sun"){
            Fact = Sun[randFact];
        }
        if (currentPlanet == "Mercury"){
            Fact = Mercury[randFact];
        }
        if (currentPlanet == "Venus"){
            Fact = Venus[randFact];
        }
        if (currentPlanet == "Earth"){
            Fact = Earth[randFact];
        }
        if (currentPlanet == "Mars"){
            Fact = Mars[randFact];
        }
        if (currentPlanet == "Jupiter"){
            Fact = Jupiter[randFact];
        }
        if (currentPlanet == "Saturn"){
            Fact = Saturn[randFact];
        }
        if (currentPlanet == "Uranus"){
            Fact = Uranus[randFact];
        }
        if (currentPlanet == "Neptune"){
            Fact = Neptune[randFact];
        }
        if (currentPlanet == "Pluto"){
            Fact = Pluto[randFact];
            finalString = "Prepare to travel as far as you can into our universe!";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // initializing vars
        randFact  = Random.Range(0, 2);
        finalString = "Prepare for takeoff to " + nextPlanet;
        // starting text animations
        DetermineFactPool();
        StartCoroutine(printSentences());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator printSentences(){
        // printing the random fact
        foreach(char Character in Fact.ToCharArray()){
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }

        // letting user read
        DialogueText.text += "\n\n";
        yield return new WaitForSeconds(3);
        
        // next level about to start warning
        foreach(char Character in finalString.ToCharArray()){
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }

        // transition to next scene
        yield return new WaitForSeconds(2);
        Initiate.Fade(nextScene, Color.white, 0.5f);
    }
}

// https://www.youtube.com/watch?v=KJYXzAIwrsc
// https://gamedevbeginner.com/how-to-move-objects-in-unity/
// https://www.youtube.com/watch?v=XCOTK-a-1cc
// https://www.youtube.com/watch?v=hvgfFNorZH8