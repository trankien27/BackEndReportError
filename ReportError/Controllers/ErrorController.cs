﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace ReportError.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ErrorController:ControllerBase
{
    private readonly AppDbContext _context;

    public ErrorController(AppDbContext context)
    {
        _context = context;
    }
    //
    [HttpGet("all")]
    public async Task<ActionResult<IEnumerable<Error>>> GetErrors()
    {
        return await _context.Errors.ToListAsync();
    }
    [HttpPost]
    public async Task<ActionResult<Error>> CreateReport([FromBody] Error error)
    {
        string id = AutoGenerate.GenerateRandomString(10);
     //string dateTime = error.TimeReport.ToString();
            error.ErrorId = id;
            _context.Errors.Add(error);
        await _context.SaveChangesAsync();
        return CreatedAtAction("GetErrors",new {id = error.ErrorId}, error);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Error>> UpdateReport(string ErrorId, [FromBody] Error error)
    {
        if (ErrorId != error.ErrorId)
        {
            return BadRequest();
        }

        _context.Entry(error).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ErrorExist(ErrorId))
            {
                return NotFound();
            }
            else
            {
                throw;
                
            }
        }

        return NoContent();
    }
  
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> DeleteReport()
    private bool ErrorExist(string ErrorId)
    {
        return _context.Errors.Any(e => e.ErrorId == ErrorId
        
        );
    }

    [HttpGet("/filter")]
 
    public IActionResult GetErrorsByAttribute(
       DateTime? fromDate,
       DateTime? toDate,
       string? typeError,
        string? shop,int pageNumber = 1, int pageSize = 10)
    {
        if (shop == null)
        {
            shop = "";
        }

        if (typeError == null)
        {
            typeError = "";
        }
        string lowerShop = shop.ToLower(); 
        string lowerTypeError = typeError.ToLower();

        int skip = (pageNumber - 1) * pageSize;

        var Errors = _context.Errors;
         
            var sortErr = Errors.Where(e => 
                    e.Shop.ToLower().Contains(lowerShop)
                    && 
                    e.DescriptionError.ToLower().Contains(lowerTypeError)
                    &&
                    e.TimeReport >= fromDate
                    &&
                   e.TimeReport <= toDate
                
                )     .Skip(skip)
                .Take(pageSize)
                .ToList();
       Console.WriteLine(Errors.Count());
        var totalItem = _context.Errors.Where(e => e.Shop.ToLower().Contains(shop.ToLower())
                                                   && 
                                                   e.DescriptionError.ToLower().Contains(typeError.ToLower())).ToList().Count();
        // var totalPage = (int)Math.Ceiling((double)totalItem / pageSize);
        
        return Ok(new { 
                            Items = sortErr,
                         totalItem = totalItem,
                         pageSize =sortErr.Count 
                         
        });
    }
   

    [HttpDelete("{id}")]
    public async Task<ActionResult<Error>> DeleteReport(String errorId)
    {
        var err = await _context.Errors.FindAsync(errorId);
        if (err == null)
        {
            return NotFound();
        }
        _context.Errors.Remove(err);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}