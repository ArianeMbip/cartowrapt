namespace ApiCartobani.Controllers.v1;

using ApiCartobani.Domain.DAs.Features;
using ApiCartobani.Domain.DAs.Dtos;
using ApiCartobani.Wrappers;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;
using System.Threading;
using MediatR;

[ApiController]
[Route("api/das")]
[ApiVersion("1.0")]
public sealed class DAsController: ControllerBase
{
    private readonly IMediator _mediator;

    public DAsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    

    /// <summary>
    /// Creates a new DA record.
    /// </summary>
    /// <response code="201">DA created.</response>
    /// <response code="400">DA has missing/invalid values.</response>
    /// <response code="500">There was an error on the server while creating the DA.</response>
    [ProducesResponseType(typeof(DADto), 201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [Consumes("application/json")]
    [Produces("application/json")]
    [HttpPost(Name = "AddDA")]
    public async Task<ActionResult<DADto>> AddDA([FromBody]DAForCreationDto dAForCreation)
    {
        var command = new AddDA.Command(dAForCreation);
        var commandResponse = await _mediator.Send(command);

        return CreatedAtRoute("GetDA",
            new { commandResponse.Id },
            commandResponse);
    }


    /// <summary>
    /// Gets a single DA by ID.
    /// </summary>
    /// <response code="200">DA record returned successfully.</response>
    /// <response code="400">DA has missing/invalid values.</response>
    /// <response code="500">There was an error on the server while creating the DA.</response>
    [ProducesResponseType(typeof(DADto), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [Produces("application/json")]
    [HttpGet("{id:guid}", Name = "GetDA")]
    public async Task<ActionResult<DADto>> GetDA(Guid id)
    {
        var query = new GetDA.Query(id);
        var queryResponse = await _mediator.Send(query);

        return Ok(queryResponse);
    }


    /// <summary>
    /// Gets a list of all DAs.
    /// </summary>
    /// <response code="200">DA list returned successfully.</response>
    /// <response code="400">DA has missing/invalid values.</response>
    /// <response code="500">There was an error on the server while creating the DA.</response>
    /// <remarks>
    /// Requests can be narrowed down with a variety of query string values:
    /// ## Query String Parameters
    /// - **PageNumber**: An integer value that designates the page of records that should be returned.
    /// - **PageSize**: An integer value that designates the number of records returned on the given page that you would like to return. This value is capped by the internal MaxPageSize.
    /// - **SortOrder**: A comma delimited ordered list of property names to sort by. Adding a `-` before the name switches to sorting descendingly.
    /// - **Filters**: A comma delimited list of fields to filter by formatted as `{Name}{Operator}{Value}` where
    ///     - {Name} is the name of a filterable property. You can also have multiple names (for OR logic) by enclosing them in brackets and using a pipe delimiter, eg. `(LikeCount|CommentCount)>10` asks if LikeCount or CommentCount is >10
    ///     - {Operator} is one of the Operators below
    ///     - {Value} is the value to use for filtering. You can also have multiple values (for OR logic) by using a pipe delimiter, eg.`Title@= new|hot` will return posts with titles that contain the text "new" or "hot"
    ///
    ///    | Operator | Meaning                       | Operator  | Meaning                                      |
    ///    | -------- | ----------------------------- | --------- | -------------------------------------------- |
    ///    | `==`     | Equals                        |  `!@=`    | Does not Contains                            |
    ///    | `!=`     | Not equals                    |  `!_=`    | Does not Starts with                         |
    ///    | `>`      | Greater than                  |  `@=*`    | Case-insensitive string Contains             |
    ///    | `&lt;`   | Less than                     |  `_=*`    | Case-insensitive string Starts with          |
    ///    | `>=`     | Greater than or equal to      |  `==*`    | Case-insensitive string Equals               |
    ///    | `&lt;=`  | Less than or equal to         |  `!=*`    | Case-insensitive string Not equals           |
    ///    | `@=`     | Contains                      |  `!@=*`   | Case-insensitive string does not Contains    |
    ///    | `_=`     | Starts with                   |  `!_=*`   | Case-insensitive string does not Starts with |
    /// </remarks>
    [ProducesResponseType(typeof(IEnumerable<DADto>), 200)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [Produces("application/json")]
    [HttpGet(Name = "GetDAs")]
    public async Task<IActionResult> GetDAs([FromQuery] DAParametersDto dAParametersDto)
    {
        var query = new GetDAList.Query(dAParametersDto);
        var queryResponse = await _mediator.Send(query);

        var paginationMetadata = new
        {
            totalCount = queryResponse.TotalCount,
            pageSize = queryResponse.PageSize,
            currentPageSize = queryResponse.CurrentPageSize,
            currentStartIndex = queryResponse.CurrentStartIndex,
            currentEndIndex = queryResponse.CurrentEndIndex,
            pageNumber = queryResponse.PageNumber,
            totalPages = queryResponse.TotalPages,
            hasPrevious = queryResponse.HasPrevious,
            hasNext = queryResponse.HasNext
        };

        Response.Headers.Add("X-Pagination",
            JsonSerializer.Serialize(paginationMetadata));

        return Ok(queryResponse);
    }


    /// <summary>
    /// Deletes an existing DA record.
    /// </summary>
    /// <response code="204">DA deleted.</response>
    /// <response code="400">DA has missing/invalid values.</response>
    /// <response code="500">There was an error on the server while creating the DA.</response>
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [Produces("application/json")]
    [HttpDelete("{id:guid}", Name = "DeleteDA")]
    public async Task<ActionResult> DeleteDA(Guid id)
    {
        var command = new DeleteDA.Command(id);
        await _mediator.Send(command);

        return NoContent();
    }


    /// <summary>
    /// Updates an entire existing DA.
    /// </summary>
    /// <response code="204">DA updated.</response>
    /// <response code="400">DA has missing/invalid values.</response>
    /// <response code="500">There was an error on the server while creating the DA.</response>
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(500)]
    [Produces("application/json")]
    [HttpPut("{id:guid}", Name = "UpdateDA")]
    public async Task<IActionResult> UpdateDA(Guid id, DAForUpdateDto dA)
    {
        var command = new UpdateDA.Command(id, dA);
        await _mediator.Send(command);

        return NoContent();
    }

    // endpoint marker - do not delete this comment
}
