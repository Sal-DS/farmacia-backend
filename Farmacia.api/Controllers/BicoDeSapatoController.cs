using Microsoft.AspNetCore.Mvc;

namespace Farmacia.api.Controllers;

[ApiController]
[Route("api/bico-de-sapato")]
public class BicoDeSapatoController : ControllerBase
{
    [HttpGet]
    [Produces("text/plain")]
    public ContentResult Get()
    {
        const string art = """
                         \  |  /   /\
                      \   \ | /   /  \
                    .-^^^^^^^---^^^^^^^-.
                  .'                     `.
                 /       ___      ___       \
                |       /   \    /   \       |
                |      /  o  \  /  o  \      |
                |      \_____/  \_____/      |
                |          \      /           |
                |           .------.          |
                |          /        \         |
                |         /          \        |
                |        /            \       |
                 \      /              \     /
                  \    /                \   /
                   \  /                  \ /
                    \/                    V
                    ||\                  /||
                    || \                / ||
                    ||  \              /  ||
                    ||   \____________/   ||
                    ||                    ||
                    ||                    ||
                    ||                    ||
                   /  \                  /  \
                  /    \                /    \
                 /      \              /      \
        """;

        return Content(art, "text/plain; charset=utf-8");
    }
}
