using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class AboutController : ControllerBase
{
    private static readonly string[] RandomFacts = new[]
    {
        "Loves to code.",
        "Enjoys hiking.",
        "Fan of science fiction.",
        "Likes to cook.",
        "Avid reader."
    };

    private readonly string owner = "Repository Owner";

    [HttpGet("me")]
    public IActionResult GetRandomFact()
    {
        var random = new Random();
        var randomFact = RandomFacts[random.Next(RandomFacts.Length)];
        return Ok(new { Fact = randomFact });
    }

    [HttpGet]
    public IActionResult GetOwner()
    {
        return Ok(new { Owner = owner });
    }

    [HttpPost]
    public IActionResult PostName([FromBody] NameModel model)
    {
        return Ok(new { Message = $"Hi {model.Name} from {owner}" });
    }

    public class NameModel
    {
        public string Name { get; set; }
    }
}
