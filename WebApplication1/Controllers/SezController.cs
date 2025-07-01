﻿using Azure;
using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using DpeApi.Data;
using DpeApi.Model.DBModels;
using DpeApi.Model.Request;
using DpeApi.Model.Response;
using DpeApi.Services;
namespace DpeApi.Controllers
{
    //API 5556
    [ApiController]
    [Route("[controller]")]
    public class SezController : Controller
    {
        private readonly IServices _services;

        public SezController(IServices services)
        {
            _services = services;
        }
        [NonAction]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("add-test")]
        public async Task<IActionResult> AddTest(test product)
        {
            try
            {
               await _services.AddTest(product);
                return Ok("Product added successfully");
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("AddEditMststorageCharge")]
        public async Task<IActionResult> AddEditMststorageCharge(RequestMststorageCharge request)
        {
            if (request == null)
            {
                return BadRequest("Request data is required.");
            }
            try
            {
                var result =  await _services.AddMststorageCharge(request);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetMststorageCharge")]
        public async Task<ActionResult<List<mststoragecharge>>> GetMststorageCharge()
        {
            var response = await _services.GetMststorageCharge();

            if (response.Data == null || !response.Data.Any())
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }

        [HttpPost("AddEditEntry")]
        public async Task<IActionResult> AddEditEntry(RequestGetEntry request)
        {
            if (request == null)
                return BadRequest("Request data is required.");

            try
            {
                var result = await _services.AddEditGetEntry(request);

                return Ok(result);
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetAllEntries")]
        public async Task<ActionResult<List<GetEntry>>> GetAllEntries()
        {

            var response = await _services.GetAllEntries();

            if (response.Data == null || !response.Data.Any())
            {
                return NotFound(new { message = "No entries found." });
            }

            return Ok(response);
        }
    }
}
