using Microsoft.AspNetCore.Http;
using System;

namespace FinalTest.WebAPI.Service
{
    public interface IFileService
    {
        Tuple<int, string> SaveImage(IFormFile imageFile);
    }
}